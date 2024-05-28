using TMPro;
using UnityEngine;

namespace Universe
{
    public class DebugUI_Pirate : ConfiguredMonoBehaviour
    {
        [SerializeField] private TMP_Text info;
        [SerializeField] private UIButton invincibleBtn;

        private void Start()
        {
            invincibleBtn.OnClickAction = ClickInvincible;
            UPdateUI();
        }

        private void ClickInvincible()
        {
            DebugManager.SetPirateInvincible();
            UPdateUI();
        }

        private void UPdateUI()
        {
            info.text = DebugManager.Pirate_InvincibleMode ? "무적" : "무적 아님";
            invincibleBtn.SetImage(SpriteUtil.Button(DebugManager.Pirate_InvincibleMode ? EButton.Green : EButton.Red));
        }
    }
}