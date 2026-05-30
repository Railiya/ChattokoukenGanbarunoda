using System.Collections.Generic;

namespace CKG.Translator
{
    public readonly record struct SLanguagePair(string Source, string Destination);

    public class LanguageCodeInfo
    {
        private static readonly Dictionary<string, string> LOWER_CODE_MAP = new Dictionary<string, string>
        {
            { "KO",      "ko" },
            { "EN",      "en" },
            { "EN-US",   "en" },
            { "EN-GB",   "en" },
            { "JA",      "ja" },
            { "ZH",      "zh-CN" },
            { "ZH-HANS", "zh-CN" },
            { "ZH-HANT", "zh-TW" },
            { "ES",      "es" },
            { "FR",      "fr" },
            { "DE",      "de" },
            { "RU",      "ru" },
            { "PT",      "pt" },
            { "PT-BR",   "pt" },
            { "PT-PT",   "pt" },
            { "ID",      "id" },
            { "VI",      "vi" },
            { "TH",      "th" },
            { "AR",      "ar" },
            { "HI",      "hi" },
        };

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

        public static SLanguagePair ToLower(SLanguagePair pair)
        {
            bool hasSource = LOWER_CODE_MAP.TryGetValue(pair.Source, out string source);
            bool hasDest = LOWER_CODE_MAP.TryGetValue(pair.Destination, out string dest);

            if (hasSource == false || hasDest == false)
            {
                return new SLanguagePair(null, null);
            }

            return new SLanguagePair(source, dest);
        }
    }
}
