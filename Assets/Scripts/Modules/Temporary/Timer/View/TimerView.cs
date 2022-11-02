using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine.Events;
using TMPro;

namespace Collector.Timer
{
    public class TimerView : ObjectView<ITimerModel>
    {
        [SerializeField]
        private TMP_Text _timerText;

        public bool IsStarted;

        public float InitialTime;

        public UnityAction<float> OnTimeUpdated;

        protected override void InitRenderModel(ITimerModel model)
        {
            return;
        }

        protected override void UpdateRenderModel(ITimerModel model)
        {
            int remainingTimeInt = (int)Mathf.Ceil(model.TimeRemaining);
            _timerText.text = string.Format("{0}{1}", remainingTimeInt / 10, remainingTimeInt % 10);
            return;
        }

        private void Update()
        {
            if (IsStarted)
            {
                OnTimeUpdated.Invoke(Time.deltaTime);
            }
        }
    }
}