using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public interface ITimerModel : IBaseModel
{
    public float TimeRemaining { get; }
}
