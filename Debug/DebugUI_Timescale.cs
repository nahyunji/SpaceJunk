using TMPro;
using UnityEngine;

namespace Universe
{
    public class DebugUI_Timescale : MonoBehaviour
    {
        [SerializeField] private TMP_Text curTimeScaleTex;
        [SerializeField] private UIButton timeScaleMinus;
        [SerializeField] private UIButton timeScalePlus;
        [SerializeField] private UIButton timeSclaeMultMinus;
        [SerializeField] private UIButton timeSclaeMultPlus;
        [SerializeField] private UIButton timeSclaeNormal;

        private void Start()
        {
            timeScaleMinus.OnClickAction = TimeScaleMinus;
            timeScalePlus.OnClickAction = TimeScalePlus;
            timeSclaeMultMinus.OnClickAction = TimeSclaeMultMinus;
            timeSclaeMultPlus.OnClickAction = TimeSclaeMultPlus;
            timeSclaeNormal.OnClickAction = TimeSclaeNormal;
        }

        private void TimeScaleMinus()
        {
            Time.timeScale -= 0.1f;
            UpdateCurTimeScale();
        }

        private void TimeScalePlus()
        {
            Time.timeScale += 0.1f;
            UpdateCurTimeScale();
        }

        private void TimeSclaeMultMinus()
        {
            Time.timeScale *= 0.9f;
            UpdateCurTimeScale();
        }

        private void TimeSclaeMultPlus()
        {
            Time.timeScale *= 1.1f;
            UpdateCurTimeScale();
        }

        private void TimeSclaeNormal()
        {
            Time.timeScale = 1;
            UpdateCurTimeScale();
        }

        private void UpdateCurTimeScale()
        {
            curTimeScaleTex.text = $"TimeScale : {Time.timeScale}";
        }
    }
}