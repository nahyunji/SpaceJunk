using System;
using System.Collections.Generic;
using UnityEngine;

namespace Universe
{
    public class DebugUI_MergeList : MonoBehaviour
    {
        public Action<EMerge> OnSelect = delegate { };
        [SerializeField] private Transform content;
        [SerializeField] private DebugUI_MergeItem baseItem;
        private List<DebugUI_MergeItem> items = new();

        private void OnEnable()
        {
            var mergeCount = Enum.GetValues(typeof(EMerge)).Length;
            if (items.Count >= mergeCount) return;

            for (int i = 0; i < mergeCount; i++)
            {
                var newObj = Instantiate(baseItem, content);
                newObj.gameObject.SetActive(true);
                items.Add(newObj.GetComponent<DebugUI_MergeItem>());
                newObj.SetMerge((EMerge)i);
            }
        }

        internal void SelectMerge(EMerge merge)
        {
            OnSelect?.Invoke(merge);
            gameObject.SetActive(false);
        }
    }
}