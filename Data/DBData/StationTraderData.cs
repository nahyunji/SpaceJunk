using Sirenix.Serialization;
using System.Collections.Generic;

namespace Universe.DB
{
    public class StationTraderData
    {
        [OdinSerialize] public List<TraderBuyInfo> BuyInfo { get; set; }
        [OdinSerialize] public List<TraderSellInfo> SellInfo { get; set; }

        public StationTraderData()
        {
            LoadData();
        }

        private void LoadData()
        {
            BuyInfo = new();
            SellInfo = new();

            for (int i = 0; i < m떠돌이상인.GetEntity(0).f구매; i++)
            {
                var newBuy = new TraderBuyInfo
                {
                    trader = LocalUtil.StringToEnum<ETraderBuy>(m떠돌이상인.GetEntity(i).fBuy_Key),
                    count = m떠돌이상인.GetEntity(i).fBuy_Count,
                    money = LocalUtil.StringToEnum<EMoney>(m떠돌이상인.GetEntity(i).fBuy_Money),
                    price = m떠돌이상인.GetEntity(i).fBuy_Price,
                    percent = m떠돌이상인.GetEntity(i).f확률,
                };
                BuyInfo.Add(newBuy);
            }

            for (int i = 0; i < m떠돌이상인.GetEntity(0).f판매; i++)
            {
                var newSell = new TraderSellInfo
                {
                    trader = LocalUtil.StringToEnum<ETraderSale>(m떠돌이상인.GetEntity(i).fSell_Key),
                    count = m떠돌이상인.GetEntity(i).fSell_Price,
                    money = LocalUtil.StringToEnum<EMoney>(m떠돌이상인.GetEntity(i).fSell_Money),
                    price = m떠돌이상인.GetEntity(i).fSell_Count
                };
                SellInfo.Add(newSell);
            }
        }
    }
}