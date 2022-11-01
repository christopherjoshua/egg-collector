using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class TimerController : ObjectController<TimerController, TimerModel, ITimerModel, TimerView>
{
    public override void SetView(TimerView view)
    {
        base.SetView(view);
        _model.SetTime(view.InitialTime);
        view.OnTimeUpdated += UpdateTime;
        view.IsStarted = true;
    }

    private void UpdateTime(float deltaTime)
    {
        float remainingTime = _model.TimeRemaining - deltaTime;
        if(remainingTime <= 0)
        {
            remainingTime = 0;
            GameTimeout();
            _view.IsStarted = false;
        }
        _model.SetTime(remainingTime);
    }

    private void GameTimeout()
    {
        Publish<TimerTimeOutMessage>(new TimerTimeOutMessage());
    }

    public struct TimerTimeOutMessage
    {

    }
}
