using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class TimerModel : BaseModel, ITimerModel
{
    public float TimeRemaining { get; private set; }

    public void SetTime(float time)
    {
        TimeRemaining = time;
        SetDataAsDirty();
    }
}
