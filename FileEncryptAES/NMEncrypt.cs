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
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileEncryptAES
{
    public partial class NMEncrypt : Form
    {
        public NMEncrypt()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            newToolStripMenuItem.Enabled = false;
            openToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            printPreviewToolStripMenuItem.Enabled = false;
            printToolStripMenuItem.Enabled = false;
            exitToolStripMenuItem.Enabled = false;
            customizeToolStripMenuItem.Enabled = false;
            optionsToolStripMenuItem.Enabled = false;
            contentsToolStripMenuItem.Enabled = false;
            indexToolStripMenuItem.Enabled = false;
            searchToolStripMenuItem.Enabled = false;
            aboutToolStripMenuItem.Enabled = false;
            editToolStripMenuItem.Visible = false;
        }
        string workerOptions = "";
        string pathToSave = "";
        string _PRIVATEKEY = "";
        string _PUBLICKEY = "";

        public void AESAlgorithm(String inputFile, String OutputFile, String password, bool isEncrypt)
        {
            byte[] DGSignFromFile = new byte[384];
            bool isGotDGSign = false;
            FileStream fsInput = new(inputFile, FileMode.Open, FileAccess.ReadWrite);
            FileStream fsCipherText = new(OutputFile, FileMode.Create, FileAccess.ReadWrite);
            try
            {
                fsCipherText.SetLength(0);
                int numberBytesRead = 1048576;//1MB
                byte[] bin = new byte[numberBytesRead];
                long rdlen = 0;
                long totlen = fsInput.Length;
                int len;
                //progressBar1.Minimum = 0;
                //progressBar1.Maximum = 100;

                byte[] salt = new byte[32];

                if(isEncrypt)
                {
                    salt = GenerateRandomSalt();
                }
                else
                {
                    //fsInput.Seek(-384, SeekOrigin.End);
                    //fsInput.Read(DGSignFromFile, 0, DGSignFromFile.Length);
                    //fsInput.SetLength(totlen - DGSignFromFile.Length);
                    //isGotDGSign = true;
                    //totlen = fsInput.Length;
                    fsInput.Position = 0;
                    fsInput.Read(salt, 0, salt.Length);
                    rdlen = 32;
                }

                byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
                RijndaelManaged AES = new();
                AES.KeySize = 256;
                AES.BlockSize = 128;
                AES.Padding = PaddingMode.PKCS7;
                AES.Mode = CipherMode.CFB;
                AES.FeedbackSize = 128;
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
                while (rdlen < totlen)
                {
                    long position = fsInput.Position;
                    len = fsInput.Read(bin, 0, numberBytesRead); // Lần lượt đọc 1MB / 1 lần trong file input
                    rdlen = rdlen + len;
                    if(rdlen >= totlen && !isEncrypt)
                    {
                        fsInput.Position = position;
                        len = fsInput.Read(bin, 0, len - 384);
                    }
                    cryptStream.Write(bin, 0, len);

                    //label1.Text = "Tên tệp xử lý : " + Path.GetFileName(inputFile) + "\t Thành công: " + ((long)(rdlen * 100) / totlen).ToString() + " %";
                    //label1.Refresh();

                    //progressBar1.Value = (int)((rdlen * 100) / totlen);

                }
                cryptStream.FlushFinalBlock();

                if (isEncrypt)
                {
                    //Hash File:
                    lblStatus.Text = "Get Hash value...";
                    fsCipherText.Position = 0;
                    string SHAoutput = HashFile(fsCipherText);

                    //Sign to file
                    lblStatus.Text = "Signging to file...";
                    string DGSignBase64 = RsaEncryptWithPrivate(SHAoutput, _PRIVATEKEY);
                    byte[] DGSignByte = Convert.FromBase64String(DGSignBase64);
                    fsCipherText.Write(DGSignByte, 0, DGSignByte.Length);
                    //txtDGsignature.Text = RsaEncryptWithPrivate(txtSHAoutput.Text, "privateKey.pem");
                }
                else
                {
                    //fsInput.Write(DGSignFromFile, 0, DGSignFromFile.Length);
                    //isGotDGSign = false;
                    //fsCipherText.SetLength( fsCipherText.Length - 384 );
                }


                ////if (progressBar1.IsHandleCreated && isEncryptFile)
                ////{
                ////    System.Diagnostics.Process prc = new System.Diagnostics.Process();
                ////    prc.StartInfo.FileName = Path.GetDirectoryName(txtInput.Text);
                ////    prc.Start();
                ////}

                try
                {
                    cryptStream.Close();
                    fsInput.Close();
                    isGotDGSign = false;
                    fsCipherText.Close();
                }
                catch
                {
                    if( isGotDGSign && !isEncrypt )
                    {
                        fsInput.Write(DGSignFromFile, 0, DGSignFromFile.Length);
                        isGotDGSign = false;
                    }
                    fsInput.Close();
                    fsCipherText.Close();
                }
            }
            catch
            {
                if (isGotDGSign && !isEncrypt )
                {
                    fsInput.Write(DGSignFromFile, 0, DGSignFromFile.Length);
                }
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
            using var sha512 = SHA512.Create();
            return BitConverter.ToString(sha512.ComputeHash(stream)).Replace("-", "").ToUpper();
        }

        public string RsaEncryptWithPrivate(string clearText, string prkeyPath)
        {
            string privateKey = File.ReadAllText(prkeyPath);
            var bytesToEncrypt = Encoding.UTF8.GetBytes(clearText);
            var encryptEngine = new Pkcs1Encoding(new RsaEngine());
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
            var decryptEngine = new Pkcs1Encoding(new RsaEngine());
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
                lblStatus.Text = "Compressing...";
                pathToSave = path + ".NMTemp";
                int count = 1;
                while (File.Exists(pathToSave))
                {
                    count++;
                    pathToSave = path + " (" + count + ")" + ".NMTemp";
                }
                ZipFile.CreateFromDirectory(path, pathToSave);
            }
        }

        public void ExtractFolder(string path)
        {
            string fileType = Path.GetExtension(path);
            if (fileType == ".NMTemp")
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
            if (chbxDisplaypassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '\u25cf';
            }
        }

        private void btnBrowserfile_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All Files (*.*)|*.*";
            op.Title = "Select File";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtInput.Text = op.FileName;
            }
        }

        private void btnBrowserfolder_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
            FolderBrowserDialog fb = new();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                txtInput.Text = fb.SelectedPath;
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                workerOptions = "encrypt";
                OpenFileDialog op = new();
                op.Filter = "PEM File (*.pem*)|*.pem*";
                op.Title = "Import Private Key File (.pem)";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    if (!backgroundWorker1.IsBusy)
                    {
                        _PRIVATEKEY = op.FileName;
                        backgroundWorker1.RunWorkerAsync();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch { }
        }
        private void Encrypt(DoWorkEventArgs e)
        {
            try
            {
                string inputFileName = txtInput.Text;
                string outputFileName = inputFileName;
                string password = txtPassword.Text;

                string fileOrfolder = "";
                if (File.GetAttributes(inputFileName).HasFlag(FileAttributes.Directory))
                {
                    fileOrfolder = "Folder";
                    outputFileName = inputFileName + ".NMCryptF";
                    int count = 1;
                    while(File.Exists(outputFileName))
                    {
                        count++;
                        outputFileName = inputFileName + " (" + count + ")" + ".NMCryptF";
                    }
                    CompressFolder(inputFileName);
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

                lblStatus.Text = fileOrfolder + " is being encrypt...";
                AESAlgorithm(inputFileName, outputFileName, password, true);

                lblStatus.Text = "Completed!";
                if(fileOrfolder == "Folder")
                {
                    DeleteFile(inputFileName);
                }
                MessageBox.Show("File save at\n" + outputFileName, "Completed!");
            }
            catch { }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                workerOptions = "decrypt";
                if (!backgroundWorker1.IsBusy)
                {
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
            string inputFileName = txtInput.Text;
            string password = txtPassword.Text;
            string outputFileName = inputFileName;
            string tempFileName = "";
            try
            {

                string fileOrfolder = "";
                if (Path.GetExtension(inputFileName) == ".NMCryptF")
                {
                    fileOrfolder = "Folder";
                    tempFileName = Path.Combine(Path.GetDirectoryName(inputFileName), Path.GetFileNameWithoutExtension(inputFileName));
                    outputFileName = tempFileName + ".NMTemp";
                    int count = 1;
                    while (File.Exists(outputFileName))
                    {
                        count++;
                        outputFileName = tempFileName + " (" + count + ")" + ".NMTemp";
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
                        MessageBox.Show("Sorry, this file type is not supported here!", "Error!");
                        return;
                    }
                }

                lblStatus.Text = fileOrfolder + " is being decrypt...";
                AESAlgorithm(inputFileName, outputFileName, password, false);

                if(fileOrfolder == "Folder")
                {
                    lblStatus.Text = "Extracting...";

                    ExtractFolder(outputFileName);
                    DeleteFile(outputFileName);
                    outputFileName = pathToSave;
                }

                lblStatus.Text = fileOrfolder + " decrypt successful";
                MessageBox.Show(fileOrfolder + " save at " + outputFileName, "Completed!");
            }
            catch
            {
                DeleteFile(outputFileName);
                DeleteFolder(pathToSave);
                MessageBox.Show("Cannot decrypt, Password incorrect!", "Error!");
            }
        }
        private void keygenerateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                workerOptions = "generateRSAKey";
                FolderBrowserDialog fb = new();
                if (fb.ShowDialog() == DialogResult.OK)
                {
                    pathToSave = fb.SelectedPath;
                    if (!backgroundWorker1.IsBusy)
                    {
                        backgroundWorker1.RunWorkerAsync();
                    }
                    else
                    {
                        return;
                    }

                }
            }
            catch { pathToSave = ""; }
        }
        private void generateRSAKey(DoWorkEventArgs e)
        {
            lblStatus.Text = "Generating RSA public key and private key...";
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

            lblStatus.Text = "Public key and Private key generate completed";
            MessageBox.Show("Filename: publicKey.pem & privateKey.pem\nAt " + pathToSave, "Generate and save key successful",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
            pathToSave = "";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if(workerOptions == "encrypt")
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
            
        }

        private void btnVerifyfile_Click(object sender, EventArgs e)
        {
            try
            {
                workerOptions = "verifyfile";
                OpenFileDialog op = new();
                op.Filter = "PEM File (*.pem*)|*.pem*";
                op.Title = "Import Public Key File (.pem)";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    if (!backgroundWorker1.IsBusy)
                    {
                        pathToSave = op.FileName;
                        backgroundWorker1.RunWorkerAsync();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch { }
        }
        private void VerifyFileIntegrity(DoWorkEventArgs e)
        {
            string inputFileName = txtInput.Text;
            byte[] DGSignFromFile = new byte[384];
            bool isGotDGSign = false;
            FileStream fsInput = new(inputFileName, FileMode.Open, FileAccess.ReadWrite);
            try
            {
                lblStatus.Text = "Verifying file integrity";
                fsInput.Seek(-384, SeekOrigin.End);
                fsInput.Read(DGSignFromFile, 0, DGSignFromFile.Length);
                string SHAGetFromFile = RsaDecryptWithPublic(Convert.ToBase64String(DGSignFromFile), pathToSave);

                fsInput.SetLength(fsInput.Length - DGSignFromFile.Length);
                isGotDGSign = true;
                fsInput.Position = 0;
                string SHAComputeFromFile = HashFile(fsInput);
                fsInput.Write(DGSignFromFile, 0, DGSignFromFile.Length);
                if (SHAGetFromFile == SHAComputeFromFile)
                {
                    lblStatus.Text = "Verify file successful!";
                    MessageBox.Show("Your file is safe. You can decrypt it!", "Notification");
                }
                else
                {
                    MessageBox.Show("This file has been change (Not have integrity)!", "Warning");
                }
                fsInput.Close();
            }
            catch
            {
                if (isGotDGSign)
                {
                    fsInput.Write(DGSignFromFile, 0, DGSignFromFile.Length);
                }
                fsInput.Close();
                MessageBox.Show("This file has been change (Not have integrity)!", "Warning!");
            }
        }
    }
}
