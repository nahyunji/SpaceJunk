using System;
using System.Collections.Generic;
using UnityEngine;

namespace Universe
{
    public class DebugUI_BuffList : MonoBehaviour
    {
        public Action<EZodiac> OnSelect = delegate { };
        [SerializeField] private Transform content;
        [SerializeField] private DebugUI_BuffItem baseItem;
        private List<DebugUI_BuffItem> items = new();

        private void OnEnable()
        {
            var buffCount = Enum.GetValues(typeof(EZodiac)).Length;
            if (items.Count >= buffCount) return;

            for (int i = 0; i < buffCount; i++)
            {
                var newObj = Instantiate(baseItem, content);
                newObj.gameObject.SetActive(true);
                items.Add(newObj.GetComponent<DebugUI_BuffItem>());
                newObj.SetBuff((EZodiac)i);
            }
        }

        internal void SelectBuff(EZodiac zordiac)
        {
            OnSelect?.Invoke(zordiac);
            gameObject.SetActive(false);
        }
    }
}