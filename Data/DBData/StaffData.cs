using Sirenix.Serialization;
using System;
using System.Collections.Generic;

namespace Universe.DB
{
    public class StaffData
    {
        [OdinSerialize] public List<StaffSet> Info { get; set; }
        [OdinSerialize] public List<OpenInfo> OpenInfo { get; set; }
        [OdinSerialize] public List<StaffUpgradeData> UpgradeData { get; set; } //승급시 정보
        [OdinSerialize] public StaffUpgradeInfo UpgradeInfo { get; set; }
        [OdinSerialize] public List<StaffRecruitRate> RecruitRate { get; set; } //모집 확률
        [OdinSerialize] public List<StaffRecruitUpgradeRate> RecruitUpgradeRate { get; set; } //모집 승급 확률
        [OdinSerialize] public List<StaffRecruitPrice> RecruitPrice { get; set; }

        [OdinSerialize] public int SlotCount { get; set; }
        [OdinSerialize] public int maxSlotCount { get; set; }

        public StaffData()
        {
            LoadData();
        }

        private void LoadData()
        {
            Info = new();
            SetInfo();

            RecruitRate = new();
            SetRate();

            RecruitUpgradeRate = new();
            SetGradeRate();

            OpenInfo = new();
            SetOpen();

            UpgradeData = new();
            SetUpgrade();

            UpgradeInfo = new()
            {
                startRate = m직원승급.GetEntity(0).f승급성공확률,
                decreaseRate = m직원승급.GetEntity(0).f확률감소,
                maxUpgrade = m직원승급.GetEntity(0).f최대승급,
                upgradeMoney = LocalUtil.StringToEnum<EMoney>(m직원승급.GetEntity(0).f레벨업재화),
            };

            SlotCount = m직원.GetEntity(0).f시작슬롯개수;
            maxSlotCount = m직원.GetEntity(0).f최대슬롯개수;

            RecruitPrice = new();
            SetRecruitPirce();
        }

        private void SetInfo()
        {
            for (int i = 0; i < m직원.CountEntities; i++)
            {
                StaffSet set = new()
                {
                    index = m직원.GetEntity(i).f번호,
                    Key = m직원.GetEntity(i).fKey,
                    grade = LocalUtil.StringToEnum<EStaffRank>(m직원.GetEntity(i).f등급),
                };
                Info.Add(set);
            }
        }

        private void SetRate()
        {
            for (int i = 0; i < 4; i++)
            {
                StaffRecruitRate newRate = new()
                {
                    recruit = LocalUtil.StringToEnum<ERecruit>(m직원모집.GetEntity(i).f모집등급),
                    grade = LocalUtil.StringToEnum<EStaffRank>(m직원모집.GetEntity(i).f직원등급),
                    rate = m직원모집.GetEntity(i).f확률
                };
                RecruitRate.Add(newRate);
            }
        }

        private void SetGradeRate()
        {
            for (int i = 0; i < 3; i++)
            {
                StaffRecruitUpgradeRate gradeRate = new()
                {
                    grade = m직원모집.GetEntity(i).f모집승급,
                    rate = m직원모집.GetEntity(i).f승급확률
                };
                RecruitUpgradeRate.Add(gradeRate);
            }
        }

        private void SetOpen()
        {
            for (int i = 0; i < 3; i++)
            {
                OpenInfo open = new()
                {
                    num = m직원.GetEntity(i).f직원슬롯,
                    level = m직원.GetEntity(i).f해금레벨
                };
                OpenInfo.Add(open);
            }
        }

        private void SetUpgrade()
        {
            for (int i = 0; i < 3; i++)
            {
                var index = m직원승급.FindEntity(x => x.f승급_등급 != null && x.f승급_등급.Contains(((EStaffRank)i).ToString())).Index;

                StaffUpgradeData upgrade = new()
                {
                    rank = (EStaffRank)Enum.Parse(typeof(EStaffRank), m직원승급.GetEntity(index).f승급_등급),
                    mergeCount = m직원승급.GetEntity(index).f합성개수,
                    totalStar = m직원승급.GetEntity(index).f별개수,
                    infos = new List<StaffUpgradeSet>()
                };

                var gradeCount = ((upgrade.totalStar + 1) * 3);
                for (int j = 0; j < gradeCount; j++)
                {
                    StaffUpgradeSet newInfo = new()
                    {
                        grade = m직원승급.GetEntity(index + j).f승급,
                        star = m직원승급.GetEntity(index + j).f별,
                        addValue = m직원승급.GetEntity(index + j).f효과증가,
                        price = m직원승급.GetEntity(index + j).f레벨업비용,
                    };
                    upgrade.infos.Add(newInfo);
                }

                UpgradeData.Add(upgrade);
            }
        }

        private void SetRecruitPirce()
        {
            for (int i = 0; i < 2; i++)
            {
                StaffRecruitPrice price = new()
                {
                    recruit = (ERecruit)Enum.Parse(typeof(ERecruit), m직원모집.GetEntity(i).f모집구분),
                    money = (EMoney)Enum.Parse(typeof(EMoney), m직원모집.GetEntity(i).f모집재화),
                    price = m직원모집.GetEntity(i).f재화소모
                };
                RecruitPrice.Add(price);
            }
        }
    }
}