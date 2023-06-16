using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Agilite.Services.Managers;

public static class AuthManager
{
    public static byte[] EncryptData(string data, string key)
    {
        var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.IV = new byte[16];

        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        var memoryStream = new MemoryStream();
        var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        using (var streamWriter = new StreamWriter(cryptoStream))
        {
            streamWriter.Write(data);
        }

        return memoryStream.ToArray();
    }

    public static string DecryptData(byte[] data, string key)
    {
        var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.IV = new byte[16];

        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        var memoryStream = new MemoryStream(data);
        var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        var streamReader = new StreamReader(cryptoStream);

        return streamReader.ReadToEnd();
    }

    public static string HashPasswordSaltCombination(string password, string salt)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var saltBytes = Encoding.UTF8.GetBytes(salt);
        var combinedBytes = new byte[passwordBytes.Length + saltBytes.Length];
        Buffer.BlockCopy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
        Buffer.BlockCopy(saltBytes, 0, combinedBytes, passwordBytes.Length, saltBytes.Length);

        using var sha512 = SHA512.Create();
        var hashBytes = sha512.ComputeHash(combinedBytes);
        return Convert.ToBase64String(hashBytes);
    }
}