using Sirenix.Serialization;
using System.Collections.Generic;

namespace Universe.DB
{
    public class StaffSet
    {
        [OdinSerialize] public EStaffRank grade { get; set; }
        [OdinSerialize] public int index { get; set; } //��ȣ
        [OdinSerialize] public string Key { get; set; } //�̸�
    }

    public class StaffRecruitRate
    {
        [OdinSerialize] public ERecruit recruit { get; set; } //���� ���
        [OdinSerialize] public EStaffRank grade { get; set; } //���� ���
        [OdinSerialize] public float rate { get; set; } //Ȯ��
    }

    public class StaffRecruitUpgradeRate
    {
        [OdinSerialize] public int grade { get; set; } //�����±�
        [OdinSerialize] public float rate { get; set; } //�±�Ȯ��
    }

    public class StaffRecruitPrice
    {
        [OdinSerialize] public ERecruit recruit { get; set; }
        [OdinSerialize] public EMoney money { get; set; }
        [OdinSerialize] public int price { get; set; }
    }

    public class OpenInfo
    {
        [OdinSerialize] public int num { get; set; } //��������
        [OdinSerialize] public int level { get; set; } //�رݷ���
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