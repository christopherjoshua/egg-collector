using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using static Types;
using Collector.Score;
using Collector.EggGenerator;
using Collector.Movement;

namespace Collector.GameFlow
{
    public class GameFlowController : BaseController<GameFlowController>
    {
        private ScoreController _score;
        private EggGeneratorController _egg;
        private MovementController _movement;
        public override IEnumerator Finalize()
        {
            return base.Finalize();
        }

        public void OnTimeout()
        {
            _egg.StopGenerators();
            _movement.EndMovements();
        }

        public void OnGetObject(OnGetObjectMessage message)
        {
            switch (message.ObjectType)
            {
                case "Player":
                    OnScoreUp();
                    break;
                case "Limit":
                    OnComboDown();
                    break;
                default:
                    break;
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
    }
}
