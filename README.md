# Express.Security

Express Security is an easy to use wrapper for security implementations inside your .NET applications.

The latest version of ExpressSecurity abstracts 2 popular hashing and 2 popular encription mechanism that can be used anywhere on your application. With lot of ease. APIs exposed and clear consistant and designed for quick usage.

Express Security is light weight and easy to use and supports .NET Core platform

![alt text](https://lh3.googleusercontent.com/proxy/B_7eIUlcSWIhijMsKkvsKeB4sv5ZqG8cOGXyWFKIrIAgPlQTL_RyHreEs5bCSthMBUgPzIuifuFL89mIzpZfMhA)

### Package Manager
The library is available free on NuGet
https://www.nuget.org/packages/Twileloop.ExpressSecurity

```nuget
Install-Package Twileloop.ExpressSecurity -Version 1.0.0
```

### Versions
Version Information
| Version | Change log
| ------ | ------
| v1.1 | Supports SHA Hashing, BCript Hashing, AES Encription, RSA Encription

### Repository Contents
This repo maintains 2 projects. The main library and a demo project to implement it

### PreRequesties
No prerequesties to run the demo. Buld it and run it


### Usage
### SHA256 and SHA512 Hashing
Express Encript wrapper currently supports 2 Hashing modules. SHA and BCript based on Blowfish algorithm
```csharp
var password = "sangeeth123";

var hashText1 = Hashing.SHA256(password);
var hashText2 = Hashing.SHA512(password);
```
### BCript Hashing + (With Salt and Work Factor)
BCript is designed over blowfish algorithm. Express Security wraps its complexities and exposes an easy to use API
```csharp
var password = "sangeeth123";
var workFactor = 13;

var salt = BlowFishHashing.GenerateSalt(int.Parse(workFactor));
var hashText = BlowFishHashing.HashString(password, salt);
```
### AES File Encription/Description
AES is an symetric key encription. Which means the file will be encripted using a key and descripted using the same key. AES is suted for locking files. It mostly is used for file encriptions
Express Security wraps AES security with simple API
```csharp
var filePassword = "sangeeth123";
var inputPath = "C:\sample.txt";
var outputPath = "C:\sample.txt.aes";

//AES Encription
AESEncription.AES_Encrypt(inputPath, password);
//AES Description
AESEncription.AES_Decrypt(outputPath, password);
```
### RSA Text Encription/Description
RSA is an asymetric key encription. Which means the text will be encripted using a public key and descripted using a private key. RSA is suted for sending sensitive data. It mostly is used for key/string encriptions
Express Security wraps RSA security with simple API
```csharp
var input = "sangeeth"
var publicKeyPath = "C:\public_key.rsa";
var privateKeyPath = "C:\private_key.rsa";

//Generate Keys
RSAEncription.MakeKey(publicKeyPath, privateKeyPath);

//RSA Encription
var ciphertext = RSAEncription.EncryptString(input, publicKeyPath);
//RSA Description
input = RSAEncription.DecryptString(ciphertext, privateKeyPath);
```
