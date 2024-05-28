using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Universe
{
    [Serializable]
    public class SeedSpriteInfo
    {
        public EVegetable vegetable;
        [ShowAssetPreview(50, 50)] public Sprite main;
        [ShowAssetPreview(50, 50)] public List<Sprite> sprites;
    }

    [CreateAssetMenu(menuName = "Scriptables/SpriteData/SeedSpriteData")]
    public class SeedSpriteData : ScriptableObject
    {
        public List<SeedSpriteInfo> sprites = new();
    }
}