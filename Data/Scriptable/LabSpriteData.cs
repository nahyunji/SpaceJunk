using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Universe
{
    [Serializable]
    public class LabSpriteInfo
    {
        public string nameKey;
        [ShowAssetPreview(50, 50)] public Sprite sprite;
    }

    [CreateAssetMenu(menuName = "Scriptables/SpriteData/LabSpriteData")]
    public class LabSpriteData : ScriptableObject
    {
        public List<LabSpriteInfo> sprites = new();
    }
}