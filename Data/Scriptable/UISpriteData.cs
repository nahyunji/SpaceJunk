using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Universe
{
    [CreateAssetMenu(menuName = "Scriptables/SpriteData/UISpriteData")]
    public class UISpriteData : ScriptableObject
    {
        public List<ButtonSprite> button = new();
        public List<FrameSprite> frame = new();
        public List<IconSprite> icon = new();

        public Sprite GetButton(EButton eButton) => button.Find(x => x.type == eButton).sprite;

        public Sprite GetFrame(EFrame eFrame) => frame.Find(x => x.type == eFrame).sprite;

        public Sprite GetIcon(EIcon eIcon) => icon.Find(x => x.type == eIcon).sprite;

        public Sprite GetFrame(EStaffRank staffGrade) => staffGrade switch
        {
            EStaffRank.RARE => GetFrame(EFrame.Purple),
            EStaffRank.EPIC => GetFrame(EFrame.Yellow),
            EStaffRank.REGEND => GetFrame(EFrame.Red),
            _ => GetFrame(EFrame.Blue)
        };

        public Sprite GetFrame(EMergeGrade grade) => grade switch
        {
            EMergeGrade.NORMAL => GetFrame(EFrame.Blue),
            EMergeGrade.RARE => GetFrame(EFrame.Green),
            EMergeGrade.UNIQUE => GetFrame(EFrame.Purple),
            EMergeGrade.REGEND => GetFrame(EFrame.Yellow),
            EMergeGrade.EPIC => GetFrame(EFrame.Red),
            _ => GetFrame(EFrame.Blue)
        };

        public Sprite GetIcon(int upgrade) => upgrade switch
        {
            1 => GetIcon(EIcon.Number1),
            2 => GetIcon(EIcon.Number2),
            3 => GetIcon(EIcon.Number3),
            _ => GetIcon(EIcon.Number1)
        };
    }
}