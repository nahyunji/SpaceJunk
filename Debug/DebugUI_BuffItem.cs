using UnityEngine;
using Local.Localization;

namespace Universe
{
    public class DebugUI_BuffItem : MonoBehaviour
    {
        private EZodiac zordiac;
        private UIButton uiButton;

        private void Start()
        {
            uiButton = GetComponent<UIButton>();
            uiButton.OnClickAction = SelectBuff;
        }

        private void SelectBuff()
        {
            GetComponentInParent<DebugUI_BuffList>().SelectBuff(zordiac);
        }

        internal void SetBuff(EZodiac zordiac)
        {
            this.zordiac = zordiac;
            GetComponentInChildren<LocalizedTMPFormatParams>().UpdateFormatParameters("{0}", (true, $"{zordiac}"));
        }
    }
}