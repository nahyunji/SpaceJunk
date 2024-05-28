using TMPro;
using UnityEngine;

namespace Universe
{
    public class DebugUI_Player : ConfiguredMonoBehaviour
    {
        [SerializeField] private TMP_InputField expInput;
        [SerializeField] private TMP_InputField levelInput;
        [SerializeField] private TMP_InputField blackholeInput, blackholeTimeInput;
        [SerializeField] private TMP_InputField adaptationInput;
        [SerializeField] private UIButton expBtn;
        [SerializeField] private UIButton levelBtn;
        [SerializeField] private UIButton blackholeBtn;
        [SerializeField] private UIButton adaptationBtn;
        [SerializeField] private TMP_Text infoTex;

        private void Start()
        {
            expBtn.OnClickAction = AddExp;
            levelBtn.OnClickAction = AddLevel;
            blackholeBtn.OnClickAction = AddBlackholeRecord;
            adaptationBtn.OnClickAction = AddAdaptation;
        }

        private void OnEnable()
        {
            GameManager.OnInit += SetInfoText;
            SetInfoText();
        }

        private void OnDisable()
        {
            if (ApplicationQuit) return;
            GameManager.OnInit -= SetInfoText;
        }

        private void SetInfoText()
        {
            infoTex.text = $"Exp: {PlayerUtil.PlayerData.exp}\n Level: {PlayerUtil.PlayerData.level}" +
                $"\n Blackhole: {ChallengeUtil.UserChallengeData.blackhole.curRecord.meter}";
        }

        private void AddExp()
        {
            PlayerUtil.AddExp(int.Parse(expInput.text));
            SetInfoText();
        }

        private void AddLevel()
        {
            PlayerUtil.AddLevel(int.Parse(levelInput.text));
            SetInfoText();
        }

        private void AddBlackholeRecord()
        {
            ChallengeUtil.DebugBlackholeRecord(int.Parse(blackholeInput.text), float.Parse(blackholeTimeInput.text));
            SetInfoText();
        }

        private void AddAdaptation()
        {
            EventUtil.DebugAddAlAdaptation(int.Parse(adaptationInput.text));
        }
    }
}