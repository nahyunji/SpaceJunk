using Sirenix.Serialization;
using System;

namespace Universe.DB
{
    [Serializable]
    public class QuestInfo
    {
        [OdinSerialize] public EQuest quest { get; set; }
        [OdinSerialize] public int count { get; set; }
        [OdinSerialize] public EMoney money { get; set; }
        [OdinSerialize] public int reward { get; set; }
    }

    [Serializable]
    public class RepeatQuestInfo
    {
        [OdinSerialize] public ERepeatQuest quest { get; set; }
        [OdinSerialize] public int count { get; set; }
        [OdinSerialize] public int add { get; set; }
        [OdinSerialize] public double max { get; set; }
        [OdinSerialize] public (EMoney, int) reward { get; set; }
    }
}