using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NMCrypt
{
    public partial class formNMCrypt : Form
    {
        public formNMCrypt()
        {
            InitializeComponent();
        }
        private void formNMCrypt_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            newToolStripMenuItem.Enabled = false;
            openToolStripMenuItem.Enabled = false;
            //exitToolStripMenuItem.Enabled = false;
            customizeToolStripMenuItem.Enabled = false;
            //optionsToolStripMenuItem.Enabled = false;
            contentsToolStripMenuItem.Enabled = false;
            indexToolStripMenuItem.Enabled = false;
            searchToolStripMenuItem.Enabled = false;
            aboutToolStripMenuItem.Enabled = false;
            editToolStripMenuItem.Visible = false;
            btnHide.Visible = false;
        }
        private void BeforeWorkerStart()
        {
            importprkeyToolStripMenuItem.Enabled = false;
            keygenerateToolStripMenuItem.Enabled = false;
            txtPasswordEncrypt.Enabled = false;
            txtInputEncrypt.Enabled = false;
            btnBrowserfileEncrypt.Enabled = false;
            btnBrowserfolder.Enabled = false;
            btnEncrypt.Enabled = false;
            btnImportKey.Enabled = false;
            txtInputCheck.Enabled = false;
            btnBrowserfileCheck.Enabled = false;
            btnCheck.Enabled = false;
            txtPasswordDecrypt.Enabled = false;
            txtInputDecrypt.Enabled = false;
            btnBrowserfileDecrypt.Enabled = false;
            btnDecrypt.Enabled = false;
            exitToolStripMenuItem.Enabled = false;
            optionsToolStripMenuItem.Enabled = false;
        }
        private void AfterWorkerStop()
        {
            importprkeyToolStripMenuItem.Enabled = true;
            keygenerateToolStripMenuItem.Enabled = true;
            txtPasswordEncrypt.Enabled = true;
            txtInputEncrypt.Enabled = true;
            btnBrowserfileEncrypt.Enabled = true;
            btnBrowserfolder.Enabled = true;
            btnEncrypt.Enabled = true;
            btnImportKey.Enabled = true;
            txtInputCheck.Enabled = true;
            btnBrowserfileCheck.Enabled = true;
            btnCheck.Enabled = true;
            txtPasswordDecrypt.Enabled = true;
            txtInputDecrypt.Enabled = true;
            btnBrowserfileDecrypt.Enabled = true;
            btnDecrypt.Enabled = true;
            exitToolStripMenuItem.Enabled = true;
            optionsToolStripMenuItem.Enabled = true;
        }

        //Disable close button
        //private const int CP_DISABLE_CLOSE_BUTTON = 0x200;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ClassStyle = cp.ClassStyle | CP_DISABLE_CLOSE_BUTTON;
        //        return cp;
        //    }
        //}

        string workerOptions = "";
        string pathToSave = "";
        string _PRIVATEKEY = "";
        string _PUBLICKEY = "";
        string _AESMODE = "CBC";
        string _AESKEYSIZE = "256 bits";
        string _FINALMESSAGE = "";
        //string _DROPEDPATH = "";
        int statusCount = 0;
        int statusLength = 1;
        Stopwatch stopWatch = new Stopwatch();

        public void AESAlgorithm(String inputFile, String OutputFile, String password, bool isEncrypt)
        {
            byte[] DGSignFromFile = new byte[384];
            FileStream fsInput = new(inputFile, FileMode.Open, FileAccess.Read);
            FileStream fsCipherText = new(OutputFile, FileMode.Create, FileAccess.ReadWrite);
            try
            {
                fsCipherText.SetLength(0);
                int numberBytesRead = 2 * 1024 * 1024; //2MB
                byte[] bin = new byte[numberBytesRead];
                long rdlen = 0;
                long totlen = fsInput.Length;
                int len;

                byte[] salt = new byte[32];

                if(isEncrypt)
                {
                    salt = GenerateRandomSalt();
                }
                else
                {
                    fsInput.Position = 0;
                    fsInput.Read(salt, 0, salt.Length);
                    rdlen = 32;
                }

                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                RijndaelManaged AES = new();
                AES.BlockSize = 128;
                AES.Padding = PaddingMode.PKCS7;
                AES.KeySize = 256;
                AES.Mode = CipherMode.CBC;
                switch (_AESMODE)
                {
                    case "CBC":
                        break;
                    case "ECB":
                        AES.Mode = CipherMode.ECB;
                        break;
                    case "CFB":
                        AES.Mode = CipherMode.CFB;
                        AES.FeedbackSize = 128;
                        break;
                }
                switch (_AESKEYSIZE)
                {
                    case "256 bits":
                        break;
                    case "128 bits":
                        AES.KeySize = 128;
                        break;
                    case "192 bits":
                        AES.KeySize = 192;
                        break;
                }
                int iterations = 50000;
                var key = new Rfc2898DeriveBytes(passwordBytes, salt, iterations);
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);

                CryptoStream cryptStream;
                if (isEncrypt)
                {
                    //Ghi 32 byte salt vào phần đầu của file output
                    fsCipherText.Write(salt, 0, salt.Length);
                    cryptStream = new CryptoStream(fsCipherText, AES.CreateEncryptor(), CryptoStreamMode.Write);
                }
                else
                {
                    cryptStream = new CryptoStream(fsCipherText, AES.CreateDecryptor(), CryptoStreamMode.Write);
                }
                //Read from the input file, then encrypt and write to the output file.
                lblPercentcount.Text = "";
                lblPercentcount.Refresh();
                while (rdlen < totlen)
                {
                    long position = fsInput.Position;
                    len = fsInput.Read(bin, 0, numberBytesRead); // Lần lượt đọc 2MB / 1 lần trong file input
                    rdlen = rdlen + len;
                    if(rdlen >= totlen && !isEncrypt)
                    {
                        fsInput.Position = position;
                        len = fsInput.Read(bin, 0, len - 384);
                    }
                    cryptStream.Write(bin, 0, len);

                    int value = (int)((rdlen * 100) / totlen);
                    if(value != progressContinuous.Maximum)
                    {
                        progressContinuous.Value = value + 1;
                    }
                    else
                    {
                        progressContinuous.Maximum = value + 1;
                        progressContinuous.Value = value + 1;
                        progressContinuous.Maximum = value;
                    }
                    progressContinuous.Value = value;
                    progressContinuous.Refresh();

                    lblPercentcount.Text = ((long)(rdlen * 100) / totlen).ToString() + " %";
                    lblPercentcount.Refresh();
                }
                cryptStream.FlushFinalBlock();
                lblPercentcount.Text = "";
                lblPercentcount.Refresh();

                if (isEncrypt)
                {
                    progressBarmarquee.Visible = true;
                    //Hash File:
                    lblStatus.Text = statusCount + "/" + statusLength + ". Signing to file...";
                    statusCount++;
                    fsCipherText.Position = 0;
                    string SHAoutput = HashFile(fsCipherText);

                    string DGSignBase64 = RsaEncryptWithPrivate(SHAoutput, _PRIVATEKEY);
                    byte[] DGSignByte = Convert.FromBase64String(DGSignBase64);
                    fsCipherText.Write(DGSignByte, 0, DGSignByte.Length);
                    //txtDGsignature.Text = RsaEncryptWithPrivate(txtSHAoutput.Text, "privateKey.pem");
                    progressBarmarquee.Visible = false;
                }
                cryptStream.Close();
                fsInput.Close();
                fsCipherText.Close();
            }
            catch
            {
                fsInput.Close();
                fsCipherText.Close();
            }

        }

        public static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];
            using (RNGCryptoServiceProvider rng = new())
            {
                for (int i = 0; i < 10; i++)
                {
                    rng.GetBytes(data);
                }
            }
            return data;
        }

        public string HashFile(FileStream stream)
        {
            SHA512 sha512 = SHA512.Create();
            return BitConverter.ToString(sha512.ComputeHash(stream)).Replace("-", "").ToUpper();
        }

        public string RsaEncryptWithPrivate(string clearText, string prkeyPath)
        {
            string privateKey = File.ReadAllText(prkeyPath);
            var bytesToEncrypt = Encoding.UTF8.GetBytes(clearText);
            var encryptEngine = new OaepEncoding(new RsaEngine());
            using (var txtreader = new StringReader(privateKey))
            {
                var keyPair = (AsymmetricCipherKeyPair)new PemReader(txtreader).ReadObject();
                encryptEngine.Init(true, keyPair.Private);
            }
            var encrypted = Convert.ToBase64String(encryptEngine.ProcessBlock(bytesToEncrypt, 0, bytesToEncrypt.Length));
            return encrypted;
        }

        public string RsaDecryptWithPublic(string base64Input, string pbkeyPath)
        {
            string publicKey = File.ReadAllText(pbkeyPath);
            var bytesToDecrypt = Convert.FromBase64String(base64Input);
            var decryptEngine = new OaepEncoding(new RsaEngine());
            using (var txtreader = new StringReader(publicKey))
            {
                var keyParameter = (AsymmetricKeyParameter)new PemReader(txtreader).ReadObject();
                decryptEngine.Init(false, keyParameter);
            }
            var decrypted = Encoding.UTF8.GetString(decryptEngine.ProcessBlock(bytesToDecrypt, 0, bytesToDecrypt.Length));
            return decrypted;
        }

        public void CompressFolder(string path)
        {
            if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
            {
                pathToSave = path + ".NMcrx";
                int count = 1;  
                while (File.Exists(pathToSave))
                {
                    count++;
                    pathToSave = path + " (" + count + ")" + ".NMcrx";
                }
                ZipFile.CreateFromDirectory(path, pathToSave);
            }
        }

        public void ExtractFolder(string path)
        {
            string fileType = Path.GetExtension(path);
            if (fileType == ".NMcrx")
            {
                pathToSave = Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path);
                string tempPath = pathToSave;
                int count = 1;
                while (Directory.Exists(pathToSave))
                {
                    count++;
                    pathToSave = tempPath + " (" + count + ")";
                }
                Directory.CreateDirectory(pathToSave);
                ZipFile.ExtractToDirectory(path, pathToSave);
            }
        }

        public void DeleteFolder(string path)
        {
            Directory.Delete(path);
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        private void chbxDisplaypassword_CheckedChanged(object sender, EventArgs e)
        {
            if (btnShow.Visible == true)
            {
                txtPasswordEncrypt.PasswordChar = '\0';
                btnShow.Visible = false;
                btnHide.Visible = true;
            }
            else
            {
                txtPasswordEncrypt.PasswordChar = '\u25cf';
                btnHide.Visible = false;
                btnShow.Visible = true;
            }
        }

        private void btnBrowserfile_Click(object sender, EventArgs e)
        {
            txtInputEncrypt.Text = "";
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All Files (*.*)|*.*";
            op.Title = "Select File";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtInputEncrypt.Text = op.FileName;
            }
        }

        private void btnBrowserfolder_Click(object sender, EventArgs e)
        {
            txtInputEncrypt.Text = "";
            FolderBrowserDialog fb = new();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                txtInputEncrypt.Text = fb.SelectedPath;
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.Dispose();
                if(_PRIVATEKEY == "")
                {
                    MessageBox.Show(this, "You need to import your private key first! \nGo to File -> Import Private Key (.pem)", "NMCrypt Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (!File.Exists(txtInputEncrypt.Text))
                {
                    if(!Directory.Exists(txtInputEncrypt.Text))
                    {
                        MessageBox.Show(this, "Invalid input path. Couldn't find your file or folder!", "NMCrypt Message", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }
                workerOptions = "encrypt";
                if (!backgroundWorker1.IsBusy)
                {
                    progressBarmarquee.Visible = false;
                    progressBarmarquee.Style = ProgressBarStyle.Marquee;
                    progressBarmarquee.MarqueeAnimationSpeed = 1;
                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    return;
                }
            }
            catch { }
        }
        private void Encrypt(DoWorkEventArgs e)
        {
            try
            {
                statusLength = 2;
                statusCount = 1;
                string inputFileName = txtInputEncrypt.Text;
                string outputFileName = inputFileName;
                string password = txtPasswordEncrypt.Text;

                string fileOrfolder = "";
                if (File.GetAttributes(inputFileName).HasFlag(FileAttributes.Directory))
                {
                    statusLength++;
                    fileOrfolder = "Folder";
                    outputFileName = inputFileName + ".NMCryptF";
                    int count = 1;
                    while(File.Exists(outputFileName))
                    {
                        count++;
                        outputFileName = inputFileName + " (" + count + ")" + ".NMCryptF";
                    }
                    lblStatus.Text = statusCount + "/" + statusLength + ". " + "Compressing folder...";
                    progressBarmarquee.Visible = true;
                    statusCount++;
                    CompressFolder(inputFileName);
                    progressBarmarquee.Visible = false;
                    inputFileName = pathToSave;
                }
                else
                {
                    fileOrfolder = "File";
                    outputFileName = inputFileName + ".NMCrypt";
                    int count = 1;
                    while (File.Exists(outputFileName))
                    {
                        count++;
                        outputFileName = Path.Combine(Path.GetDirectoryName(inputFileName), Path.GetFileNameWithoutExtension(inputFileName) + " (" + count + ")" + Path.GetExtension(inputFileName) + ".NMCrypt");
                    }
                }
                lblStatus.Text = statusCount + "/" + statusLength + ". " + fileOrfolder + " is being encrypt...";
                statusCount++;
                AESAlgorithm(inputFileName, outputFileName, password, true);

                if (fileOrfolder == "Folder")
                {
                    DeleteFile(inputFileName);
                }
                _FINALMESSAGE = "File save at\n" + outputFileName;

                lblStatus.Text = fileOrfolder + " encrypt successful!";
            }
            catch
            {
                
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.Dispose();
                FileAttributes attr = File.GetAttributes(txtInputDecrypt.Text);
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    MessageBox.Show(this, "Sorry, this file type is not supported here!", "NMCrypt Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                else
                {
                    if (!File.Exists(txtInputDecrypt.Text))
                    {
                        if (!Directory.Exists(txtInputDecrypt.Text))
                        {
                            MessageBox.Show(this, "Invalid input path. Couldn't find your file!", "NMCrypt Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                    else
                    {
                        if (Path.GetExtension(txtInputDecrypt.Text) != ".NMCryptF" && Path.GetExtension(txtInputDecrypt.Text) != ".NMCrypt")
                        {
                            MessageBox.Show(this, "Sorry, this file type is not supported here!", "NMCrypt Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                }
                workerOptions = "decrypt";
                if (!backgroundWorker1.IsBusy)
                {
                    progressBarmarquee.Visible = false;
                    progressBarmarquee.Style = ProgressBarStyle.Marquee;
                    progressBarmarquee.MarqueeAnimationSpeed = 1;
                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    return;
                }
            }
            catch { }
        }

        private void Decrypt(DoWorkEventArgs e)
        {
            statusLength = 1;
            statusCount = 1;
            string inputFileName = txtInputDecrypt.Text;
            string password = txtPasswordDecrypt.Text;
            string outputFileName = inputFileName;
            string tempFileName = "";
            try
            {
                string fileOrfolder = "";
                if (Path.GetExtension(inputFileName) == ".NMCryptF")
                {
                    statusLength++;
                    fileOrfolder = "Folder";
                    tempFileName = Path.Combine(Path.GetDirectoryName(inputFileName), Path.GetFileNameWithoutExtension(inputFileName));
                    outputFileName = tempFileName + ".NMcrx";
                    int count = 1;
                    while (File.Exists(outputFileName))
                    {
                        count++;
                        outputFileName = tempFileName + " (" + count + ")" + ".NMcrx";
                    }
                }
                else
                {
                    if(Path.GetExtension(inputFileName) == ".NMCrypt")
                    {
                        fileOrfolder = "File";
                        tempFileName = Path.Combine(Path.GetDirectoryName(inputFileName) + "\\" + Path.GetFileNameWithoutExtension(inputFileName));
                        outputFileName = tempFileName;
                        int count = 1;
                        while (File.Exists(outputFileName))
                        {
                            count++;
                            outputFileName = Path.Combine(Path.GetDirectoryName(tempFileName), Path.GetFileNameWithoutExtension(tempFileName) + " (" + count + ")" + Path.GetExtension(tempFileName));
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                lblStatus.Text = statusCount + "/" + statusLength + ". " + fileOrfolder + " is being decrypt...";
                statusCount++;
                AESAlgorithm(inputFileName, outputFileName, password, false);

                if (fileOrfolder == "Folder")
                {
                    lblPercentcount.Text = "";
                    lblPercentcount.Refresh();
                    progressBarmarquee.Visible = true;
                    lblStatus.Text = statusCount + "/" + statusLength + ". " + "Extracting...";
                    statusCount++;
                    ExtractFolder(outputFileName);
                    DeleteFile(outputFileName);
                    progressBarmarquee.Visible = false;
                    outputFileName = pathToSave;
                }

                _FINALMESSAGE = fileOrfolder + " save at " + outputFileName;
                lblStatus.Text = fileOrfolder + " decrypt successful!";
            }
            catch
            {
                DeleteFile(outputFileName);
                DeleteFolder(pathToSave);
                _FINALMESSAGE = "Cannot decrypt, Password incorrect!";
            }
        }
        private void keygenerateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.Dispose();
                workerOptions = "generateRSAKey";
                statusLength = 1;
                statusCount = 1;
                FolderBrowserDialog fb = new();
                if (fb.ShowDialog() == DialogResult.OK)
                {
                    pathToSave = fb.SelectedPath;
                    if (!backgroundWorker1.IsBusy)
                    {
                        progressBarmarquee.Visible = false;
                        progressBarmarquee.Style = ProgressBarStyle.Marquee;
                        progressBarmarquee.MarqueeAnimationSpeed = 1;
                        backgroundWorker1.RunWorkerAsync();
                    }
                    else
                    {
                        lblStatus.Text = "Ready!";
                        return;
                    }
                }
            }
            catch 
            {
                
            }
        }
        private void generateRSAKey(DoWorkEventArgs e)
        {
            progressBarmarquee.Visible = true;
            lblStatus.Text = statusCount + "/" + statusLength + ". " + "Generating RSA public key and private key...";
            statusCount++;
            //RSA key pair Generator generates the RSA kay pair based on the Random Number and the strength of key required 
            RsaKeyPairGenerator rsaKeyPairGenerator = new RsaKeyPairGenerator();
            rsaKeyPairGenerator.Init(new KeyGenerationParameters(new SecureRandom(), 3072));
            AsymmetricCipherKeyPair keyPair = rsaKeyPairGenerator.GenerateKeyPair();

            //Extracting the private key from the pair
            RsaKeyParameters privatekey = (RsaKeyParameters)keyPair.Private;
            RsaKeyParameters publickey = (RsaKeyParameters)keyPair.Public;


            //To print the public key in pem format
            TextWriter textWriter1 = new StringWriter();
            PemWriter pemWriter1 = new PemWriter(textWriter1);
            pemWriter1.WriteObject(publickey);
            pemWriter1.Writer.Flush();
            string print_publickey = textWriter1.ToString();
            File.WriteAllText(pathToSave + @"\publicKey.pem", print_publickey);


            //To print the private key in pem format
            TextWriter textWriter2 = new StringWriter();
            PemWriter pemWriter2 = new PemWriter(textWriter2);
            pemWriter2.WriteObject(privatekey);
            pemWriter2.Writer.Flush();
            string print_privatekey = textWriter2.ToString();
            File.WriteAllText(pathToSave + @"\privateKey.pem", print_privatekey);

            progressBarmarquee.Visible = false;
            lblStatus.Text = "Generate successful!";
            _FINALMESSAGE = "Generate RSA key successful!\nFilename: publicKey.pem & privateKey.pem \nAt " + pathToSave;
            pathToSave = "";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            stopWatch.Reset();
            stopWatch.Start();
            btnReset.Enabled = false;
            BeforeWorkerStart();
            if (workerOptions == "encrypt")
            {
                Encrypt(e);
                return;
            }
            if (workerOptions == "decrypt")
            {
                Decrypt(e);
                return;
            }
            if(workerOptions == "generateRSAKey")
            {
                generateRSAKey(e);
                return;
            }
            if(workerOptions == "verifyfile")
            {
                VerifyFileIntegrity(e);
                return;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}h {1:00}m {2:00}s {3:00}ms", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            progressBarmarquee.Visible = false;
            progressBarmarquee.MarqueeAnimationSpeed = 0;
            progressBarmarquee.Style = ProgressBarStyle.Continuous;
            btnReset.Enabled = true;
            AfterWorkerStop();
            _FINALMESSAGE = _FINALMESSAGE + "\nTotal time: " + elapsedTime;
            MessageBox.Show(this, _FINALMESSAGE, "NMCrypt Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            lblStatus.Text = "Ready!";
            lblStatus.Refresh();
            lblPercentcount.Text = "";
            lblPercentcount.Refresh();
            progressContinuous.Value = 0;
        }

        private void btnVerifyfile_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.Dispose();
                if(_PUBLICKEY == "")
                {
                    MessageBox.Show(this, "You need to import public key first!", "NMCrypt Message", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                FileAttributes attr = File.GetAttributes(txtInputCheck.Text);
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    MessageBox.Show(this, "Sorry, this file type is not supported here!", "NMCrypt Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                else
                {
                    if (!File.Exists(txtInputCheck.Text))
                    {
                        if (!Directory.Exists(txtInputCheck.Text))
                        {
                            MessageBox.Show(this, "Invalid input path. Couldn't find your file!", "NMCrypt Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                    else
                    {
                        if (Path.GetExtension(txtInputCheck.Text) != ".NMCryptF" && Path.GetExtension(txtInputCheck.Text) != ".NMCrypt")
                        {
                            MessageBox.Show(this, "Sorry, this file type is not supported here!", "NMCrypt Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                }


                
                statusLength = 1;
                statusCount = 1;
                workerOptions = "verifyfile";
                if (!backgroundWorker1.IsBusy)
                {
                    progressBarmarquee.Visible = false;
                    progressBarmarquee.Style = ProgressBarStyle.Marquee;
                    progressBarmarquee.MarqueeAnimationSpeed = 1;
                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    return;
                }
            }
            catch { }
        }
        private void VerifyFileIntegrity(DoWorkEventArgs e)
        {
            string inputFileName = txtInputCheck.Text;
            byte[] DGSignFromFile = new byte[384];
            FileStream fsInput = new(inputFileName, FileMode.Open, FileAccess.Read);
            try
            {
                progressBarmarquee.Visible = false;
                lblStatus.Text = statusCount + "/" + statusLength + ". " + "Verifying file integrity...";
                statusCount++;
                fsInput.Seek(-384, SeekOrigin.End);
                fsInput.Read(DGSignFromFile, 0, DGSignFromFile.Length);
                string SHAGetFromFile = RsaDecryptWithPublic(Convert.ToBase64String(DGSignFromFile), _PUBLICKEY);

                //Read from the input file, then calculate hash of the input file.
                fsInput.Position = 0;
                lblPercentcount.Text = "";
                lblPercentcount.Refresh();
                int numberBytesRead = 2 * 1024 * 1024; //2MB
                byte[] bin = new byte[numberBytesRead];
                long rdlen = 0;
                long totlen = fsInput.Length;
                int len = 0;
                SHA512 sha512 = SHA512.Create();
                while (rdlen < totlen)
                {
                    long position = fsInput.Position;
                    len = fsInput.Read(bin, 0, numberBytesRead); // Lần lượt đọc 2MB / 1 lần trong file input
                    rdlen = rdlen + len;
                    if (rdlen >= totlen)
                    {
                        fsInput.Position = position;
                        len = fsInput.Read(bin, 0, len - 384);
                    }
                    sha512.TransformBlock(bin, 0, len, null, 0);

                    int value = (int)((rdlen * 100) / totlen);
                    if (value != progressContinuous.Maximum)
                    {
                        progressContinuous.Value = value + 1;
                    }
                    else
                    {
                        progressContinuous.Maximum = value + 1;
                        progressContinuous.Value = value + 1;
                        progressContinuous.Maximum = value;
                    }
                    progressContinuous.Value = value;
                    progressContinuous.Refresh();

                    lblPercentcount.Text = ((long)(rdlen * 100) / totlen).ToString() + " %";
                    lblPercentcount.Refresh();
                }
                sha512.TransformFinalBlock(new byte[0], 0, 0);
                string SHAComputeFromFile = BitConverter.ToString(sha512.Hash).Replace("-", "").ToUpper();

                if (SHAGetFromFile == SHAComputeFromFile)
                {
                    _FINALMESSAGE = "Your file is safe. You can decrypt it!";
                }
                else
                {
                    _FINALMESSAGE = "Warning!\nThis file has been change (Not have integrity)!";
                }
                lblStatus.Text = "Completed!";
                fsInput.Close();
            }
            catch
            {
                fsInput.Close();
                _FINALMESSAGE = "Warning!\nThis file has been change (Not have integrity)!";
            }
        }

        private void chbxDisplaypasswordDecrypt_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void importpukeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new();
            op.Filter = "File (*.pem*)|*.pem*";
            op.Title = "Import Private Key File (.pem)";
            if (op.ShowDialog() == DialogResult.OK)
            {
                if(File.ReadLines(op.FileName).First() == "-----BEGIN RSA PRIVATE KEY-----")
                {
                    _PRIVATEKEY = op.FileName;
                    MessageBox.Show(this, "Import private key completed", "NMCrypt Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show(this, "Invalid private key.", "NMCrypt Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btnImportKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new();
            op.Filter = "File (*.pem)|*.pem";
            op.Title = "Import Public Key File (.pem)";
            if (op.ShowDialog() == DialogResult.OK)
            {
                if (File.ReadLines(op.FileName).First() == "-----BEGIN PUBLIC KEY-----")
                {
                    _PUBLICKEY = op.FileName;
                    MessageBox.Show(this, "Import public key completed", "NMCrypt Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show(this, "Invalid public key.", "NMCrypt Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btnBrowserfileCheck_Click(object sender, EventArgs e)
        {
            txtInputCheck.Text = "";
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "File (*.NMCrypt;*.NMCryptf)|*.NMCrypt;*NMCryptF";
            op.Title = "Select File";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtInputCheck.Text = op.FileName;
            }
        }

        private void btnBrowserfileDecrypt_Click(object sender, EventArgs e)
        {
            txtInputDecrypt.Text = "";
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "File (*.NMCrypt;*.NMCryptf)|*.NMCrypt;*NMCryptF";
            op.Title = "Select File";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtInputDecrypt.Text = op.FileName;
            }
        }

        private void btnShowD_Click(object sender, EventArgs e)
        {
            if (btnShowD.Visible == true)
            {
                txtPasswordDecrypt.PasswordChar = '\0';
                btnShowD.Visible = false;
                btnHideD.Visible = true;
            }
            else
            {
                txtPasswordDecrypt.PasswordChar = '\u25cf';
                btnHideD.Visible = false;
                btnShowD.Visible = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            importprkeyToolStripMenuItem.Enabled = true;
            keygenerateToolStripMenuItem.Enabled = true;
            txtPasswordEncrypt.Enabled = true;
            txtInputEncrypt.Enabled = true;
            btnBrowserfileEncrypt.Enabled = true;
            btnBrowserfolder.Enabled = true;
            btnEncrypt.Enabled = true;
            btnImportKey.Enabled = true;
            txtInputCheck.Enabled = true;
            btnBrowserfileCheck.Enabled = true;
            btnCheck.Enabled = true;
            txtPasswordDecrypt.Enabled = true;
            txtInputDecrypt.Enabled = true;
            btnBrowserfileDecrypt.Enabled = true;
            btnDecrypt.Enabled = true;
            exitToolStripMenuItem.Enabled = true;

            txtPasswordEncrypt.Text = "";
            txtInputEncrypt.Text = "";
            txtInputCheck.Text = "";
            txtPasswordDecrypt.Text = "";
            txtInputDecrypt.Text = "";
            workerOptions = "";
            pathToSave = "";
            _PRIVATEKEY = "";
            _PUBLICKEY = "";
            _FINALMESSAGE = "";
            //string _DROPEDPATH = "";
            statusCount = 0;
            statusLength = 1;
        }

        private void chbTopmost_CheckedChanged(object sender, EventArgs e)
        {
            if(chbTopmost.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void btnEncrypt_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if(fileList.Length == 1)
            {
                if(tabControl1.SelectedTab == tabEncrypt)
                {
                    txtInputEncrypt.Text = fileList[0];
                    btnEncrypt_Click(sender, e);
                }
                if (tabControl1.SelectedTab == tabCheck)
                {
                    txtInputCheck.Text = fileList[0];
                    btnVerifyfile_Click(sender, e);
                }
                if (tabControl1.SelectedTab == tabDecrypt)
                {
                    txtInputDecrypt.Text = fileList[0];
                    btnDecrypt_Click(sender, e);
                }
            }
        }

        private void btnEncrypt_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "NMCrypt Confirm Exit", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formOptions f = new();
            f.tempMode = _AESMODE;
            f.tempKeySize = _AESKEYSIZE;
            f._AESMode = new formOptions.GETDATA(getAESMode);
            f._AESKeySize = new formOptions.GETDATA(getAESKeySize);
            if (this.TopMost == true)
            {
                chbTopmost.Checked = false;
                f.ShowDialog();
                chbTopmost.Checked = true;
            }
            else
            {
                f.ShowDialog();
            }
        }

        public void getAESMode(string value)
        {
            _AESMODE = value;
        }
        public void getAESKeySize(string value)
        {
            _AESKEYSIZE = value;
        }
    }
}
