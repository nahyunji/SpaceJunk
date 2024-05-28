using Sirenix.Serialization;
using System;

namespace Universe.DB
{
    [Serializable]
    public class GreenhouseInfo
    {
        [OdinSerialize] public EVegetable vegetable { get; set; }
        [OdinSerialize] public float time { get; set; }
        [OdinSerialize] public float price { get; set; }
    }

    [Serializable]
    public class GreenhouseLock
    {
        public int slot { get; set; }
        public int price { get; set; }
    }
}