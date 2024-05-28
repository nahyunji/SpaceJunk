using System;
using System.Collections.Generic;
using UnityEngine;

namespace Universe
{
    public class DebugUI_MoneyList : MonoBehaviour
    {
        public Action<EMoney> OnSelectMoney = delegate { };
        [SerializeField] private Transform content;
        [SerializeField] private DebugUI_MoneyItem baseItem;
        private List<DebugUI_MoneyItem> items = new();

        public void OnEnable()
        {
            var moneyCount = Enum.GetValues(typeof(EMoney)).Length;
            if (items.Count >= moneyCount) return;

            for (int i = 0; i < moneyCount; i++)
            {
                var newObj = Instantiate(baseItem, content);
                newObj.gameObject.SetActive(true);
                items.Add(newObj.GetComponent<DebugUI_MoneyItem>());
                newObj.SetMoney((EMoney)i + 1);
            }
        }

        public void SelectMoney(EMoney money)
        {
            OnSelectMoney?.Invoke(money);
            gameObject.SetActive(false);
        }
    }
}