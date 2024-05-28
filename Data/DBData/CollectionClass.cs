using Sirenix.Serialization;
using System;
using System.Collections.Generic;

namespace Universe.DB
{
    [Serializable]
    public class CollectionInfo
    {
        [OdinSerialize] public ECollection collection { get; set; }
        [OdinSerialize] public int count { get; set; }
        [OdinSerialize] public List<int> bonusCount { get; set; }
        [OdinSerialize] public EMoney bonus { get; set; }
        [OdinSerialize] public List<int> bonusReward { get; set; }
        [OdinSerialize] public int cardPiece { get; set; }
        [OdinSerialize] public int cardPack { get; set; }
        [OdinSerialize] public int percent { get; set; }
        [OdinSerialize] public int adsPiece { get; set; }
    }
}