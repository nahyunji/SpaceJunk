using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Universe
{
    [Serializable]
    public class SpaceShipMenuInfo
    {
        public ESpaceShipMenu menu;
        [ShowAssetPreview(50, 50)] public Sprite sprite;
    }

    [CreateAssetMenu(menuName = "Scriptables/SpriteData/SpaceShipMenuData")]
    public class SpaceShipMenuData : ScriptableObject
    {
        public List<SpaceShipMenuInfo> sprites = new List<SpaceShipMenuInfo>();
    }
}