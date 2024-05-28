using TMPro;
using UnityEngine;

namespace Universe
{
    public class DebugUI_ResourceItem : MonoBehaviour
    {
        private ETrash trash;
        private UIButton uiButton;

        private void Start()
        {
            uiButton = GetComponent<UIButton>();
            uiButton.OnClickAction = SelectMoney;
        }

        private void SelectMoney()
        {
            GetComponentInParent<DebugUI_ResourceList>().SelectResource(trash);
        }

        public void SetResource(ETrash trash)
        {
            this.trash = trash;
            GetComponentInChildren<TMP_Text>().text = $"{trash}";
        }
    }
}