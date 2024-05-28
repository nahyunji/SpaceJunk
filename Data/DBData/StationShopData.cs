using Sirenix.Serialization;
using System.Collections.Generic;

namespace Universe.DB
{
    public class StationShopData
    {
        [OdinSerialize] public List<StationShopInfo> BuyInfo { get; set; } = new();
        [OdinSerialize] public List<StationShopInfo> PriceInfo { get; set; } = new();
        [OdinSerialize] public int dailyCount { get; set; }

        public StationShopData() => LoadData();

        private void LoadData()
        {
            dailyCount = m우주상점.GetEntity(0).f일일개수;

            for (int i = 0; i < m우주상점.CountEntities; i++)
            {
                StationShopInfo newbuyInfo = new()
                {
                    money = LocalUtil.StringToEnum<EMoney>(m우주상점.GetEntity(i).f구매),
                    value = m우주상점.GetEntity(i).f구매개수,
                };
                BuyInfo.Add(newbuyInfo);

                StationShopInfo newpriceInfo = new()
                {
                    money = LocalUtil.StringToEnum<EMoney>(m우주상점.GetEntity(i).f재화),
                    value = m우주상점.GetEntity(i).f비용,
                };
                PriceInfo.Add(newpriceInfo);
            }
        }
    }
}