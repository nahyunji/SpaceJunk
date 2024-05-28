using Sirenix.Serialization;
using System;
using System.Collections.Generic;

namespace Universe.DB
{
    [Serializable]
    public class PiratesInfo
    {
        [OdinSerialize] public EChallenge challange { get; set; } = EChallenge.CLEAR_PIRATES;
        [OdinSerialize] public List<PiratesStage> stages { get; set; } = new();
    }

    [Serializable]
    public class PiratesStage
    {
        [OdinSerialize] public int stage { get; set; }
        [OdinSerialize] public float power { get; set; }
        [OdinSerialize] public float health { get; set; }
        [OdinSerialize] public float bossPower { get; set; }
        [OdinSerialize] public int bossHealth { get; set; }
        [OdinSerialize] public float perGold { get; set; }
        [OdinSerialize] public int clearGem { get; set; }
        [OdinSerialize] public int clearGraxyCoin { get; set; }
        [OdinSerialize] public float enemyBulletDelay { get; set; }
        [OdinSerialize] public float enemyBulletSpeed { get; set; }
        [OdinSerialize] public List<int> enemyCount { get; set; }
        [OdinSerialize] public float waveSpeed { get; set; }
        [OdinSerialize] public float wavetimeBetween { get; set; }
        [OdinSerialize] public float bulletPercent { get; set; }
    }

    [Serializable]
    public class BlackholeMeter
    {
        [OdinSerialize] public int meter { get; set; }
        [OdinSerialize] public float minSize { get; set; }
        [OdinSerialize] public float maxSize { get; set; }
        [OdinSerialize] public float minLength { get; set; }
        [OdinSerialize] public float maxLength { get; set; }
        [OdinSerialize] public float speed { get; set; }
    }

    [Serializable]
    public class BlackholeRankReward
    {
        [OdinSerialize] public int min { get; set; }
        [OdinSerialize] public int max { get; set; }
        [OdinSerialize] public EMoney money { get; set; }
        [OdinSerialize] public int value { get; set; }
    }

    [Serializable]
    public class OrePlanetInfo
    {
        [OdinSerialize] public int index { get; set; }
        [OdinSerialize] public EOrePlanet orePlanet { get; set; }
        [OdinSerialize] public int time { get; set; }
        [OdinSerialize] public List<int> reward { get; set; }
        [OdinSerialize] public int minReward { get; set; }
        [OdinSerialize] public int maxReward { get; set; }
    }
}