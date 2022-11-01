using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class ScoreController : ObjectController<ScoreController, ScoreModel, IScoreModel, ScoreView>
{
    public override void SetView(ScoreView view)
    {
        base.SetView(view);
        _model.UpdateScore(0);
        _model.UpdateCombo(0);
        // Set how much to add score and the bonus per combo
        _model.AddScore = _view.AddScore;
        _model.BonusScore = _view.BonusScore;
        _view.OnForceAddScore += UpdateScore;
    }

    public void UpdateScore()
    {
        // get the current score, 
        // add addscore value
        // add bonusscore multiplied by combo count
        // add combo by 1

        int score = _model.Score;
        int combo = _model.Combo;

        score += _model.AddScore + (combo * _model.BonusScore);
        _model.UpdateCombo(combo + 1);
        _model.UpdateScore(score);
    }
}
