using Sirenix.Serialization;
using System.Collections.Generic;

namespace Universe.DB
{
    public class StationRecruitData
    {
        [OdinSerialize] public List<StaffRecruitRate> RecruitRate { get; set; } //모집 확률
        [OdinSerialize] public List<StaffRecruitUpgradeRate> RecruitUpgradeRate { get; set; } //모집 승급 확률

        [OdinSerialize] public EMoney recruitMoney;
        [OdinSerialize] public int pay;
        [OdinSerialize] public int dailyCount;

        public StationRecruitData()
        {
            LoadData();
        }

        private void LoadData()
        {
            RecruitRate = new();
            RecruitUpgradeRate = new();
            recruitMoney = LocalUtil.StringToEnum<EMoney>(m구인구직.GetEntity(0).f채용재화);
            pay = m구인구직.GetEntity(0).f재화소모;
            dailyCount = m구인구직.GetEntity(0).f일일개수;

            for (int i = 0; i < 3; i++)
            {
                StaffRecruitRate newRate = new()
                {
                    grade = LocalUtil.StringToEnum<EStaffRank>(m구인구직.GetEntity(i).f직원등급),
                    rate = m구인구직.GetEntity(i).f확률,
                };
                RecruitRate.Add(newRate);
            }

            for (int i = 0; i < 3; i++)
            {
                StaffRecruitUpgradeRate gradeRate = new()
                {
                    grade = m구인구직.GetEntity(i).f모집승급,
                    rate = m구인구직.GetEntity(i).f승급확률
                };
                RecruitUpgradeRate.Add(gradeRate);
            }
        }
    }
}