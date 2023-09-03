namespace CodingChallenge.Data.Abstractions
{
    public interface ILanguageHelper
    {
        string GetString(string name);

        void ChangeLanguage(string language);

        string GetCurrentLanguage();
    }
}