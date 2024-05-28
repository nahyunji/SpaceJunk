using Sirenix.Serialization;
using System;
using System.Collections.Generic;

namespace Universe.DB
{
    [Serializable]
    public class UpgradeInfo
    {
        [OdinSerialize] public EShipUpgrade shipUpgrade { get; set; }
        [OdinSerialize] public int maxLevel { get; set; }
        [OdinSerialize] public List<UpgradeLevel> levelData { get; set; }
    }

    [Serializable]
    public class UpgradeLevel
    {
        [OdinSerialize] public int level { get; set; }
        [OdinSerialize] public float price { get; set; }
        [OdinSerialize] public float value { get; set; }
    }
}