using Sirenix.Serialization;
using System.Collections.Generic;

namespace Universe.DB
{
    public class RouletteData
    {
        [OdinSerialize] public List<RouletteInfo> Info { get; set; }
        [OdinSerialize] public int free { get; set; }
        [OdinSerialize] public int ad { get; set; }
        [OdinSerialize] public int interval { get; set; }

        public RouletteData()
        {
            LoadData();
        }

        private void LoadData()
        {
            Info = new();
            for (int i = 0; i < m룰렛.CountEntities; i++)
            {
                var newItem = new RouletteInfo
                {
                    index = m룰렛.GetEntity(i).fIndex,
                    money = LocalUtil.StringToEnum<EMoney>(m룰렛.GetEntity(i).f재화),
                    value = m룰렛.GetEntity(i).fValue,
                };
                Info.Add(newItem);
            }
            free = m룰렛.GetEntity(0).f무료횟수;
            ad = m룰렛.GetEntity(0).f광고횟수;
            interval = m룰렛.GetEntity(0).f시간간격;
        }
    }
}