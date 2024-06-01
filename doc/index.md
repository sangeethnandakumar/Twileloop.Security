---
layout: default
---

## About
An all in one library that centralizes multiple algorithms for encoding, encrypting and hashing in one place to be used anywhere in your code.

> **Note**
> ***Starting from version v2.0+ and above, This is the official documentation. For older versions, Refer old documentation <a href="https://github.com/sangeethnandakumar/Twileloop.Security/blob/master/README_Old.md">
    here
  </a>***

## License
> Twileloop.Security is licensed under the MIT License. See the LICENSE file for more details.

#### This library is absolutely free. If it gives you a smile, A small coffee would be a great way to support my work. Thank you for considering it!
[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/sangeethnanda)


## 1. Install Package
```bash
dotnet add package Twileloop.Security
```

### Supported Algorithms

| Encoding Algorithms
| ---      
| ✅ ASCII
| ✅ UTF-8
| ✅ Base64
| ✅ Hex
| ✅ Binary

| Encryption Algorithms 
| ---      
| ✅ AES
| ✅ RSA

| Hashing Algorithms
| ---      
| ✅ MD5
| ✅ SHA1
| ✅ SHA256
| ✅ SHA3
| ✅ Blake2
| ✅ BCrypt
| ✅ Argon2


## 2. Encode/Decode Text
Encode or decode text in multiple supported formats

```csharp
    //Encoding Algorithms
    //-------------------------------

    //1. ASCII
    var data1 = ASCIIEncoder.Encode("English");
    var data2 = ASCIIEncoder.Decode(data1);
    
    //2. UTF-8
    var data3 = UTF8Encoder.Encode("മലയാളം");
    var data4 = UTF8Encoder.Decode(data3);
    
    //3. Base64
    var data5 = Base64Encoder.Encode("मैं तुमसे प्यार करता हूँ");
    var data6 = Base64Encoder.Decode(data5);
    
    //4. Hex
    var data7 = HexEncoder.Encode("أنا ذاهب");
    var data8 = HexEncoder.Decode(data7);
    
    //5. Binary
    var data9 = BinaryEncoder.Encode("நான் உன்னை அன்புக்குரியேன்");
    var data10 = BinaryEncoder.Decode(data9);
```

## 3. Encrypt/Decrypt Text or File
Encrypt or decrypt text or files in multiple supported formats.

> Encrypt as Bytes, String, or even File

#### AES
```csharp
  var text = "Sangeeth Nandakumar";
  var textAsBytes = System.Text.Encoding.UTF8.GetBytes(text);

   //1 - AES (Advanced Encryption Standard)
   //--------------------------------------
   //Raw Bytes
   var aesEncryptedBytes = AESAlgorithm.EncryptBytes(textAsBytes, key: "1234", iv: "1234567890123456");
   var aesDecryptedBytes = AESAlgorithm.DecryptBytes(aesEncryptedBytes, key: "1234", iv: "1234567890123456");
   //Text
   var aesEncryptedString = AESAlgorithm.EncryptText("Twileloop", key: "1234", iv: "1234567890123456");
   var aesDecryptedString = AESAlgorithm.DecryptText(aesEncryptedString, key: "1234", iv: "1234567890123456");
   //File
   AESAlgorithm.EncryptFile(@"D:\data.txt", @"D:\data_aes_encrypted.aes", key: "1234", iv: "1234567890123456");
   AESAlgorithm.DecryptFile(@"D:\data_aes_encrypted.aes", @"D:\data_aes_decrypted.txt", key: "1234", iv: "1234567890123456");
```

#### RSA
```csharp
  var text = "Sangeeth Nandakumar";
  var textAsBytes = System.Text.Encoding.UTF8.GetBytes(text);

  //2 - RSA (Rivest-Shamir-Adleman)
  //--------------------------------------
  RSAAlgorithm.MakeRSAKeyPairs(out RSAParameters publicKey, out RSAParameters privateKey);
  //Raw Bytes
  var rsaEncryptedBytes = RSAAlgorithm.EncryptBytes(textAsBytes, publicKey);
  var rsaDecryptedBytes = RSAAlgorithm.DecryptBytes(rsaEncryptedBytes, privateKey);
  //Text
  var rsaEncryptedText = RSAAlgorithm.EncryptText("Twileloop", publicKey);
  var rsaDecryptedText = RSAAlgorithm.DecryptText(rsaEncryptedText, privateKey);
  //File
  RSAAlgorithm.EncryptFile(@"D:\data.txt", @"D:\data_rsa_encrypted.rsa", publicKey);
  RSAAlgorithm.DecryptFile(@"D:\data_rsa_encrypted.rsa", @"D:\data_rsa_decrypted.txt", privateKey);
```

## 4. Hash Text
Hash text in multiple supported formats

```csharp
    // Hashing Algorithms
    //-------------------------------

    //1 - MD5
    var hash1 = MD5Algorithm.Hash("Sangeeth Nandakumar");
    
    //2 - SHA1
    var hash2 = SHAAlgorithm.HashUsingSHA1("Sangeeth Nandakumar");
    
    //3 - SHA256 
    var hash3 = SHAAlgorithm.HashUsingSHA256("Sangeeth Nandakumar");
    
    //4 - SHA3 
    var hash4 = SHAAlgorithm.HashUsingSHA3("Sangeeth Nandakumar");
    
    //5 - Blake2 
    var hash5 = Blake2DigestAlgorithm.Hash("Sangeeth Nandakumar");
    
    //6 - BCrypt 
    var hash7 = BCryptAlgorithm.Hash("Sangeeth Nandakumar", workFactor: 11);
    
    //7 - Argon2
    var hash8 = Argon2Algorithm.Hash("Sangeeth Nandakumar", byteSize: 32, iterations: 1, memorySizeKB: 4096, degreeOfParallelism: 1);
```
