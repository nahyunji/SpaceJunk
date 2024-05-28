using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Universe
{
    [Serializable]
    public class MoneyInfo
    {
        public EMoney EMoney;
        [ShowAssetPreview(50, 50)] public Sprite sprite;
    }

    [CreateAssetMenu(menuName = "Scriptables/SpriteData/MoneySpriteData")]
    public class MoenySpriteData : ScriptableObject
    {
        public List<MoneyInfo> sprites = new List<MoneyInfo>();
    }
}