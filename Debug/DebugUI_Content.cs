using System;
using UnityEngine;

namespace Universe
{
    public class DebugUI_Content : ConfiguredMonoBehaviour
    {
        [SerializeField] private UIButton closeBtn;
        [SerializeField] private UIButton resetBtn;
        [SerializeField] private UIButton backBtn;
        [SerializeField] private UIButton maxBtn;

        private void Start()
        {
            backBtn.OnClickAction = CloseDebug;
            closeBtn.OnClickAction = CloseDebug;
            resetBtn.OnClickAction = ResetData;
            maxBtn.OnClickAction = Max;
        }

        private void Max()
        {
            GameManager.Instance.SetMax();
        }

        private void CloseDebug()
        {
            gameObject.SetActive(false);
        }

        private void ResetData()
        {
            DataManager.user.ResetUserData();
        }
    }
}