using amorphie.workflow.core.Helper;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace amorphie.workflow.test.core;
public class AesHelperTest
{
    [Fact]
    public void Encrypt_Decrypt_Verify()
    {
        var guid = "abcde000-0717-4562-b3fc-2d963f66c052";
        var guidbyte = Encoding.ASCII.GetBytes(guid);
        byte[] bytes = new byte[16];

        Array.Copy(guidbyte, bytes, 16);
        //var rng = new RNGCryptoServiceProvider();
        //rng.GetBytes(bytes);

        var key = Convert.ToBase64String(bytes);
        var value = "Lorem Ipsum Dolor Cart Curt Test1";
        var encryptResult = AesHelper.EncryptString(key, value);
        var decryptResult = AesHelper.DecryptString(key, encryptResult);

        Assert.Equal(decryptResult, value);
    }

    [Fact]
    public void DecryptJson()
    {

        var dataToBeJson = "{\r\n    \"message\": \"encrypted_qDzV1VdCrITk8zrvYKjxPdJTx+jLcBSbsRaTGod1U1VrbpDxGvehIdlYlSwj/uAe_QJ+aTzZw0BWjvPA/L6Ri2w==\",\r\n    \"dec\": \"suc\",\r\n    \"objectsam\": {\r\n        \"key1\": \"val1\",\r\n        \"key2\": \"val2\"\r\n    }\r\n}";
        var additionalData = WfJsonSerializer.Deserialize<JsonObject>(dataToBeJson);


        var guid = "abcde000-0717-4562-b3fc-2d963f66c052";
        var guidbyte = Encoding.ASCII.GetBytes(guid);
        byte[] bytes = new byte[16];

        Array.Copy(guidbyte, bytes, 16);
        //var rng = new RNGCryptoServiceProvider();
        //rng.GetBytes(bytes);

        var key = Convert.ToBase64String(bytes);

        var decryptResult = AesHelper.DecryptJson(key, additionalData);

    }

}
