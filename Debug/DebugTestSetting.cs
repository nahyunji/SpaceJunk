using Sirenix.OdinInspector;
using UnityEngine;

namespace Universe
{
    public class DebugTestSetting : SingletonConfigured<DebugTestSetting>
    {
        public bool BlackholeMaxTest = false;
        [SerializeField] private MainUI mainUI;
        [SerializeField] private GameObject pirateUI;
        [SerializeField] private GameObject pirateIngame;

        public bool isPirate;

        [Button]
        public void PirateSetting()
        {
            if (isPirate) mainUI.HideUI();
            else mainUI.ShowUI();
            pirateUI.SetActive(isPirate);
            pirateIngame.SetActive(isPirate);
        }
    }
}