using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Universe.UserData
{
    [Serializable]
    public class LoginData
    {
        public ELogin login = ELogin.None;
        public DateTime restore { get; set; } = new(2023, 10, 01);
        public DateTime join { get; set; }
        public string uid { get; set; }
        public string deId { get; set; } //deviceId
        public string nick { get; set; }
        public DateTime backup { get; set; } = new(2023, 10, 01);
        public List<int> rollback { get; set; } = new();
    }

    [Serializable]
    public class TimeData
    {
        [OdinSerialize] public DateTime time { get; set; } //playTime
    }

    [Serializable]
    public class PlayerData
    {
        [OdinSerialize] public int rank { get; set; } = 1;
        [OdinSerialize] public int level { get; set; } = 1;
        [OdinSerialize] public float exp { get; set; } = 0;
        [OdinSerialize] public int profile { get; set; } = 1;
        [OdinSerialize] public int spaceShip { get; set; } = 1;
        [OdinSerialize] public SystemLanguage language { get; set; }
        [OdinSerialize] public DateTime saveData { get; set; }
        [OdinSerialize] public VolumeData volume { get; set; } = new();
        [OdinSerialize] public List<int> openProfile { get; set; } = new();
        [OdinSerialize] public List<BuffInfo> buff { get; set; } = new();
        [OdinSerialize] public List<DailyData> daily { get; set; } = new();
        [OdinSerialize] public List<string> coupon { get; set; } = new();
        [OdinSerialize] public OfflineADData offAd { get; set; } = new();
        [OdinSerialize] public TutorialData tutorial { get; set; } = new();
    }

    public class TutorialData
    {
        [OdinSerialize] public List<ETutorial> clear { get; set; } = new();
        [OdinSerialize] public (ETutorialQuest, bool) quest { get; set; } = (ETutorialQuest.NONE, false);
    }

    [Serializable]
    public class VolumeData
    {
        [OdinSerialize] public float Bgm { get; set; } = 1;
        [OdinSerialize] public float Sfx { get; set; } = 1;
    }

    [Serializable]
    public class ShipData
    {
        [OdinSerialize] public List<UpgradeInfo> upgrades { get; set; } = new();
        [OdinSerialize] public List<SpaceShipInfo> spaceShipInfos { get; set; } = new();
        [OdinSerialize] public GreenHouseData greenHouse { get; set; } = new();
        [OdinSerialize] public List<Lab> labs { get; set; } = new();
        [OdinSerialize] public StationShop stationShop { get; set; } = new();
        [OdinSerialize] public StationStaff stationStaff { get; set; } = new();
        [OdinSerialize] public StationQuest stationQuests { get; set; } = new();
        [OdinSerialize] public StationTrader stationTrader { get; set; } = new();
    }

    [Serializable]
    public class MoneyData
    {
        [OdinSerialize] public List<MoneyInfo> moneys { get; set; } = new();
    }

    [Serializable]
    public class MoneyInfo
    {
        [OdinSerialize] public EMoney money { get; set; }
        [OdinSerialize] public InfNum value { get; set; }
    }

    //자원 오픈/레벨
    [Serializable]
    public class PlanetResource
    {
        [OdinSerialize] public int index { get; set; }
        [OdinSerialize] public bool open { get; set; }
        [OdinSerialize] public int level { get; set; }
        [OdinSerialize] public int loadingShip { get; set; }
    }

    //행성 리스트
    [Serializable]
    public class UserPlanet
    {
        [OdinSerialize] public EPlanet cur { get; set; } = EPlanet.EARTH;
        [OdinSerialize] public List<PlanetData> list { get; set; } = new();
    }

    //행성 번호, 자원
    [Serializable]
    public class PlanetData
    {
        [OdinSerialize] public EPlanet planet { get; set; }
        [OdinSerialize] public DateTime offstart { get; set; }
        [OdinSerialize] public List<PlanetResource> resource { get; set; } = new();
    }

    [Serializable]
    public class Trash
    {
        [OdinSerialize] public List<TrashSet> trash { get; set; } = new();
        [OdinSerialize] public List<TrashSet> recycle { get; set; } = new();
        [OdinSerialize] public List<MergeSet> merge { get; set; } = new();
        [OdinSerialize] public List<ConvertRecycle> recycleSlots { get; set; } = new();
        [OdinSerialize] public List<ConvertMerge> mergeSlots { get; set; } = new();
    }

    //쓰레기 개수
    [Serializable]
    public class TrashSet
    {
        [OdinSerialize] public ETrash trash { get; set; }
        [OdinSerialize] public InfNum count { get; set; }
        [OdinSerialize] public bool autoSell { get; set; }
    }

    //합성 개수
    [Serializable]
    public class MergeSet
    {
        [OdinSerialize] public EMerge merge { get; set; }
        [OdinSerialize] public InfNum count { get; set; }
        [OdinSerialize] public bool autoSell { get; set; }
    }

    [Serializable]
    public class ConvertRecycle
    {
        [OdinSerialize] public bool open { get; set; }
        [OdinSerialize] public int slot { get; set; }
        [OdinSerialize] public ETrash trash { get; set; }
    }

    [Serializable]
    public class ConvertMerge
    {
        [OdinSerialize] public bool open { get; set; }
        [OdinSerialize] public int slot { get; set; }
        [OdinSerialize] public EMerge merge { get; set; }
    }

    [Serializable]
    public class Staff
    {
        [OdinSerialize] public string id { get; set; }
        [OdinSerialize] public int index { get; set; }
        [OdinSerialize] public EStaffRank rank { get; set; }
        [OdinSerialize] public int upgrade { get; set; }
        [OdinSerialize] public List<bool> star { get; set; } = new();
        [OdinSerialize] public List<EStaffAbility> ability { get; set; } = new();
        [OdinSerialize] public StaffWork work { get; set; } = null;
    }

    public class StaffWork
    {
        [OdinSerialize] public EPlanet planet { get; set; }
        [OdinSerialize] public int source { get; set; } //resourceIndex
        [OdinSerialize] public int slot { get; set; } //resourceSlot
    }

    [Serializable]
    public class StaffData
    {
        [OdinSerialize] public int slot { get; set; } //slotCount
        [OdinSerialize] public EStaffFilter staffFilter { get; set; } = EStaffFilter.Newst_des;
        [OdinSerialize] public EStaffFilter selectStaffFilter { get; set; } = EStaffFilter.ExceptWork_Newst_des;
        [OdinSerialize] public List<Staff> staffs { get; set; } = new();
    }

    [Serializable]
    public class Lab
    {
        [OdinSerialize] public string index { get; set; }
        [OdinSerialize] public int level { get; set; }
    }

    [Serializable]
    public class UpgradeInfo
    {
        [OdinSerialize] public EShipUpgrade upgrade { get; set; }
        [OdinSerialize] public int level { get; set; }
    }

    [Serializable]
    public class SpaceShipInfo
    {
        [OdinSerialize] public int index { get; set; }
        [OdinSerialize] public bool open { get; set; }
        [OdinSerialize] public DateTime build { get; set; }
    }

    [Serializable]
    public class GreenHouseData
    {
        [OdinSerialize] public int level { get; set; }
        [OdinSerialize] public float exp { get; set; }
        [OdinSerialize] public int storageLevel { get; set; }
        [OdinSerialize] public List<SeedInfo> seedInfos { get; set; } = new();
        [OdinSerialize] public List<VegetableInfo> veges { get; set; } = new();
        [OdinSerialize] public List<int> locks { get; set; } = new();
    }

    //화분에 심은 씨앗
    [Serializable]
    public class SeedInfo
    {
        [OdinSerialize] public int index { get; set; }
        [OdinSerialize] public EVegetable vege { get; set; }
        [OdinSerialize] public DateTime seed { get; set; }
    }

    [Serializable]
    public class VegetableInfo
    {
        [OdinSerialize] public EVegetable vege { get; set; }
        [OdinSerialize] public float count { get; set; }
    }

    [Serializable]
    public class BuffInfo
    {
        [OdinSerialize] public EZodiac zodiac { get; set; }
        [OdinSerialize] public int applyTime { get; set; }
        [OdinSerialize] public int num { get; set; }
        [OdinSerialize] public bool auto { get; set; } = false;
    }

    [Serializable]
    public class StationShop
    {
        [OdinSerialize] public DateTime date { get; set; }
        [OdinSerialize] public List<StationShopInfo> infos { get; set; } = new();
    }

    [Serializable]
    public class StationShopInfo
    {
        [OdinSerialize] public bool soldout { get; set; }
        [OdinSerialize] public DB.StationShopInfo buy { get; set; }
        [OdinSerialize] public DB.StationShopInfo price { get; set; }
    }

    [Serializable]
    public class StationStaff
    {
        [OdinSerialize] public DateTime date { get; set; }
        [OdinSerialize] public List<StationStaffInfo> Staffs { get; set; } = new();
    }

    [Serializable]
    public class StationStaffInfo : Staff
    {
        [OdinSerialize] public bool soldOut { get; set; }
    }

    [Serializable]
    public class StationQuest
    {
        [OdinSerialize] public DateTime date { get; set; }
        [OdinSerialize] public List<StationQuestInfo> quests { get; set; } = new();
    }

    [Serializable]
    public class StationQuestInfo
    {
        [OdinSerialize] public EStationQuest quest { get; set; }
        [OdinSerialize] public InfNum cur { get; set; }
        [OdinSerialize] public InfNum goal { get; set; }
        [OdinSerialize] public bool isClear { get; set; }
        [OdinSerialize] public bool accept { get; set; }
        [OdinSerialize] public EMerge merge { get; set; }
        [OdinSerialize] public ETrash trash { get; set; }
        [OdinSerialize] public EVegetable vege { get; set; }
        [OdinSerialize] public (EMoney, int) reward { get; set; }
    }

    [Serializable]
    public class StationTrader
    {
        [OdinSerialize] public DateTime date { get; set; }
        [OdinSerialize] public List<StationTraderBuy> buys { get; set; } = new();
        [OdinSerialize] public List<StationTraderSale> sales { get; set; } = new();
    }

    [Serializable]
    public class StationTraderBuy
    {
        [OdinSerialize] public bool soldout { get; set; }
        [OdinSerialize] public ETraderBuy buy { get; set; }
        [OdinSerialize] public TraderItem item { get; set; }
    }

    [Serializable]
    public class StationTraderSale
    {
        [OdinSerialize] public bool soldout { get; set; }
        [OdinSerialize] public ETraderSale sale { get; set; }
        [OdinSerialize] public TraderItem item { get; set; } = new();
    }

    [Serializable]
    public class TraderItem
    {
        [OdinSerialize] public ETrash trash { get; set; }
        [OdinSerialize] public EMerge merge { get; set; }
        [OdinSerialize] public EVegetable vege { get; set; }
        [OdinSerialize] public EMoney money { get; set; }
        [OdinSerialize] public EZodiac zordiac { get; set; }
    }

    [Serializable]
    public class PassData
    {
        [OdinSerialize] public int season { get; set; }
        [OdinSerialize] public DateTime start { get; set; }
        [OdinSerialize] public DateTime end { get; set; }
        [OdinSerialize] public DateTime questUpdate { get; set; }
        [OdinSerialize] public int level { get; set; }
        [OdinSerialize] public float exp { get; set; }
        [OdinSerialize] public bool buyGold { get; set; }
        [OdinSerialize] public List<PassInfo> reward { get; set; } = new();
        [OdinSerialize] public List<PassQuest> quest { get; set; } = new();
        [OdinSerialize] public (EPlanet, PosVector) star { get; set; } = new();
    }

    [Serializable]
    public class PosVector
    {
        public float x { get; set; } = 0;
        public float y { get; set; } = 0;
        public float z { get; set; } = 0;
    }

    [Serializable]
    public class PassInfo
    {
        [OdinSerialize] public int level { get; set; }
        [OdinSerialize] public bool goldGet { get; set; }
        [OdinSerialize] public bool freeGet { get; set; }
    }

    [Serializable]
    public class PassQuest
    {
        [OdinSerialize] public EPassQuest quest { get; set; }
        [OdinSerialize] public InfNum cur { get; set; }
        [OdinSerialize] public int clear { get; set; }
    }

    [Serializable]
    public class RouletteData
    {
        [OdinSerialize] public DateTime spin { get; set; }
        [OdinSerialize] public int count { get; set; }
    }

    [Serializable]
    public class QuestData
    {
        [OdinSerialize] public DateTime date { get; set; }
        [OdinSerialize] public List<QuestInfo> quests { get; set; } = new();
    }

    [Serializable]
    public class RepeatQuestData
    {
        [OdinSerialize] public ERepeatQuest curQuest { get; set; } = ERepeatQuest.TRASH_COLLECTION;
        [OdinSerialize] public List<RepeatQuestInfo> repeatQuest { get; set; } = new();
    }

    [Serializable]
    public class RepeatQuestInfo
    {
        [OdinSerialize] public ERepeatQuest quest { get; set; }
        [OdinSerialize] public InfNum goal { get; set; }
        [OdinSerialize] public InfNum cur { get; set; }
    }

    [Serializable]
    public class QuestInfo
    {
        [OdinSerialize] public EQuest quest { get; set; }
        [OdinSerialize] public int count { get; set; }
        [OdinSerialize] public bool freeGet { get; set; }
        [OdinSerialize] public bool adGet { get; set; }
    }

    [Serializable]
    public class EventData
    {
        [OdinSerialize] public bool clearLogin { get; set; }
        [OdinSerialize] public string login { get; set; } = "2023-10-1";
        [OdinSerialize] public int loginNum { get; set; }
        [OdinSerialize] public List<DailyData> newLogin { get; set; } = new();
        [OdinSerialize] public List<int> level { get; set; } = new();
        [OdinSerialize] public List<int> blackhole { get; set; } = new();
        [OdinSerialize] public List<EEvent_Adaptation> clearAdapt { get; set; } = new();
        [OdinSerialize] public List<EventAdaptatoinData> adapt { get; set; } = new();
    }

    [Serializable]
    public class DailyData
    {
        [OdinSerialize] public int day { get; set; }
        [OdinSerialize] public DateTime get { get; set; }
    }

    [Serializable]
    public class EventAdaptatoinData
    {
        [OdinSerialize] public EEvent_Adaptation adapt { get; set; }
        [OdinSerialize] public int count { get; set; }
    }

    [Serializable]
    public class CollectionData
    {
        [OdinSerialize] public CollectionAD ad { get; set; } = new();
        [OdinSerialize] public List<CollectionInfo> collect { get; set; } = new();
    }

    [Serializable]
    public class CollectionAD
    {
        [OdinSerialize] public DateTime date { get; set; }
        [OdinSerialize] public int count { get; set; }
    }

    [Serializable]
    public class CollectionInfo
    {
        [OdinSerialize] public int piece { get; set; }
        [OdinSerialize] public ECollection collect { get; set; }
        [OdinSerialize] public List<int> bonus { get; set; } = new();
        [OdinSerialize] public List<CollectEach> each { get; set; } = new();
        [OdinSerialize] public List<CollectionTrash> trash { get; set; } = new();
    }

    [Serializable]
    public class CollectionTrash
    {
        [OdinSerialize] public ETrash trash { get; set; }
        [OdinSerialize] public List<CollectEach> each { get; set; } = new();
    }

    [Serializable]
    public class CollectEach
    {
        [OdinSerialize] public int index { get; set; }
        [OdinSerialize] public bool getBonus { get; set; }
    }

    [Serializable]
    public class LocalMsg
    {
        [OdinSerialize] public SystemLanguage lang { get; set; }
        [OdinSerialize] public string title { get; set; }
        [OdinSerialize] public string msg { get; set; }
    }

    [Serializable]
    public class ChallengeData
    {
        [OdinSerialize] public int piratesStage { get; set; } = 0;
        [OdinSerialize] public BlackholeData blackhole { get; set; } = new();
        [OdinSerialize] public List<ClearPirate> clearPirate { get; set; } = new();
        [OdinSerialize] public List<OreData> oreData { get; set; } = new();
    }

    [Serializable]
    public class BlackholeData
    {
        [OdinSerialize] public int version { get; set; }
        [OdinSerialize] public BlackholeRecord bestRecord { get; set; } = new BlackholeRecord(); //for event
        [OdinSerialize] public BlackholeRecord curRecord { get; set; } = new BlackholeRecord(); //for week
        [OdinSerialize] public List<BlackholeReward> rewards { get; set; } = new();
    }

    [Serializable]
    public class BlackholeRecord
    {
        [OdinSerialize] public int meter { get; set; } = 0;
        [OdinSerialize] public double time { get; set; } = 0;
        [OdinSerialize] public double tab { get; set; } = 0;
    }

    [Serializable]
    public class BlackholeReward
    {
        [OdinSerialize] public int position { get; set; }
        [OdinSerialize] public int version { get; set; }
        [OdinSerialize] public int value { get; set; }
        [OdinSerialize] public bool get { get; set; }
    }

    [Serializable]
    public class ClearPirate
    {
        [OdinSerialize] public int stage { get; set; }
        [OdinSerialize] public int kill { get; set; }
    }

    [Serializable]
    public class OreData
    {
        [OdinSerialize] public bool working { get; set; }
        [OdinSerialize] public EOrePlanet orePlanet { get; set; }
        [OdinSerialize] public DateTime start { get; set; }
        [OdinSerialize] public string staffuniq { get; set; }
        [OdinSerialize] public bool complete { get; set; }
        [OdinSerialize] public List<OreRewardInfo> reward { get; set; } = new();
    }

    [Serializable]
    public class OreRewardInfo
    {
        [OdinSerialize] public EMerge merge { get; set; }
        [OdinSerialize] public int count { get; set; }
    }

    [Serializable]
    public class OfflineADData
    {
        [OdinSerialize] public DateTime offlineDay { get; set; }
        [OdinSerialize] public int offline { get; set; }
    }

    [Serializable]
    public class ShopData
    {
        [OdinSerialize] public List<ShopGalileo> galileo { get; set; } = new();
        [OdinSerialize] public List<ShopSpace> space { get; set; } = new();
        [OdinSerialize] public List<ShopStar> star { get; set; } = new();
        [OdinSerialize] public List<ShopCharge> charge { get; set; } = new();
        [OdinSerialize] public List<ShopInfo> pass { get; set; } = new();
        [OdinSerialize] public List<GemShopInfo> gem { get; set; } = new();
        [OdinSerialize] public DateTime gemDaily { get; set; }
        [OdinSerialize] public DateTime adGemDaily { get; set; }
        [OdinSerialize] public int adCount { get; set; } = 0;
    }

    [Serializable]
    public class GemShopInfo
    {
        [OdinSerialize] public EMoney money { get; set; }
        [OdinSerialize] public int buy { get; set; }
        [OdinSerialize] public DateTime date { get; set; }
    }

    [Serializable]
    public class ShopInfo
    {
        [OdinSerialize] public DateTime date { get; set; }
        [OdinSerialize] public bool success { get; set; }
        [OdinSerialize] public string log { get; set; } = "";
    }

    [Serializable]
    public class ShopGalileo : ShopInfo
    {
        [OdinSerialize] public EGalileoPack pack { get; set; }
    }

    [Serializable]
    public class ShopStar : ShopInfo
    {
        [OdinSerialize] public EShopStarPack pack { get; set; }
    }

    [Serializable]
    public class ShopCharge : ShopInfo
    {
        [OdinSerialize] public EShopChargePack pack { get; set; }
    }

    [Serializable]
    public class ShopSpace : ShopInfo
    {
        [OdinSerialize] public DateTime start { get; set; }
        [OdinSerialize] public DateTime end { get; set; }
    }

    [Serializable]
    public class ServerSaveList
    {
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        [OdinSerialize] public List<ESave> saveList { get; set; } = new();
    }

    [Serializable]
    public class StaffFilterList
    {
        [OdinSerialize] public EStaffFilter filter { get; set; }
        [OdinSerialize] public List<UserData.Staff> staffs { get; set; } = new();
    }
}