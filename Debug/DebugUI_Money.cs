using System;
using TMPro;
using UnityEngine;

namespace Universe
{
    public class DebugUI_Money : ConfiguredMonoBehaviour
    {
        [SerializeField] private UIButton selMoneyBnt;
        [SerializeField] private DebugUI_MoneyList moneyList;
        [SerializeField] private TMP_InputField input, input_all;
        [SerializeField] private UIButton add, addAll;
        private EMoney selMoney = EMoney.GOLD;

        private void Start()
        {
            selMoneyBnt.OnClickAction = OpenMoneyList;
            add.OnClickAction = AddMoney;
            addAll.OnClickAction = AddAllMoney;
            moneyList.OnSelectMoney = SelectMoney;
        }

        private void OpenMoneyList()
        {
            moneyList.gameObject.SetActive(!moneyList.gameObject.activeInHierarchy);
        }

        private void SelectMoney(EMoney money)
        {
            selMoney = money;
            selMoneyBnt.SetText("{0}", (false, $"{money}"));
        }

        private void AddMoney()
        {
            MoneyUtil.Add(selMoney, Convert.ToDouble(input.text), true);
        }

        private void AddAllMoney()
        {
            MoneyUtil.DebugAddAll(Convert.ToDouble(input_all.text));
        }
    }
}