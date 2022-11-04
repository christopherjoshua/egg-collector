using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using static Types;

namespace Collector.Timer
{

    public class TimerController : ObjectController<TimerController, TimerModel, ITimerModel, TimerView>
    {
        public override void SetView(TimerView view)
        {
            base.SetView(view);
            StartTimer();
            view.OnTimeUpdated += UpdateTime;
        }

        private void UpdateTime(float deltaTime)
        {
            float remainingTime = _model.TimeRemaining - deltaTime;
            if (remainingTime <= 0)
            {
                remainingTime = 0;
                GameTimeout();
                _view.IsStarted = false;
            }
            _model.SetTime(remainingTime);
        }

        public void StopTimer()
        {
            _model.SetTime(0f);
            _view.IsStarted = false;
        }
        public void StartTimer()
        {
            _model.SetTime(_view.InitialTime);
            _view.IsStarted = true;
        }

        private void GameTimeout()
        {
            Publish<OnTimerTimeoutMessage>(new OnTimerTimeoutMessage());
            StopTimer();
        }
    }
}