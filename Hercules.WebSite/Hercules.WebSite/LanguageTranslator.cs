using System;

using Google.Cloud.Translation.V2;


/*
 1. login to wordpress
 2. copy html and load to dcom   need 3rd part package
 3. translate   need google package
 4. save to a fr version     
     
     */
namespace Hercules.WebSite
{
    public class LanguageTranslator
    {
        public static string translateToFrench(string text)
        {
            TranslationClient client = TranslationClient.Create();

            var response = client.TranslateText(text, "fr");

            return response.TranslatedText;
        }


        public static string translateHtmlToFrench(string html)
        {
            TranslationClient client = TranslationClient.Create();

            var response = client.TranslateHtml(html, "fr");

            return response.TranslatedText;
        }
    }
}
