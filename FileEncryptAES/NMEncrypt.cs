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

        public void AESAlgorithm(String inputFile, String OutputFile, String password, bool isEncrypt)
        {
            try
            {
                if (!isEncrypt)
                {
                    OutputFile = Path.Combine(Path.GetDirectoryName(OutputFile), Path.GetFileNameWithoutExtension(OutputFile) + "_1" + Path.GetExtension(OutputFile));
                }

                FileStream fsInput = new(inputFile, FileMode.Open, FileAccess.ReadWrite);
                FileStream fsCipherText = new(OutputFile, FileMode.Create, FileAccess.ReadWrite);

                fsCipherText.SetLength(0);
                int numberBytesRead = 10485760;//10MB
                byte[] bin = new byte[numberBytesRead];
                long rdlen = 0;
                long totlen = fsInput.Length;
                int len;
                byte[] DGSignFromFile = new byte[384];
                //progressBar1.Minimum = 0;
                //progressBar1.Maximum = 100;

                byte[] salt = new byte[32];

                if(isEncrypt)
                {
                    salt = GenerateRandomSalt();
                }
                else
                {
                    fsInput.Seek(-384, SeekOrigin.End);
                    fsInput.Read(DGSignFromFile, 0, DGSignFromFile.Length);
                    fsInput.SetLength(totlen - DGSignFromFile.Length);
                    totlen = fsInput.Length;
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
                    len = fsInput.Read(bin, 0, numberBytesRead); // Lần lượt đọc 10MB / 1 lần trong file input
                    cryptStream.Write(bin, 0, len);
                    rdlen = rdlen + len;

                    //label1.Text = "Tên tệp xử lý : " + Path.GetFileName(inputFile) + "\t Thành công: " + ((long)(rdlen * 100) / totlen).ToString() + " %";
                    //label1.Refresh();

                    //progressBar1.Value = (int)((rdlen * 100) / totlen);

                }
                cryptStream.FlushFinalBlock();

                if(isEncrypt)
                {
                    //Hash File:
                    lblStatus.Text = "Hashing file...";
                    fsCipherText.Position = 0;
                    string SHAoutput = HashFile(fsCipherText);

                    //Sign to file
                    lblStatus.Text = "Signging file...";
                    string DGSignBase64 = RsaEncryptWithPrivate(SHAoutput, pathToSave);
                    byte[] DGSignByte = Convert.FromBase64String(DGSignBase64);
                    fsCipherText.Write(DGSignByte, 0, DGSignByte.Length);
                    //txtDGsignature.Text = RsaEncryptWithPrivate(txtSHAoutput.Text, "privateKey.pem");
                }
                else
                {
                    fsInput.Write(DGSignFromFile, 0, DGSignFromFile.Length);
                }


                ////if (progressBar1.IsHandleCreated && isEncryptFile)
                ////{
                ////    System.Diagnostics.Process prc = new System.Diagnostics.Process();
                ////    prc.StartInfo.FileName = Path.GetDirectoryName(txtInput.Text);
                ////    prc.Start();
                ////}

                fsInput.Close();
                cryptStream.Close();
                fsCipherText.Close();
            }
            catch
            {
                
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
        private void Encrypt(DoWorkEventArgs e)
        {
            try
            {
                string inputFileName = txtInput.Text;
                string password = txtPassword.Text;
                string outputFileName = inputFileName + ".NMEncrypt";

                lblStatus.Text = "File is being encrypt.";
                AESAlgorithm(inputFileName, outputFileName, password, true);
                MessageBox.Show("Your file has been encrypted at " + outputFileName, "File enccrypt successful");
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
            try
            {
                string inputFileName = txtInput.Text;
                string password = txtPassword.Text;

                int length = inputFileName.Length - 10;
                string outputFileName = inputFileName.Substring(0, length);

                lblStatus.Text = "File is being decrypt.";
                AESAlgorithm(inputFileName, outputFileName, password, false);

                lblStatus.Text = "File decrypt successful";
                MessageBox.Show("Your file has been decrypt at " + outputFileName, "File decrypt successful");
            }
            catch { }
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

            lblStatus.Text = "Public key and Private key has been generated";
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
            FileStream fsInput = new(inputFileName, FileMode.Open, FileAccess.ReadWrite);
            try
            {
                lblStatus.Text = "Verifying file integrity";
                byte[] DGSignFromFile = new byte[384];
                fsInput.Seek(-384, SeekOrigin.End);
                fsInput.Read(DGSignFromFile, 0, DGSignFromFile.Length);
                string SHAGetFromFile = RsaDecryptWithPublic(Convert.ToBase64String(DGSignFromFile), pathToSave);

                fsInput.Position = 0;
                fsInput.SetLength(fsInput.Length - DGSignFromFile.Length);
                string SHAComputeFromFile = HashFile(fsInput);
                fsInput.Write(DGSignFromFile, 0, DGSignFromFile.Length);
                if (SHAGetFromFile == SHAComputeFromFile)
                {
                    lblStatus.Text = "Verify file successful!";
                    MessageBox.Show("Your file is safe. You can decrypt it!", "Notification");
                }
                else
                {
                    MessageBox.Show("This file has been change (Not have integrity)!", "File decrypt successful");
                }
                fsInput.Close();
            }
            catch
            {
                fsInput.Close();
                MessageBox.Show("This file has been change (Not have integrity)!", "Warning!");
            }
        }
    }
}
