using System;
using System.Collections;
using System.Collections.Generic;
using Universe.UserData;

namespace Universe.Simple
{
    [Serializable]
    public class SimpleServerData
    {
        public SimpleEconomyData economyData { get; set; } = new();
        public SimplePlayData playData { get; set; } = new();
        public SimpleCollectData collectData { get; set; } = new();
    }

    [Serializable]
    public class SimplePlayData
    {
        public SimplePlayerData player { get; set; } = new();
        public SimplePlanetData planet { get; set; } = new();
        public SimpleShipData ship { get; set; } = new();
        public SimpleCollectionData collection { get; set; } = new();
        public SimpleChallengeData challenge { get; set; } = new();
        public RouletteData roulette { get; set; } = new();
        public SimpleQuestData quest { get; set; } = new();
        public SimpleRepeatQuestData repeatQuest { get; set; } = new();
        public EventData events { get; set; } = new();
    }

    public class SimpleQuestData
    {
        public DateTime date { get; set; }
        public List<List<int>> quest { get; set; } = new();
    }

    public class SimpleRepeatQuestData
    {
        public int curQuest { get; set; }
        public List<List<long>> quest { get; set; } = new();
    }

    [Serializable]
    public class SimpleChallengeData
    {
        public int pirate { get; set; }
        public int blackVersion { get; set; }
        public List<double> blackBest { get; set; } = new();
        public List<double> blackRecord { get; set; } = new();
        public List<List<int>> blackReward { get; set; } = new();
        public List<List<int>> clearPirate { get; set; } = new();
        public List<SimpleOreData> ore { get; set; } = new();
    }

    [Serializable]
    public class SimpleOreData
    {
        public List<int> data { get; set; } = new();
        public List<string> strs { get; set; } = new();
        public List<List<int>> reward { get; set; } = new();
    }

    [Serializable]
    public class SimpleCollectionData
    {
        public CollectionAD ad { get; set; } = new();
        public List<SimpleCollectionInfo> collect { get; set; } = new();
    }

    [Serializable]
    public class SimpleCollectionInfo
    {
        public List<int> data { get; set; } = new();
        public List<int> bonus { get; set; } = new();
        public List<List<int>> each { get; set; } = new();
        public List<SimpleCollectionTrash> trash { get; set; } = new();
    }

    [Serializable]
    public class SimpleCollectionTrash
    {
        public int trash { get; set; }
        public List<List<int>> each { get; set; } = new();
    }

    [Serializable]
    public class SimpleShipData
    {
        public List<List<int>> upgrade { get; set; } = new();
        public List<SimpleSpaceShipInfo> shipInfo { get; set; } = new();
        public SimpleGreenHouseData seed { get; set; } = new();
        public List<Lab> lab { get; set; } = new();
        public SimpleStationShop shop { get; set; } = new();
        public SimpleStationStaffInfo staff { get; set; } = new();
        public SimpleStationQuest quest { get; set; } = new();
        public SimpleStationTrader trader { get; set; } = new();
    }

    [Serializable]
    public class SimpleStationTrader
    {
        public DateTime date { get; set; }
        public List<List<int>> buy { get; set; } = new();
        public List<List<int>> sale { get; set; } = new();
    }

    [Serializable]
    public class SimpleStationQuest
    {
        public DateTime date { get; set; }
        public List<SimpleStationQuestInfo> quest { get; set; } = new();
    }

    [Serializable]
    public class SimpleStationQuestInfo
    {
        public List<int> data { get; set; } = new();
        public List<long> infnum { get; set; } = new();
    }

    [Serializable]
    public class SimpleStationShop
    {
        public DateTime date { get; set; }
        public List<SimpleStationShopInfo> info { get; set; } = new();
    }

    [Serializable]
    public class SimpleStationShopInfo
    {
        public int soldout { get; set; }
        public List<int> buy { get; set; } = new();
        public List<int> price { get; set; } = new();
    }

