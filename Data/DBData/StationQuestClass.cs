using Sirenix.Serialization;
using System;

namespace Universe.DB
{
    [Serializable]
    public class StationQuestInfo
    {
        [OdinSerialize] public EStationQuest quest { get; set; }
        [OdinSerialize] public string contentKey { get; set; }
        [OdinSerialize] public int min { get; set; }
        [OdinSerialize] public int max { get; set; }
    }

    [Serializable]
    public class StationQuestReward
    {
        [OdinSerialize] public EMoney payMoney { get; set; }
        [OdinSerialize] public int payCount { get; set; }
    }
}