using TMPro;
using UnityEngine;

namespace Universe
{
    public class DebugUI_Blackhole : ConfiguredMonoBehaviour
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
            DebugManager.SetBlackholeInvincible();
            UPdateUI();
        }

        private void UPdateUI()
        {
            info.text = DebugManager.Blackhole_InvincibleMode ? "무적" : "무적 아님";
            invincibleBtn.SetImage(SpriteUtil.Button(DebugManager.Blackhole_InvincibleMode ? EButton.Green : EButton.Red));
        }
    }
}