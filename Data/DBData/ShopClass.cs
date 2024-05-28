using Sirenix.Serialization;
using System;
using System.Collections.Generic;

namespace Universe.DB
{
    [Serializable]
    public class ShopGalileo
    {
        [OdinSerialize] public EShop shop = EShop.GALILEO;
        [OdinSerialize] public List<GalileoInfo> Info { get; set; }
    }

    [Serializable]
    public class ShopStar
    {
        [OdinSerialize] public EShop shop = EShop.STAR_EXPLORATION;
        [OdinSerialize] public List<StarInfo> Info { get; set; }
    }

    [Serializable]
    public class ChargeShop
    {
        [OdinSerialize] public EShop shop = EShop.CHARGE;
        [OdinSerialize] public List<ChargeInfo> Info { get; set; }
    }

    [Serializable]
    public class GemShop
    {
        [OdinSerialize] public EShop shop = EShop.GEM_SHOP;
        [OdinSerialize] public List<GemShopInfo> Info { get; set; }
    }

    [Serializable]
    public class MemberShip : ShopInfo
    {
        [OdinSerialize] public EShop shop = EShop.SPACE_FEDERATION;
        [OdinSerialize] public (EMoney, int) startReward { get; set; }
        [OdinSerialize] public (EMoney, int) reward { get; set; }
        [OdinSerialize] public (EMoney, int) MemberShipReward { get; set; }
        [OdinSerialize] public (EMoney, int) MemberShipDailyReward { get; set; }
        [OdinSerialize] public int MemberShipOfflineTime { get; set; }
        [OdinSerialize] public int MemberShipLimitMult { get; set; }
        [OdinSerialize] public string discount_googleKey { get; set; }
        [OdinSerialize] public float discount_doller { get; set; }
        [OdinSerialize] public int discount_krw { get; set; }
    }

    [Serializable]
    public class GalileoInfo : ShopPeriod
    {
        [OdinSerialize] public EGalileoPack pack { get; set; }
    }

    [Serializable]
    public class StarInfo : ShopPeriod
    {
        [OdinSerialize] public EShopStarPack pack { get; set; }
        [OdinSerialize] public int zodiac { get; set; }
    }

    [Serializable]
    public class ChargeInfo : ShopInfo
    {
        [OdinSerialize] public EShopChargePack pack { get; set; }
        [OdinSerialize] public EMoney money { get; set; }
        [OdinSerialize] public int reward { get; set; }
    }

    [Serializable]
    public class ShopPeriod : ShopInfo
    {
        [OdinSerialize] public (EPeriod, int) period { get; set; }
        [OdinSerialize] public Dictionary<EMoney, int> reward { get; set; }
    }

    [Serializable]
    public class ShopInfo
    {
        [OdinSerialize] public string googleKey { get; set; }
        [OdinSerialize] public float doller { get; set; }
        [OdinSerialize] public int krw { get; set; }
    }

    [Serializable]
    public class GemShopInfo
    {
        [OdinSerialize] public EMoney money { get; set; }
        [OdinSerialize] public int reward { get; set; }
        [OdinSerialize] public int price { get; set; }
        [OdinSerialize] public int dayLimit { get; set; }
    }
}