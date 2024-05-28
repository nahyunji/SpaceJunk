using Sirenix.Serialization;

namespace Universe.DB
{
    public class LoadingShipSet
    {
        [OdinSerialize] public int index { get; set; }
        [OdinSerialize] public ELoadingShip grade { get; set; }
        [OdinSerialize] public float speed { get; set; }
        [OdinSerialize] public float amount { get; set; }
        [OdinSerialize] public int priceLevel { get; set; }
    }
}