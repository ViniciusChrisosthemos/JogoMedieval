
using System;
using System.Text.RegularExpressions;
using UnityEngine;

public static class TextParser
{
    public static string ParseText(string input, string pattern, Func<string, string> formatter)
    {
        return Regex.Replace(input, pattern, match =>
        {
            string data = match.Value; // conteúdo dentro de < >
            return formatter(data);
        });
    }
}
