using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public class SeoUrl
    {
        private SeoUrl() { }
        private static SeoUrl Instance;

        public static SeoUrl GetInstance()
        {
            if (Instance == null)
                Instance = new SeoUrl();

            return Instance;
        }
        public string ConvertUrl(string text)
        {
            string seourl = text.ToLower().Trim();

            if (string.IsNullOrEmpty(seourl))
                return seourl;

            seourl = seourl.Replace('ç', 'c');
            seourl = seourl.Replace('ş', 's');
            seourl = seourl.Replace('ı', 'i');
            seourl = seourl.Replace('ğ', 'g');
            seourl = seourl.Replace('ü', 'u');
            seourl = seourl.Replace('ö', 'o');
            seourl = seourl.Replace("\"", "");
            seourl = seourl.Replace("(", "");
            seourl = seourl.Replace("<b>", "");
            seourl = seourl.Replace("</b>", "");
            seourl = seourl.Replace("<", "");
            seourl = seourl.Replace(">", "");
            seourl = seourl.Replace(")", "");
            seourl = seourl.Replace("[", "");
            seourl = seourl.Replace("]", "");
            seourl = seourl.Replace("!", "");
            seourl = seourl.Replace("+", "");
            seourl = seourl.Replace("/", "");
            seourl = seourl.Replace("%", "");
            seourl = seourl.Replace("^", "");
            seourl = seourl.Replace("*", "");
            seourl = seourl.Replace("&", "");
            seourl = seourl.Replace("~", "");
            seourl = seourl.Replace(",", "");
            seourl = seourl.Replace(".", "");
            seourl = seourl.Replace("'", "-");
            seourl = seourl.Replace(":", "");
            seourl = seourl.Replace("?", "");
            seourl = seourl.Replace("!", "");
            seourl = seourl.Replace("-", "");
            seourl = seourl.Replace("#", "");
            seourl = seourl.Replace("|", "");
            seourl = seourl.Replace("$", "");
            seourl = seourl.Replace("[", "");
            seourl = seourl.Replace("}", "");
            seourl = seourl.Replace("]", "");
            seourl = seourl.Replace("}", "");
            seourl = seourl.Replace("'", "-");
            seourl = seourl.Replace("  ", " ");
            seourl = seourl.Replace(" ", " ");
            seourl = seourl.Replace("`", " ");
            seourl = seourl.Trim().Replace(' ', '-');

            var cont = seourl.Substring(seourl.Length - 1, 1);
            if (cont == "-") seourl = seourl.Substring(seourl.Length - 1);

            string result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(seourl);
            result= result.Replace("İ", "i");
            return result;
        }
        public string ConvertPath(string text)
        {
            string seourl = text.ToLower().Trim();

            seourl = seourl.Replace('ç', 'c');
            seourl = seourl.Replace('ş', 's');
            seourl = seourl.Replace('ı', 'i');
            seourl = seourl.Replace('ğ', 'g');
            seourl = seourl.Replace('ü', 'u');
            seourl = seourl.Replace('ö', 'o');
            seourl = seourl.Replace("(", "");
            seourl = seourl.Replace(")", "");
            seourl = seourl.Replace("<", "");
            seourl = seourl.Replace(">", "");
            seourl = seourl.Replace("[", "");
            seourl = seourl.Replace("]", "");
            seourl = seourl.Replace("!", "");
            seourl = seourl.Replace("+", "");
            seourl = seourl.Replace("%", "");
            seourl = seourl.Replace("^", "");
            seourl = seourl.Replace("*", "");
            seourl = seourl.Replace("&", "");
            seourl = seourl.Replace("~", "");
            seourl = seourl.Replace(",", "");
            seourl = seourl.Replace(".", "");
            seourl = seourl.Replace("'", "");
            seourl = seourl.Replace(":", "");
            seourl = seourl.Replace("?", "");
            seourl = seourl.Replace("!", "");
            seourl = seourl.Replace("-", "");
            seourl = seourl.Replace("#", "");
            seourl = seourl.Replace("|", "");
            seourl = seourl.Replace("$", "");
            seourl = seourl.Replace("[", "");
            seourl = seourl.Replace("}", "");
            seourl = seourl.Replace("]", "");
            seourl = seourl.Replace("}", "");
            seourl = seourl.Replace("'", "-");
            seourl = seourl.Trim().Replace(' ', '-');

            var cont = seourl.Substring(seourl.Length - 1, 1);
            if (cont == "-") seourl = seourl.Substring(seourl.Length - 1);

            string result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(seourl);

            return result.Replace("İ", "i");
        }
        public string ConvertTurkishToEng(string text)
        {
            string result = text.ToLower().Trim();

            result = result.Replace('ç', 'c');
            result = result.Replace('ş', 's');
            result = result.Replace('ı', 'i');
            result = result.Replace('ğ', 'g');
            result = result.Replace('ü', 'u');
            result = result.Replace('ö', 'o');
            result = result.Replace('Ç', 'C');
            result = result.Replace('Ş', 'S');
            result = result.Replace('Ğ', 'G');
            result = result.Replace('Ü', 'U');
            result = result.Replace('Ö', 'O');
            result = result.Replace(' ', '-');
            return result;
        }
     
        public string RemoveHTMLFromText(string text)
        {
            return Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
        }
    }
}
