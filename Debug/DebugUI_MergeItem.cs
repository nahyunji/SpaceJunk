using TMPro;
using UnityEngine;

namespace Universe
{
    public class DebugUI_MergeItem : MonoBehaviour
    {
        private EMerge merge;
        private UIButton uiButton;

        private void Start()
        {
            uiButton = GetComponent<UIButton>();
            uiButton.OnClickAction = SelectMerge;
        }

        private void SelectMerge()
        {
            GetComponentInParent<DebugUI_MergeList>().SelectMerge(merge);
        }

        public void SetMerge(EMerge merge)
        {
            this.merge = merge;
            GetComponentInChildren<TMP_Text>().text = $"{merge}";
        }
    }
}