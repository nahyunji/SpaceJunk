using TMPro;
using UnityEngine;

namespace Universe
{
    public class DebugUI_Pass : ConfiguredMonoBehaviour
    {
        [SerializeField] private TMP_InputField passInput;
        [SerializeField] private UIButton passLevelBtn;
        [SerializeField] private TMP_Text infoTex;

        private void Start()
        {
            passLevelBtn.OnClickAction = AddPassLevel;
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
            infoTex.text = $"Pass Level : {PassUtil.UserPassData.level}";
        }

        private void AddPassLevel()
        {
            PassUtil.AddLevel(int.Parse(passInput.text));
            SetInfoText();
        }
    }
}