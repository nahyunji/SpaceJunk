using System;
using TMPro;
using UnityEngine;

namespace Universe
{
    public class DebugUI_Resource : ConfiguredMonoBehaviour
    {
        [SerializeField] private UIButton add, addAll;
        [SerializeField] private TMP_InputField input, inputAll;
        [SerializeField] private UIButton resourceKind, resource, merge;
        [SerializeField] private DebugUI_ResourceKindList kindList;
        [SerializeField] private DebugUI_ResourceList resourceList;
        [SerializeField] private DebugUI_MergeList mergeList;

        private EResource curResource = EResource.TRASH;
        private ETrash curTrash = ETrash.BALL;
        private EMerge curMerge = EMerge.DARK_CRYSTAL;

        private void Start()
        {
            add.OnClickAction = AddSource;
            addAll.OnClickAction = AddAllResource;
            resourceKind.OnClickAction = OpenKindList;
            resource.OnClickAction = OpenResourceList;
            merge.OnClickAction = OpenMergeList;
            kindList.OnSelect = SelectKind;
            resourceList.OnSelect = SelectTrash;
            mergeList.OnSelect = SelectMerge;
        }

        private void AddSource()
        {
            var count = new InfNum(Convert.ToDouble(input.text));
            switch (curResource)
            {
                case EResource.TRASH: ResourceUtil.CollectTrash(curTrash, count); break;
                case EResource.RECYCLE: ResourceUtil.AddRecycle(curTrash, count); break;
                case EResource.MERGE: ResourceUtil.AddMerge(curMerge, count); break;
            }
        }

        private void AddAllResource()
        {
            var count = new InfNum(Convert.ToDouble(inputAll.text));
            switch (curResource)
            {
                case EResource.TRASH: ResourceUtil.DebugCollecAllTrash(count); break;
                case EResource.RECYCLE: ResourceUtil.DebugCollecAllRecycle(count); break;
                case EResource.MERGE: ResourceUtil.DebugCollecAllMerge(count); break;
            }
        }

        private void OpenKindList()
        {
            kindList.gameObject.SetActive(!kindList.gameObject.activeInHierarchy);
        }

        private void OpenResourceList()
        {
            resourceList.gameObject.SetActive(!resourceList.gameObject.activeInHierarchy);
        }

        private void OpenMergeList()
        {
            mergeList.gameObject.SetActive(!mergeList.gameObject.activeInHierarchy);
        }

        private void SelectKind(EResource eResource)
        {
            curResource = eResource;
            resourceKind.SetText("{0}", (false, $"{eResource}"));
        }

        private void SelectTrash(ETrash trash)
        {
            curTrash = trash;
            resource.SetText("{0}", (false, $"{trash}"));
        }

        private void SelectMerge(EMerge eMerge)
        {
            curMerge = eMerge;
            merge.SetText("{0}", (false, $"{eMerge}"));
        }
    }
}