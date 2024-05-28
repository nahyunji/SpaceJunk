using Sirenix.Serialization;

namespace Universe.DB
{
    public class TraderBuyInfo
    {
        [OdinSerialize] public ETraderBuy trader { get; set; }
        [OdinSerialize] public int count { get; set; }
        [OdinSerialize] public EMoney money { get; set; }
        [OdinSerialize] public int price { get; set; }
        [OdinSerialize] public float percent { get; set; }
    }

    public class TraderSellInfo
    {
        [OdinSerialize] public ETraderSale trader { get; set; }
        [OdinSerialize] public int count { get; set; }
        [OdinSerialize] public EMoney money { get; set; }
        [OdinSerialize] public int price { get; set; }
    }
}