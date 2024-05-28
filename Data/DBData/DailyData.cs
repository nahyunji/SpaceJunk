using System.Collections.Generic;
using Sirenix.Serialization;

namespace Universe.DB
{
    public class DailyData
    {
        [OdinSerialize] public List<DailyInfo> Info { get; set; }

        public DailyData()
        {
            LoadData();
        }

        private void LoadData()
        {
            Info = new();
            for (int i = 0; i < m출석.CountEntities; i++)
            {
                var newItem = new DailyInfo
                {
                    day = i + 1,
                    money = LocalUtil.StringToEnum<EMoney>(m출석.GetEntity(i).f재화),
                    reward = m출석.GetEntity(i).f보상
                };
                Info.Add(newItem);
            }
        }
    }
}