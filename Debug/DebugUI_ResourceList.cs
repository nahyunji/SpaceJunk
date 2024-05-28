using System;
using System.Collections.Generic;
using UnityEngine;

namespace Universe
{
    public class DebugUI_ResourceList : MonoBehaviour
    {
        public Action<ETrash> OnSelect = delegate { };
        [SerializeField] private Transform content;
        [SerializeField] private DebugUI_ResourceItem baseItem;
        private List<DebugUI_ResourceItem> items = new();

        private void OnEnable()
        {
            var resourceCount = Enum.GetValues(typeof(ETrash)).Length;
            if (items.Count >= resourceCount) return;

            for (int i = 0; i < resourceCount; i++)
            {
                var newObj = Instantiate(baseItem, content);
                newObj.gameObject.SetActive(true);
                items.Add(newObj.GetComponent<DebugUI_ResourceItem>());
                newObj.SetResource((ETrash)i);
            }
        }

        public void SelectResource(ETrash trash)
        {
            OnSelect?.Invoke(trash);
            gameObject.SetActive(false);
        }
    }
}