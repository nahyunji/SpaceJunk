using Sirenix.Serialization;
using System.Collections.Generic;

namespace Universe.DB
{
    [ES3Serializable]
    public class TutorialInfo
    {
        [OdinSerialize] public ETutorial tutorial { get; set; }
        [OdinSerialize] public ENPC npc { get; set; }
        [OdinSerialize] public ETutorialQuest quest { get; set; }
        [OdinSerialize] public (EMoney, int) reward { get; set; }
        [OdinSerialize] public int condition { get; set; }
        [OdinSerialize] public List<TutorialMsg> msg { get; set; } = new();
    }

    [ES3Serializable]
    public class TutorialMsg
    {
        [OdinSerialize] public int index { get; set; }
        [OdinSerialize] public string key { get; set; }
    }
}