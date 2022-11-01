using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class ScoreModel : BaseModel, IScoreModel
{
    public int Score { get; private set; }

    public int Combo { get; private set; }

    public int AddScore { get; set; }

    public int BonusScore { get; set; }


    public void UpdateScore(int score)
    {
        Score = score;
        SetDataAsDirty();
    }

    public void UpdateCombo(int combo)
    {
        Combo = combo;
        SetDataAsDirty();
    }
}
