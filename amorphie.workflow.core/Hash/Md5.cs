
using System.Text;
using System.Text.Json;
using amorphie.workflow.core.Dtos.Definition;

namespace amorphie.workflow.core.Token;

public class Md5
{
    public static string Generate(object objectToHash)
    {
        var jResult = JsonSerializer.Serialize(objectToHash);
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] retVal = md5.ComputeHash(Encoding.Unicode.GetBytes(jResult));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
    public static string Generate(WorkflowCreateDto workflowDto)
    {
        var jResult = JsonSerializer.Serialize(workflowDto);
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] retVal = md5.ComputeHash(Encoding.Unicode.GetBytes(jResult));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
    public static bool Check(WorkflowCreateDto workflowDto)
    {
        if (string.IsNullOrEmpty(workflowDto.Hash))
        {
            return false;
        }
        string hash = workflowDto.Hash;
        workflowDto.Hash = null;
        return Generate(workflowDto) == hash;
    }
}