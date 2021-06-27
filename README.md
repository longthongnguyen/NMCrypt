# NMCrypt
* File and Folder Encrypt / Decrypt / Integrity Check
* .NET 5.0 required

# Usage
### 1. Generate Key pair (RSA private and public key)
Generate your own RSA key:

Tools -> Generate RSA Key (.pem)
### 2. Encrypt File/Folder
* Step 1: Import private key (.pem). File -> Import Private Key (.pem).
* Step 2: Enter the password to encrypt File/Folder (Optional).

Now you can drag and drop the File/Folder to the Lock button to Encrypt or you can do Step 3 and Step 4.
* Step 3: Enter input path.
* Step 4: Click Lock button to start Encrypt.
### 3. Verify integrity
* Step 1: Import public key (.pem). Click Import Public Key.

Now you can drag and drop the File to the Check button to Check integrity or you can do Step 2 and Step 3.
* Step 2: Enter input path.
* Step 3: Click Check button to start check integrity.
### 4. Decrypt File/Folder
* Step 1: Enter the password to decrypt File/Folder (Optional).

Now you can drag and drop the File to the Unlock button to Decrypt or you can do Step 2 and Step 3.
* Step 2: Enter input path.
* Step 3: Click Unlock button to start Decrypt.

### 5. Change settings (Additional)
Tools -> Options

Allow Deleting File/Folder after Encrypt/Decrypt. Default: Not delete.

Allow Changing AES Mode / Key Size. Default: CBC Mode, 256 bits Key.

# Implementation
* AES algorithm by Rijndael Class: https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rijndael
* Hash Algorithm SHA512 by SHA512 Class: https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.sha512
* RSA algorithm by Legion of the Bouncy Castle: https://www.bouncycastle.org/csharp/

# Single File Application
You can use the application as a single file.

Download link: https://drive.google.com/file/d/1rodeZRyWmKgggNhgAo-n5YkwnjhSDhf7/view?usp=sharing

# Contact
e-mail: longthongnguyen@gmail.com