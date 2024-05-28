using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Universe
{
    [CreateAssetMenu(menuName = "Scriptables/SpriteData/TrashSpriteData")]
    public class TrashSpriteData : ScriptableObject
    {
        public ETrash trash;

        [ShowAssetPreview(120, 120)]
        public Sprite profile;

        public float sizeMulty = 1;
        public float radius = 4;

        [ShowAssetPreview(100, 100)]
        public List<Sprite> sprites = new List<Sprite>();
    }
}