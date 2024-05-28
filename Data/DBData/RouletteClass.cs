using Sirenix.Serialization;
using System;

namespace Universe.DB
{
    [Serializable]
    public class RouletteInfo
    {
        [OdinSerialize] public int index { get; set; }
        [OdinSerialize] public EMoney money { get; set; }
        [OdinSerialize] public int value { get; set; }
    }
}