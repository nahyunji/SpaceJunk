using System;
using System.Collections.Generic;
using UnityEngine;

namespace Universe.DB
{
    [Serializable]
    public class HelpInfo
    {
        public EHelp ehelp { get; set; }
        public List<HelpLang> helps { get; set; } = new();
    }

    [Serializable]
    public class HelpLang
    {
        public SystemLanguage lang { get; set; }
        public string title { get; set; }
        public string explain { get; set; }
    }
}