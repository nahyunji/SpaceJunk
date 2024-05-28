using Sirenix.Serialization;
using System;
using System.Collections.Generic;

namespace Universe.DB
{
    [Serializable]
    public class Event_NewLogin
    {
        [OdinSerialize] public int login { get; set; }
        [OdinSerialize] public EMoney money { get; set; }
        [OdinSerialize] public int reward { get; set; }
    }

    [Serializable]
    public class Event_Level
    {
        [OdinSerialize] public int level;
        [OdinSerialize] public List<Event_Money> moneys;
    }

    [Serializable]
    public class Event_BlackHole
    {
        [OdinSerialize] public int meter;
        [OdinSerialize] public List<Event_Money> moneys;
    }

    [Serializable]
    public class Event_Adaptation
    {
        [OdinSerialize] public EEvent_Adaptation adaptation;
        [OdinSerialize] public string titleKey;
        [OdinSerialize] public int condition;
        [OdinSerialize] public List<Event_Money> moneys;
    }

    [Serializable]
    public class Event_Money
    {
        [OdinSerialize] public EMoney money;
        [OdinSerialize] public int value;
    }
}