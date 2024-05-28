using System;
using UnityEngine;

namespace Universe
{
    public class DebugUI_ResourceKindList : MonoBehaviour
    {
        public Action<EResource> OnSelect = delegate { };
        [SerializeField] private UIButton trash, recycle, merge;

        private void Start()
        {
            trash.OnClickAction = ClickTrash;
            recycle.OnClickAction = ClickRecycle;
            merge.OnClickAction = ClickMerge;
        }

        private void ClickTrash()
        {
            OnSelect?.Invoke(EResource.TRASH);
            Close();
        }

        private void ClickRecycle()
        {
            OnSelect?.Invoke(EResource.RECYCLE);
            Close();
        }

        private void ClickMerge()
        {
            OnSelect?.Invoke(EResource.MERGE);
            Close();
        }

        private void Close()
        {
            gameObject.SetActive(false);
        }
    }
}