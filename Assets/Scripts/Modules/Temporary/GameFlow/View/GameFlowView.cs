using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

namespace Collector.GameFlow
{
    public class GameFlowView : BaseView
    {
        [SerializeField]
        private Button _playAgainButton;
        [SerializeField]
        private Button _exitButton;

        [SerializeField]
        private TMP_Text _scoreText;
        [SerializeField]
        private GameObject _highScoreText;

        [SerializeField]
        private GameObject _gameOverPopup;

        public void SetCallbacks(UnityAction onPlayAgainButton, UnityAction onExitButton)
        {
            _playAgainButton.onClick.RemoveAllListeners();
            _playAgainButton.onClick.AddListener(onPlayAgainButton);
            _exitButton.onClick.RemoveAllListeners();
            _exitButton.onClick.AddListener(onExitButton);
        }

        public void ShowGameOverScreen(int score, bool isHighScore)
        {
            _gameOverPopup.SetActive(true);
            _scoreText.text = string.Format("{0:n0}", score);
            _highScoreText.SetActive(isHighScore);
        }
    }
}