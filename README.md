# Express.Encription

Express.Encription wraps multi layer encription and hash password matching to be used inside an authentication system

### Versions

Released verisons are listed below

| Version | Change log |
| ------ | ------ |
| 1.1 | FFin.Ecnription 1.1, Microsoft.AES 1.1 |



### Usage
Encript + Hash A Password
```csharp
var rsakey = _configuration.GetSection("Encription:RSAKey");
var password = "groveave123";
ver ex = new ExpressEncription(EncriptionMethord.RSA, HashingMethord.SHA123);
var encriptedPassword = ex.Encript(password);
var hashedPassword = ex.HashPassword(encriptedPassword);
Console.WriteLine($"Password ready to be saved to DB - {hashedPassword}");
```
Match A Hashed Password
```csharp
var rsakey = _configuration.GetSection("Encription:RSAKey");
var hashedPassword = "e0d123e5f316bef78bfdf5a008837577";
ver ex = new ExpressEncription(EncriptionMethord.RSA, HashingMethord.SHA123);
var isMatch = ex.PasswordMatch(password, hashedPassword);
if(isMatch) {
    Console.WriteLine("Password matched");
}
else {
    Console.WriteLine("Password didn't matched");
}
```
