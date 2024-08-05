using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace amorphie.workflow.core.Helper;
public static class AesHelper
{

    private const string encryptPrefix = "encrypted_";

    public static string EncryptString(string key, string plainText)
    {
        using (Aes aes = Aes.Create())
        {

            aes.Key = Encoding.UTF8.GetBytes(key);

            ICryptoTransform encryptor = aes.CreateEncryptor();

            using MemoryStream memoryStream = new MemoryStream();
            using CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write);
            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
            {
                streamWriter.Write(plainText);
            }

            var array = memoryStream.ToArray();

            return encryptPrefix + Convert.ToBase64String(array) + "_" + Convert.ToBase64String(aes.IV);
        }
    }

    public static string DecryptString(string key, string cipherText)
    {
        if (!cipherText.StartsWith(encryptPrefix))
        {
            return cipherText;
        }
        var cipherParts = cipherText.Split('_');
        if (cipherParts.Length != 3)
        {
            return string.Empty;
        }
        byte[] cipherTextBuffer = Convert.FromBase64String(cipherParts[1]);
        byte[] iv = Convert.FromBase64String(cipherParts[2]);

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using MemoryStream memoryStream = new MemoryStream(cipherTextBuffer);
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using (StreamReader streamReader = new StreamReader(cryptoStream))
                return streamReader.ReadToEnd();
        }
    }
    public static string CreateAesKey(string key)
    {
        var keyByte = Encoding.ASCII.GetBytes(key);
        byte[] bytes = new byte[16];
        Array.Copy(keyByte, bytes, 16);
        return Convert.ToBase64String(bytes);
    }


    public static JsonObject DecryptJson(string key, JsonObject data)
    {
        var dict = data.ToDictionary();
        var keys = dict.Keys;
        foreach (var item in keys)
        {
            if (data[item].GetValueKind() == JsonValueKind.Object)
            {
                var decResult = DecryptDict(key, data[item] as IDictionary<string, JsonNode>);
                data[item] = JsonSerializer.Serialize(decResult);
            }
            else if (data[item].GetValueKind() == JsonValueKind.String)
            {
                data[item] = DecryptString(key, data[item].ToString());
            }
        }

        return data;
    }
    public static IDictionary<string, JsonNode> DecryptDict(string key, IDictionary<string, JsonNode> data)
    {
        var keys = data.Keys.ToList();
        foreach (var item in keys)
        {
            if (data[item].GetValueKind() == JsonValueKind.Object)
            {
                var decResult = DecryptDict(key, data[item] as IDictionary<string, JsonNode>);
                data[item] = JsonSerializer.Serialize(decResult);
            }
            else if (data[item].GetValueKind() == JsonValueKind.String)
            {
                data[item] = DecryptString(key, data[item].ToString());
            }
        }
        return data;
    }
}

