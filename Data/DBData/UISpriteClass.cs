using NaughtyAttributes;
using System;
using UnityEngine;

namespace Universe
{
    [Serializable]
    public class ButtonSprite
    {
        public EButton type;
        [ShowAssetPreview(50, 50)] public Sprite sprite;
    }

    [Serializable]
    public class FrameSprite
    {
        public EFrame type;
        [ShowAssetPreview(50, 50)] public Sprite sprite;
    }

    [Serializable]
    public class IconSprite
    {
        public EIcon type;
        [ShowAssetPreview(50, 50)] public Sprite sprite;
    }

    [Serializable]
    public class Colors
    {
        public EColor type;
        public Color color;
        public string hex;
    }
}