    [Serializable]
    public class SimpleStationStaffInfo
    {
        public DateTime date { get; set; }
        public List<StationStaffInfo> staff { get; set; } = new();
    }

    [Serializable]
    public class StationStaffInfo : SimpleStaff
    {
        public int soldout { get; set; }
    }

    [Serializable]
    public class SimpleGreenHouseData
    {
        public int level { get; set; }
        public float exp { get; set; }
        public int storage { get; set; }
        public List<SimpleSeedInfo> seed { get; set; } = new();
        public List<int> locks { get; set; } = new();
        public List<List<float>> vege { get; set; } = new();
    }

    [Serializable]
    public class SimpleSeedInfo
    {
        public List<int> data { get; set; } = new();
        public DateTime seed { get; set; }
    }

    [Serializable]
    public class SimpleSpaceShipInfo
    {
        public List<int> data { get; set; } = new();
        public DateTime build { get; set; }
    }

    [Serializable]
    public class SimplePlayerData
    {
        public int rank { get; set; } = 1;
        public int level { get; set; } = 1;
        public float exp { get; set; } = 0;
        public int profile { get; set; } = 1;
        public int spaceShip { get; set; } = 1;
        public string language { get; set; }
        public DateTime saveData { get; set; }
        public List<float> voluem { get; set; } = new();
        public List<int> openProfile { get; set; } = new();
        public List<SimpleBuffInfo> buff { get; set; } = new();
        public List<string> coupon { get; set; } = new();
        public List<SimpleDailyData> daily { get; set; } = new();
        public (int, DateTime) offAD { get; set; } = new();
        public List<int> tuto { get; set; } = new();
        public List<int> tutoQuest { get; set; } = new();
    }

    [Serializable]
    public class SimpleDailyData
    {
        public int d { get; set; }
        public DateTime g { get; set; }
    }

    [Serializable]
    public class SimplePlanetData
    {
        public EPlanet cur { get; set; }
        public List<SimplePlanetResource> list { get; set; } = new();
    }

    [Serializable]
    public class SimplePlanetResource
    {
        public int planet { get; set; }
        public DateTime off { get; set; }
        public List<List<int>> source { get; set; } = new();
    }

    [Serializable]
    public class SimpleBuffInfo
    {
        public List<int> data = new();
    }

    [Serializable]
    public class SimpleEconomyData
    {
        public ShopData shop { get; set; } = new();
        public SimpleMoneyData money { get; set; } = new();
        public SimplePassData pass { get; set; } = new();
    }

    [Serializable]
    public class SimpleMoneyData
    {
        public List<List<long>> data { get; set; } = new();
    }

    [Serializable]
    public class SimplePassData
    {
        public int season { get; set; }
        public List<string> date { get; set; } = new();
        public List<float> data { get; set; } = new();
        public List<List<int>> reward { get; set; } = new();
        public List<List<long>> quest { get; set; } = new();
        public List<float> star { get; set; } = new();
    }

    [Serializable]
    public class SimpleCollectData
    {
        public SimpleTrash trash { get; set; } = new();
        public SimpleStaffData staff { get; set; } = new();
    }

    [Serializable]
    public class SimpleStaffData
    {
        public int slot { get; set; } //slotCount
        public List<int> filter { get; set; }
        public List<SimpleStaff> staff { get; set; } = new();
    }

    [Serializable]
    public class SimpleStaff
    {
        public string id { get; set; }
        public List<int> data { get; set; } = new();
        public List<List<int>> list { get; set; } = new();
        public List<int> work { get; set; } = new();
    }

    [Serializable]
    public class SimpleTrash
    {
        public List<SimpleTrashSet> tra { get; set; } = new();
        public List<SimpleTrashSet> rec { get; set; } = new();
        public List<SimpleTrashSet> mer { get; set; } = new();

        public List<SimpleTrashSet> recSlot { get; set; } = new();
        public List<SimpleTrashSet> merSlot { get; set; } = new();
    }

    [Serializable]
    public class SimpleTrashSet
    {
        public List<long> data { get; set; } = new();
    }
}