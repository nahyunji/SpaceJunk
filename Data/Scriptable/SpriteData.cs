using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Universe
{
    [CreateAssetMenu(menuName = "Scriptables/SpriteData/SpriteData")]
    public class SpriteData : ScriptableObject
    {
        [ShowAssetPreview(100, 100)]
        public List<Sprite> sprites = new List<Sprite>();
    }
}