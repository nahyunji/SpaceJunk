using Sirenix.Serialization;
using System;
using System.Collections.Generic;

namespace Universe.DB
{
    public class GreenhouseData
    {
        [OdinSerialize] public List<GreenhouseInfo> Info { get; set; } = new();
        [OdinSerialize] public List<GreenhouseLock> LockInfo { get; set; } = new();
        public int Storage { get; set; }
        public int StorageAdd { get; set; }
        public int MaxStorage { get; set; }
        public int AddPrice { get; set; }

        public GreenhouseData()
        {
            LoadData();
        }

        private void LoadData()
        {
            Storage = m온실.GetEntity(0).f창고용량;
            StorageAdd = m온실.GetEntity(0).f창고추가;
            MaxStorage = m온실.GetEntity(0).f창고최대;
            AddPrice = m온실.GetEntity(0).f추가비용;

            for (int i = 0; i < m온실.CountEntities; i++)
            {
                GreenhouseInfo newItem = new()
                {
                    vegetable = (EVegetable)Enum.Parse(typeof(EVegetable), m온실.GetEntity(i).fVegetable),
                    time = m온실.GetEntity(i).f시간,
                    price = m온실.GetEntity(i).f판매,
                };
                Info.Add(newItem);
            }

            for (int i = 0; i < 2; i++)
            {
                LockInfo.Add(new GreenhouseLock()
                {
                    slot = m온실.GetEntity(i).f슬롯개수,
                    price = m온실.GetEntity(i).f슬롯비용
                });
            }
        }
    }
}