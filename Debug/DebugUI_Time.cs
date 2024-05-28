using UnityEngine;
using TMPro;
using System;

namespace Universe
{
    public class DebugUI_Time : ConfiguredMonoBehaviour
    {
        [SerializeField] private TMP_Text curTime;
        [SerializeField] private UIButton secBtn, minBtn, hourBtn, dayBtn, timeReset;
        [SerializeField] private TMP_InputField secInput, minInput, hourInput, dayInput;

        private void OnEnable()
        {
            TimeManager.OnSecondChanged += UpdateCurTime;
        }

        private void OnDisable()
        {
            if (ApplicationQuit) return;
            TimeManager.OnSecondChanged -= UpdateCurTime;
        }

        private void Start()
        {
            secBtn.OnClickAction = AddSec;
            minBtn.OnClickAction = AddMin;
            hourBtn.OnClickAction = AddHour;
            dayBtn.OnClickAction = AddDay;
            timeReset.OnClickAction = TimeManager.DebugResetTime;
        }

        private void UpdateCurTime(DateTime time)
        {
            curTime.text = time.ToString("yyyy-MM-dd\ntth:mm:ss dddd");
        }

        private void AddSec()
        {
            TimeManager.DebugAddSec(float.Parse(secInput.text));
        }

        private void AddMin()
        {
            TimeManager.DebugAddSec(float.Parse(minInput.text) * 60);
        }

        private void AddHour()
        {
            TimeManager.DebugAddHour(float.Parse(hourInput.text));
        }

        private void AddDay()
        {
            TimeManager.DebugAddHour(float.Parse(dayInput.text) * 24);
        }
    }
}