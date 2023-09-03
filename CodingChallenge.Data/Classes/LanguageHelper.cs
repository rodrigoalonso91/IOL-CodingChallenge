using CodingChallenge.Data.Abstractions;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace CodingChallenge.Data.Classes
{
    public class LanguageHelper : ILanguageHelper
    {
        private static ResourceManager resourceManager;

        public LanguageHelper()
        {
            resourceManager = new ResourceManager("CodingChallenge.Data.Languages.strings", Assembly.GetExecutingAssembly());
        }

        public void ChangeLanguage(string language)
        {
            if (string.IsNullOrWhiteSpace(language)) return;

            var cultureInfo = new CultureInfo(language);

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
        }

        public string GetCurrentLanguage()
        {
            return CultureInfo.CurrentCulture.DisplayName;
        }

        public string GetString(string name)
        {
            return resourceManager.GetString(name) ?? string.Empty;
        }
    }
}