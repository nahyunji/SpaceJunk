using TMPro;
using UnityEngine;

namespace Universe
{
    public class DebugUI_Buff : ConfiguredMonoBehaviour
    {
        [SerializeField] private UIButton add, addAll, selBtn;
        [SerializeField] private TMP_InputField input;
        [SerializeField] private DebugUI_BuffList list;
        private EZodiac selZordiac = EZodiac.GEMINI;

        private void Start()
        {
            add.OnClickAction = AddBuff;
            addAll.OnClickAction = AddAllBuff;
            selBtn.OnClickAction = OpenZordiacList;
            list.OnSelect += SelectVegetable;
        }

        private void OpenZordiacList()
        {
            list.gameObject.SetActive(!list.gameObject.activeInHierarchy);
        }

        private void SelectVegetable(EZodiac zordiac)
        {
            selZordiac = zordiac;
            selBtn.SetText("{0}", (true, $"{zordiac}"));
        }

        private void AddBuff()
        {
            BuffUtil.Add(selZordiac, int.Parse(input.text), true);
        }

        private void AddAllBuff()
        {
            BuffUtil.DebugAddAll(int.Parse(input.text));
        }
    }
}