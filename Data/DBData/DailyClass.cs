using Sirenix.Serialization;
using System;

namespace Universe.DB
{
    [Serializable]
    public class DailyInfo
    {
        [OdinSerialize] public int day { get; set; }
        [OdinSerialize] public EMoney money { get; set; }
        [OdinSerialize] public int reward { get; set; }
    }
}