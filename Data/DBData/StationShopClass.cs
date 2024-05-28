using Sirenix.Serialization;

namespace Universe.DB
{
    [ES3Serializable]
    public class StationShopInfo
    {
        [OdinSerialize] public EMoney money { get; set; }
        [OdinSerialize] public int value { get; set; }
    }
}