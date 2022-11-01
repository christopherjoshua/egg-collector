using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public interface IScoreModel : IBaseModel
{
    public int Score { get; }
    public int Combo { get; }

    public int AddScore { get; }
    public int BonusScore { get; }
}
