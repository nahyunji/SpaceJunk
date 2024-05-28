using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Universe
{
    [CreateAssetMenu(menuName = "Scriptables/SpriteData/ListSpriteData")]
    public class ListSpriteData : ScriptableObject
    {
        public List<SpriteData> sprites = new List<SpriteData>();
    }
}