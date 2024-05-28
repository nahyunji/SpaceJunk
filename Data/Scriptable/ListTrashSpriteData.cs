using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Universe
{
    [CreateAssetMenu(menuName = "Scriptables/SpriteData/ListTrashSpriteData")]
    public class ListTrashSpriteData : ScriptableObject
    {
        public List<TrashSpriteData> sprites = new List<TrashSpriteData>();
    }
}