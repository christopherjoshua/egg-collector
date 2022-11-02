using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine.Events;
using TMPro;

namespace Collector.Score
{

    public class ScoreView : ObjectView<IScoreModel>
    {
        public int AddScore = 50;
        public int BonusScore = 10;
        public UnityAction OnForceAddScore;

        [SerializeField]
        private TMP_Text _scoreText;
        [SerializeField]
        private TMP_Text _comboText;

        protected override void InitRenderModel(IScoreModel model)
        {
            return;
        }

        protected override void UpdateRenderModel(IScoreModel model)
        {
            _scoreText.text = string.Format("{0}", model.Score);
            _comboText.text = model.Combo > 1 ? string.Format("{0} x Combo!", model.Combo) : string.Empty;
            return;
        }

        // test add score is being update
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnForceAddScore.Invoke();
            }
        }
    }
}
