using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Universe
{
    [Serializable]
    public class ZodiacSpriteInfo
    {
        public EZodiac zodiac;
        [ShowAssetPreview(50, 50)] public Sprite profile;
        [ShowAssetPreview(50, 50)] public Sprite potion;
    }

    [CreateAssetMenu(menuName = "Scriptables/SpriteData/ZodiacSpriteData")]
    public class ZodiacSpriteData : ScriptableObject
    {
        public List<ZodiacSpriteInfo> zodiacs = new();
    }
}