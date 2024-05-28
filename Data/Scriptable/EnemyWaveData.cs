using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Universe
{
    [CreateAssetMenu(menuName = "Scriptables/Enemy/EnemyWave")]
    public class EnemyWaveData : ScriptableObject
    {
        public GameObject[] enemyWaves;
    }
}