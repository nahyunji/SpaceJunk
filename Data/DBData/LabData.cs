using Sirenix.Serialization;
using System;
using System.Collections.Generic;

namespace Universe.DB
{
    public class LabData
    {
        [OdinSerialize] public List<LabInfo> Info { get; set; } = new();
        [OdinSerialize] public List<LabLevel> LevelInfo { get; set; } = new();

        public LabData()
        {
            LoadData();
        }

        private void LoadData()
        {
            for (int i = 0; i < m연구실.CountEntities; i++)
            {
                LabInfo info = new()
                {
                    index = m연구실.GetEntity(i).fIndex,
                    ability = (ELabAbility)Enum.Parse(typeof(ELabAbility), m연구실.GetEntity(i).fAbility),
                    nameKey = m연구실.GetEntity(i).fNameKey,
                    value = m연구실.GetEntity(i).f증가,
                    levelstep = m연구실.GetEntity(i).f레벨업,
                    newProfile = m연구실.GetEntity(i).f프로필,
                    startTrash = m연구실.GetEntity(i).f쓰레기,
                    startRecycle = m연구실.GetEntity(i).f재활용,
                    startMerge = m연구실.GetEntity(i).f합성,
                    planet = m연구실.GetEntity(i).f행성,
                };
                Info.Add(info);
            }

            for (int i = 0; i < 10; i++)
            {
                LabLevel info = new()
                {
                    level = m연구실.GetEntity(i).f레벨,
                    trashCount = m연구실.GetEntity(i).f쓰레기개수,
                    recycleCount = m연구실.GetEntity(i).f재활용개수,
                    mergeCount = m연구실.GetEntity(i).f합성개수,
                };
                LevelInfo.Add(info);
            }
        }
    }
}