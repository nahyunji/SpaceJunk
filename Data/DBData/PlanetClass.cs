using System;
using System.Collections.Generic;
using Sirenix.Serialization;

namespace Universe.DB
{
    [Serializable]
    public class PlanetSet
    {
        [OdinSerialize] public int index { get; set; }
        [OdinSerialize] public int bg { get; set; }
        [OdinSerialize] public EPlanet planet { get; set; }
        [OdinSerialize] public string openCondition { get; set; }
        [OdinSerialize] public int openLevel { get; set; }
    }

    [Serializable]
    public class PlanetInfo
    {
        [OdinSerialize] public EPlanet planet { get; set; }
        [OdinSerialize] public int bgNum { get; set; } //배경
        [OdinSerialize] public List<ResourceInfo> list { get; set; } //행성 자원
    }

    [Serializable]
    public class ResourceInfo
    {
        [OdinSerialize] public int num { get; set; } // 번호
        [OdinSerialize] public List<ETrash> trash { get; set; } // 쓰레기
        [OdinSerialize] public float gold_mult { get; set; } //골드_곱
        [OdinSerialize] public double oepnGold { get; set; } //해금골드
    }

    [Serializable]
    public class ResourceLevel
    {
        [OdinSerialize] public int level { get; set; } //레벨
        [OdinSerialize] public float speed { get; set; } //우주선 속도
        [OdinSerialize] public double amountTransport { get; set; } //적재량
        [OdinSerialize] public double collectionRate { get; set; } //수집속도
        [OdinSerialize] public double price { get; set; } //레벨업 골드
    }

    [Serializable]
    public class TrashInfo
    {
        [OdinSerialize] public int index { get; set; } //번호
        [OdinSerialize] public ETrash trash { get; set; }
        [OdinSerialize] public int count { get; set; } //개수
        [OdinSerialize] public double trashPrice { get; set; } //판매
        [OdinSerialize] public double recyclePrice { get; set; } //판매
        [OdinSerialize] public double recycleCount { get; set; } //재활용 개수
        [OdinSerialize] public float recycleTime { get; set; } //재활용시간
    }

    [Serializable]
    public class MergeInfo
    {
        [OdinSerialize] public int index { get; set; } //번호
        [OdinSerialize] public EMergeGrade grade { get; set; }
        [OdinSerialize] public EMerge merge { get; set; } //key
        [OdinSerialize] public double price { get; set; } // 판매

        [OdinSerialize] public List<MergeRecycleInfo> mergeList { get; set; } //합성 리스트
        [OdinSerialize] public float recycleTime { get; set; } //재활용시간
    }

    [Serializable]
    public class MergeRecycleInfo
    {
        [OdinSerialize] public ETrash trash;
        [OdinSerialize] public int recycleCount;
    }

    [Serializable]
    public class RecycleSlotInfo
    {
        [OdinSerialize] public List<RecycleSlotPrice> recycle { get; set; }
        [OdinSerialize] public List<RecycleSlotPrice> merge { get; set; }
    }

    [Serializable]
    public class RecycleSlotPrice
    {
        [OdinSerialize] public int slot { get; set; }
        [OdinSerialize] public double openPrice { get; set; }
    }

    [Serializable]
    public class RewardInfo
    {
        [OdinSerialize] public int level { get; set; } //레벨
        [OdinSerialize] public EMoney money { get; set; }
        [OdinSerialize] public int count { get; set; }//개수
    }

    [Serializable]
    public class RewardGrp
    {
        [OdinSerialize] public int trashNum { get; set; } //자원번호
        [OdinSerialize] public List<RewardInfo> infos { get; set; }
    }
}