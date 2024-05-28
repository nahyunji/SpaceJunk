using Sirenix.Serialization;
using System.Collections.Generic;

namespace Universe.DB
{
    public class StaffSet
    {
        [OdinSerialize] public EStaffRank grade { get; set; }
        [OdinSerialize] public int index { get; set; } //번호
        [OdinSerialize] public string Key { get; set; } //이름
    }

    public class StaffRecruitRate
    {
        [OdinSerialize] public ERecruit recruit { get; set; } //모집 등급
        [OdinSerialize] public EStaffRank grade { get; set; } //직원 등급
        [OdinSerialize] public float rate { get; set; } //확률
    }

    public class StaffRecruitUpgradeRate
    {
        [OdinSerialize] public int grade { get; set; } //모집승급
        [OdinSerialize] public float rate { get; set; } //승급확률
    }

    public class StaffRecruitPrice
    {
        [OdinSerialize] public ERecruit recruit { get; set; }
        [OdinSerialize] public EMoney money { get; set; }
        [OdinSerialize] public int price { get; set; }
    }

    public class OpenInfo
    {
        [OdinSerialize] public int num { get; set; } //직원슬롯
        [OdinSerialize] public int level { get; set; } //해금레벨
    }

    public class StaffUpgradeData
    {
        [OdinSerialize] public EStaffRank rank { get; set; }
        [OdinSerialize] public int mergeCount { get; set; }
        [OdinSerialize] public int totalStar { get; set; }
        [OdinSerialize] public List<StaffUpgradeSet> infos { get; set; }
    }

    public class StaffUpgradeSet
    {
        [OdinSerialize] public int price { get; set; }
        [OdinSerialize] public int grade { get; set; }
        [OdinSerialize] public int star { get; set; }
        [OdinSerialize] public float addValue { get; set; }
    }

    public class StaffUpgradeInfo

    {
        [OdinSerialize] public float startRate { get; set; }
        [OdinSerialize] public float decreaseRate { get; set; }
        [OdinSerialize] public int maxUpgrade { get; set; }
        [OdinSerialize] public EMoney upgradeMoney { get; set; }
    }
}