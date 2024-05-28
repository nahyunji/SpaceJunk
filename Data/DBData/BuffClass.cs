using Sirenix.Serialization;
using System;

namespace Universe.DB
{
    [Serializable]
    public class BuffInfo
    {
        [OdinSerialize] public EZodiac zodiac { get; set; }
        [OdinSerialize] public string buffKey { get; set; }
        [OdinSerialize] public int addValue { get; set; }
        [OdinSerialize] public int time { get; set; }
    }
}