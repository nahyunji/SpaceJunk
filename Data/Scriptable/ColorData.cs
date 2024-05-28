using System.Collections.Generic;
using UnityEngine;

namespace Universe
{
    [CreateAssetMenu(menuName = "Scriptables/SpriteData/ColorData")]
    public class ColorData : ScriptableObject
    {
        public List<Colors> colors = new List<Colors>();
    }
}