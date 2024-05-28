using Sirenix.Serialization;
using System;
using System.Collections.Generic;

namespace Universe.DB
{
    [Serializable]
    public class SpaceShipInfo
    {
        [OdinSerialize] public int index { get; set; }
        [OdinSerialize] public float buildtime { get; set; }
        [OdinSerialize] public int price { get; set; }
        [OdinSerialize] public List<SpaceShipAbility> abilities { get; set; }
        [OdinSerialize] public List<SpaceShipResource> resources { get; set; }
    }

    public class SpaceShipAbility
    {
        [OdinSerialize] public EShipAbility shipAbility { get; set; }
        [OdinSerialize] public float abilityValue { get; set; }
    }

    public class SpaceShipResource
    {
        [OdinSerialize] public EResource eResource { get; set; }
        [OdinSerialize] public ETrash eTrash { get; set; }
        [OdinSerialize] public EMerge eMerge { get; set; }
        [OdinSerialize] public int resourceCount { get; set; }
    }
}