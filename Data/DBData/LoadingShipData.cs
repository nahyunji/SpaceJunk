using Sirenix.Serialization;
using System.Collections.Generic;

namespace Universe.DB
{
    public class LoadingShipData
    {
        [OdinSerialize] public List<LoadingShipSet> Info { get; set; }
        [OdinSerialize] public float levelGoldMult { get; set; }

        public int MaxLevel;

        public LoadingShipData()
        {
            LoadData();
        }

        private void LoadData()
        {
            MaxLevel = m운송선.CountEntities;
            Info = new List<LoadingShipSet>();
            levelGoldMult = m운송선.GetEntity(0).f레벨곱;
            for (int i = 0; i < m운송선.CountEntities; i++)
            {
                LoadingShipSet set = new()
                {
                    index = m운송선.GetEntity(i).f번호,
                    grade = LocalUtil.StringToEnum<ELoadingShip>(m운송선.GetEntity(i).f등급),
                    speed = m운송선.GetEntity(i).f속도,
                    amount = m운송선.GetEntity(i).f운송량,
                    priceLevel = m운송선.GetEntity(i).f레벨,
                };
                Info.Add(set);
            }
        }
    }
}