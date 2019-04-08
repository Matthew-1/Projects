using System;
using System.Collections.Generic;
using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {

        if (shiftKey == 0 || shiftKey == 26)
            return text;

        char[] cipheredChars = CipherEachCharacterFromText(text, shiftKey);
        
        string cipheredText = new string(cipheredChars);

        return cipheredText;

    }

    public static string RotatePremium(string text)
    {
        var time = DateTime.Now;
        int shiftKey = time.Hour;
        string basicCipheredText = Rotate(text, shiftKey);
        string premiumCipheredText = CipherEachCharPremiumWay(basicCipheredText, shiftKey);

        return premiumCipheredText;
    }

    private static string CipherEachCharPremiumWay(string basicCipheredText, int shiftKey)
    {
        List<int> premiumNumbers = new List<int>();
        List<char> premiumChars = new List<char>();
        List<char> premiumAddons = new List<char>();

        var random = new Random();

        for (int i = 0; i < 15; i++)
        {
            int newRandom = random.Next(33, 127);
            char newChar = (char)newRandom;
            premiumChars.Add(newChar);
        }

        string premiumText = String.Join("",premiumChars.Select(chars => chars.ToString()).ToArray());

        char[] premiumCipheredChars = CipherEachCharacterFromText(premiumText, shiftKey);


        if (shiftKey < 10)
        {
            premiumAddons.Add('0');
            premiumAddons.Add($"{shiftKey}".ToCharArray()[0]);
        }
        else
        {
            premiumAddons.Add($"{shiftKey}".ToCharArray()[0]);
            premiumAddons.Add($"{shiftKey}".ToCharArray()[1]);
        }

        char[] premiumAddon = new char[2] { (char)(premiumAddons[0] + 2), (char)(premiumAddons[1] + 2) };

        char[] premiumCipheredCharsWithAddon = premiumCipheredChars.Concat(premiumAddon).ToArray();

        string premiumCipheredText = String.Join("", basicCipheredText, new string(premiumCipheredCharsWithAddon));

        return premiumCipheredText;
    }

    private static char[] CipherEachCharacterFromText(string text, int shiftKey)
    {
        var cipheredChars = new char[text.Length];

        for (int i = 0; i < text.Length; i++)
        {
            bool characterNotToCypher = SearchForCharsnotToCypher(text[i]);
            
            if(characterNotToCypher || Char.IsNumber(text[i]))
            {
                cipheredChars[i] = (char)(text[i]);

                continue;
            }

            if(text[i] + shiftKey >122)
            {
                cipheredChars[i] = (char)(text[i] + shiftKey -(123-97));
                continue;
            }

            if (text[i] <= 90 && text[i] + shiftKey > 90)
            {
                cipheredChars[i] = (char)(text[i] + shiftKey - (91 - 65));
                continue;
            }


            cipheredChars[i] = (char)(text[i] + shiftKey);
        }

        return cipheredChars;
    }

    public static string UnRotatePremium(string premiumCipheredText)
    {
        int shiftKey = GetShiftKey(premiumCipheredText);
        string actualText = ExtractText(premiumCipheredText);
        char[] unCipheredChars = UnCipherEachCharacterFromText(actualText, shiftKey);

        string originalText = new string(unCipheredChars);

        return originalText;

    }

    private static char[] UnCipherEachCharacterFromText(string actualText, int shiftKey)
    {
        var cipheredChars = new char[actualText.Length];

        for (int i = 0; i < actualText.Length; i++)
        {
            bool characterNotToCypher = SearchForCharsnotToCypher(actualText[i]);

            if (characterNotToCypher || Char.IsNumber(actualText[i]))
            {
                cipheredChars[i] = (char)(actualText[i]);

                continue;
            }

            if (actualText[i] <= 90 && actualText[i] - shiftKey < 65)
            {
                cipheredChars[i] = (char)(actualText[i] - shiftKey + (91 - 65));
                continue;
            }

            if (actualText[i] >=97 && actualText[i] - shiftKey < 97  )
            {
                cipheredChars[i] = (char)(actualText[i] - shiftKey + (123 - 97));
                continue;
            }

            cipheredChars[i] = (char)(actualText[i] - shiftKey);
        }

        return cipheredChars;
    }

    private static string ExtractText(string premiumCipheredText)
    {
        var cipheredChars = new List<char>();

        for (int i = 0; i < premiumCipheredText.Length-17; i++)
        {
            cipheredChars.Add(premiumCipheredText[i]);
        }

        string cipheredText = String.Join("", cipheredChars.Select(chars => chars.ToString()).ToArray());

        return cipheredText;
    }

    private static int GetShiftKey(string premiumCipheredText)
    {
        char firstDigit = (char)(premiumCipheredText[premiumCipheredText.Length - 2]-2);
        char secondDigit = (char)(premiumCipheredText[premiumCipheredText.Length - 1]-2);
        string fullKey = firstDigit.ToString() + secondDigit.ToString();  
        int shiftKey = int.Parse(fullKey);

        return shiftKey;

    }

    private static bool SearchForCharsnotToCypher(char characterFromMainText)
    {
        char[] charactersNotToCypher = new char[] { ' ', '!', '.', ',','\'','/',':'};

        foreach (var notCypherChar in charactersNotToCypher)
        {
            if (characterFromMainText == notCypherChar)
            {
                return true;
            }
        }

        return false;
    }
}