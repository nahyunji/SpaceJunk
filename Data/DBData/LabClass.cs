using Sirenix.Serialization;
using System;

namespace Universe.DB
{
    [Serializable]
    public class LabInfo
    {
        [OdinSerialize] public string index { get; set; }
        [OdinSerialize] public ELabAbility ability { get; set; }
        [OdinSerialize] public string nameKey { get; set; }
        [OdinSerialize] public float value { get; set; }
        [OdinSerialize] public int levelstep { get; set; }
        [OdinSerialize] public int newProfile { get; set; }
        [OdinSerialize] public int startTrash { get; set; }
        [OdinSerialize] public int startRecycle { get; set; }
        [OdinSerialize] public int startMerge { get; set; }
        [OdinSerialize] public int planet { get; set; }
    }

    [Serializable]
    public class LabLevel
    {
        [OdinSerialize] public int level { get; set; }
        [OdinSerialize] public int recycleCount { get; set; }
        [OdinSerialize] public int mergeCount { get; set; }
        [OdinSerialize] public int trashCount { get; set; }
    }
}