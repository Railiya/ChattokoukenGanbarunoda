namespace CKG.Translator
{
    public class LanguageCodeInfo
    {
        public static readonly LanguageCodeInfo[] SOURCE_LANGUAGES =
        {
            new LanguageCodeInfo("Arabic", "AR"),
            new LanguageCodeInfo("Bulgarian", "BG"),
            new LanguageCodeInfo("Chinese", "ZH"),
            new LanguageCodeInfo("Czech", "CS"),
            new LanguageCodeInfo("Danish", "DA"),
            new LanguageCodeInfo("Dutch", "NL"),
            new LanguageCodeInfo("English", "EN"),
            new LanguageCodeInfo("Estonian", "ET"),
            new LanguageCodeInfo("Finnish", "FI"),
            new LanguageCodeInfo("French", "FR"),
            new LanguageCodeInfo("German", "DE"),
            new LanguageCodeInfo("Greek", "EL"),
            new LanguageCodeInfo("Hungarian", "HU"),
            new LanguageCodeInfo("Indonesian", "ID"),
            new LanguageCodeInfo("Italian", "IT"),
            new LanguageCodeInfo("Japanese", "JA"),
            new LanguageCodeInfo("Korean", "KO"),
            new LanguageCodeInfo("Latvian", "LV"),
            new LanguageCodeInfo("Lithuanian", "LT"),
            new LanguageCodeInfo("Norwegian", "NB"),
            new LanguageCodeInfo("Polish", "PL"),
            new LanguageCodeInfo("Portuguese", "PT"),
            new LanguageCodeInfo("Romanian", "RO"),
            new LanguageCodeInfo("Russian", "RU"),
            new LanguageCodeInfo("Slovak", "SK"),
            new LanguageCodeInfo("Slovenian", "SL"),
            new LanguageCodeInfo("Spanish", "ES"),
            new LanguageCodeInfo("Swedish", "SV"),
            new LanguageCodeInfo("Turkish", "TR"),
            new LanguageCodeInfo("Ukrainian", "UK"),
        };

        public static readonly LanguageCodeInfo[] TARGET_LANGUAGES =
        {
            new LanguageCodeInfo("Arabic", "AR"),
            new LanguageCodeInfo("Bulgarian", "BG"),
            new LanguageCodeInfo("Chinese (Simplified)", "ZH-HANS"),
            new LanguageCodeInfo("Chinese (Traditional)", "ZH-HANT"),
            new LanguageCodeInfo("Czech", "CS"),
            new LanguageCodeInfo("Danish", "DA"),
            new LanguageCodeInfo("Dutch", "NL"),
            new LanguageCodeInfo("English (British)", "EN-GB"),
            new LanguageCodeInfo("English (American)", "EN-US"),
            new LanguageCodeInfo("Estonian", "ET"),
            new LanguageCodeInfo("Finnish", "FI"),
            new LanguageCodeInfo("French", "FR"),
            new LanguageCodeInfo("German", "DE"),
            new LanguageCodeInfo("Greek", "EL"),
            new LanguageCodeInfo("Hungarian", "HU"),
            new LanguageCodeInfo("Indonesian", "ID"),
            new LanguageCodeInfo("Italian", "IT"),
            new LanguageCodeInfo("Japanese", "JA"),
            new LanguageCodeInfo("Korean", "KO"),
            new LanguageCodeInfo("Latvian", "LV"),
            new LanguageCodeInfo("Lithuanian", "LT"),
            new LanguageCodeInfo("Norwegian", "NB"),
            new LanguageCodeInfo("Polish", "PL"),
            new LanguageCodeInfo("Portuguese (Brazilian)", "PT-BR"),
            new LanguageCodeInfo("Portuguese (Portugal)", "PT-PT"),
            new LanguageCodeInfo("Romanian", "RO"),
            new LanguageCodeInfo("Russian", "RU"),
            new LanguageCodeInfo("Slovak", "SK"),
            new LanguageCodeInfo("Slovenian", "SL"),
            new LanguageCodeInfo("Spanish", "ES"),
            new LanguageCodeInfo("Swedish", "SV"),
            new LanguageCodeInfo("Turkish", "TR"),
            new LanguageCodeInfo("Ukrainian", "UK"),
        };

        public string Name;
        public string Code;

        public LanguageCodeInfo(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}
