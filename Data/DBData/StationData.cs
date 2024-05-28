using Sirenix.Serialization;

namespace Universe.DB
{
    public class StationData
    {
        [OdinSerialize] public StationShopData shop { get; set; }
        [OdinSerialize] public StationTraderData trader { get; set; }
        [OdinSerialize] public StationRecruitData recruit { get; set; }
        [OdinSerialize] public StationQuestData quest { get; set; }

        public StationData()
        {
            LoadData();
        }

        private void LoadData()
        {
            shop = new();
            trader = new();
            recruit = new();
            quest = new();
        }
    }
}