using Sirenix.Serialization;
using System;
using System.Collections.Generic;

namespace Universe.DB
{
    public class BuffData
    {
        [OdinSerialize] public List<BuffInfo> Info { get; set; }

        public BuffData()
        {
            LoadData();
        }

        private void LoadData()
        {
            Info = new();
            for (int i = 0; i < m버프.CountEntities; i++)
            {
                BuffInfo newItem = new()
                {
                    zodiac = (EZodiac)Enum.Parse(typeof(EZodiac), m버프.GetEntity(i).fkey),
                    buffKey = m버프.GetEntity(i).fBuffKey,
                    addValue = m버프.GetEntity(i).f증가,
                    time = m버프.GetEntity(i).f시간
                };
                Info.Add(newItem);
            }
        }
    }
}