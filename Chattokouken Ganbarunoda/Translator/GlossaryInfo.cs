using System.Collections.Generic;

namespace CKG.Translator
{
    public class GlossaryInfo
    {
        public string Name = null;
        public string Id = null;
        public int EntryCount = 0;
        public HashSet<SLanguagePair> SupportedLanguagePairs = null;

        public GlossaryInfo(string name, string id, int entryCount, HashSet<SLanguagePair> supportedLanguagePairs)
        {
            Name = name;
            Id = id;
            EntryCount = entryCount;
            SupportedLanguagePairs = supportedLanguagePairs;
        }
    }
}
