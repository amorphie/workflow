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
        var value = "Lorem Ipsum Dolor Cart Curt Test1";
        var encryptResult = AesHelper.EncryptString(guid, value);
        var decryptResult = AesHelper.DecryptString(guid, encryptResult);

        Assert.Equal(decryptResult, value);
    }

    [Fact]
    public void DecryptJson()
    {
        var dataToBeJson = "{\r\n    \"message\": \"encrypted_Uo2s0xd0FHZaYTcJv79cRdBgWt/qLKvOzyqe+8CXfpDEnEN6mv9gX4hxpQ1beT6V_E+C1hnGD4MjMGdzq4D3jTw==\",\r\n    \"dec\": \"suc\",\r\n    \"objectsam\": {\r\n        \"key1\": \"val1\",\r\n        \"key2\": \"val2\"\r\n    }\r\n}";
        var additionalData = WfJsonSerializer.Deserialize<JsonObject>(dataToBeJson);
        var guid = "abcde000-0717-4562-b3fc-2d963f66c052";
        var decryptResult = AesHelper.DecryptJson(guid, additionalData);

    }

}
