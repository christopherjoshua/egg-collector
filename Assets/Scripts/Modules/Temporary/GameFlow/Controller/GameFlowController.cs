using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using static Types;
using Collector.Score;
using Collector.EggGenerator;
using Collector.Movement;
using Collector.Boot;
using Collector.Timer;

namespace Collector.GameFlow
{
    public class GameFlowController : ObjectController<GameFlowController, GameFlowView>
    {
        private ScoreController _score;
        private EggGeneratorController _egg;
        private MovementController _movement;
        private SaveLoadController _saveLoad;
        private TimerController _timer;
        public override IEnumerator Finalize()
        {
            return base.Finalize();
        }
        public override void SetView(GameFlowView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnPlayAgainButton, OnExitButton);
        }

        public void OnTimeout()
        {
            _egg.StopGenerators();
            _timer.StopTimer();
            _movement.EndMovements();

            int currentScore = _score.GetScore();
            bool isHighScore = _saveLoad.SaveHighScore(currentScore);
            _view.ShowGameOverScreen(currentScore, isHighScore);
        }

        public void OnGetObject(OnGetObjectMessage message)
        {
            if(message.CatcherType == "Player")
            {
                if (message.ObjectType == "Bomb")
                {
                    OnTimeout();
                }
                else
                {
                    OnScoreUp();
                }
            }
            else if(message.CatcherType == "Limit")
            {
                if (message.ObjectType == "Egg")
                {
                    OnComboDown();
                }
            }
        }

        public void OnScoreUp()
        {
            _score.RaiseScore();
        }

        public void OnComboDown()
        {
            _score.ResetCombo();
        }

        public void OnPlayAgainButton ()
        {
            SceneLoader.Instance.LoadScene("Gameplay");
        }
        public void OnExitButton()
        {
            SceneLoader.Instance.LoadScene("Home");
        }
    }
}
