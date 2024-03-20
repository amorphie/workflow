using amorphie.core.Base;
using amorphie.core.Enums;

public static class StringExtension
{

    public static string DeleteUnAllowedCharecters(this string transitionName)
    {
        return System.Text.RegularExpressions.Regex.Replace(transitionName, "[^A-Za-z0-9]", "", System.Text.RegularExpressions.RegexOptions.Compiled);
    }

}
