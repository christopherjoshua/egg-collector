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

        public void OnCollectEgg(OnCollectEggMessage message)
        {
            if (message.Success)
            {
                OnScoreUp();
            }
            else
            {
                OnComboDown();
            }
        }

        public void OnCollectBomb(OnCollectBombMessage message)
        {
            if(message.Success)
            {
                OnGameOver();
            }
        }
        public void OnTimerTimeout(OnTimerTimeoutMessage message)
        {
            OnGameOver();
        }

        private void OnScoreUp()
        {
            _score.RaiseScore();
        }

        private void OnComboDown()
        {
            _score.ResetCombo();
        }

        private void OnGameOver()
        {
            _egg.StopGenerators();
            _timer.StopTimer();
            _movement.EndMovements();

            int currentScore = _score.GetScore();
            bool isHighScore = _saveLoad.SaveHighScore(currentScore);
            _view.ShowGameOverScreen(currentScore, isHighScore);
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
