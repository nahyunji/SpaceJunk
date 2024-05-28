using UnityEngine;

namespace Universe
{
    public class DebugUI : MonoBehaviour
    {
        [SerializeField] private UIButton debugBtn;
        [SerializeField] private UIButton debugCommandBtn;
        [SerializeField] private DebugUI_Content content;
        [SerializeField] private GameObject commandController;
        public bool openedCommand => commandController.activeInHierarchy;

        private void Start()
        {
            debugBtn.OnClickAction = OpenDebugUI;
            debugCommandBtn.OnClickAction = OpenCommand;
        }

        private void OpenDebugUI()
        {
            content.gameObject.SetActive(true);
        }

        private void OpenCommand()
        {
            commandController.SetActive(!commandController.activeInHierarchy);
        }
    }
}