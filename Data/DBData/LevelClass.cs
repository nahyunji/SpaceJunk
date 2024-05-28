using Sirenix.Serialization;
using System;

namespace Universe.DB
{
    [Serializable]
    public class LevelInfo
    {
        [OdinSerialize] public int level;
        [OdinSerialize] public int needExp;
        [OdinSerialize] public int addExp;
    }

    [Serializable]
    public class ExpInfo
    {
        [OdinSerialize] public EGainExp expType;
        [OdinSerialize] public int exp;
    }
}