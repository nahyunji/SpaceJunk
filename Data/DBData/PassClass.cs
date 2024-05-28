using Sirenix.Serialization;
using System;

namespace Universe.DB
{
    [Serializable]
    public class PassInfo
    {
        [OdinSerialize] public int level { get; set; }
        [OdinSerialize] public PassKind goldPass { get; set; }
        [OdinSerialize] public PassKind freePass { get; set; }
        [OdinSerialize] public int levelup { get; set; }
    }

    [Serializable]
    public class PassKind
    {
        [OdinSerialize] public bool profile { get; set; } = false;
        [OdinSerialize] public EMoney money { get; set; } = EMoney.NONE;
        [OdinSerialize] public int value { get; set; }
    }

    [Serializable]
    public class PassQuestInfo
    {
        [OdinSerialize] public EPassQuest passQuest { get; set; }
        [OdinSerialize] public int condition { get; set; }
        [OdinSerialize] public int count { get; set; }
        [OdinSerialize] public int exp { get; set; }
    }

    [Serializable]
    public class PassShopInfo
    {
        [OdinSerialize] public EMoney money;
        [OdinSerialize] public int reward;
        [OdinSerialize] public int passCoin;
    }
}