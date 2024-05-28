using Local.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Universe
{
    [CreateAssetMenu(menuName = "Scriptables/PopupData/PopupData")]
    public class LabPopupData : ScriptableObject
    {
        public List<LabPopup> popups = new();

        public LabPopup GetPopup(EPopup popup)
        {
            return popups.Find(x => x.ePopup == popup);
        }
    }
}