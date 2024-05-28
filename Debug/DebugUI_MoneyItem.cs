using TMPro;
using UnityEngine;

namespace Universe
{
    public class DebugUI_MoneyItem : MonoBehaviour
    {
        private EMoney money;
        private UIButton uiButton;

        private void Start()
        {
            uiButton = GetComponent<UIButton>();
            uiButton.OnClickAction = SelectMoney;
        }

        private void SelectMoney()
        {
            GetComponentInParent<DebugUI_MoneyList>().SelectMoney(money);
        }

        internal void SetMoney(EMoney eMoney)
        {
            money = eMoney;
            GetComponentInChildren<TMP_Text>().text = $"{eMoney}";
        }
    }
}