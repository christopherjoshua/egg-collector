using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using static Types;
using Collector.GameFlow;

namespace Collector.Gameplay
{
    public class GameplayConnector : BaseConnector
    {
        private GameFlowController _gameFlow;
        

        protected override void Connect()
        {
            Subscribe<OnTimerTimeoutMessage>(OnTimerTimeout);
            Subscribe<OnCollectEggMessage>(OnCollectEgg);
            Subscribe<OnCollectBombMessage>(OnCollectBomb);
        }

        protected override void Disconnect()
        {
            Unsubscribe<OnTimerTimeoutMessage>(OnTimerTimeout);
            Unsubscribe<OnCollectEggMessage>(OnCollectEgg);
            Unsubscribe<OnCollectBombMessage>(OnCollectBomb);
        }

        private void OnTimerTimeout(OnTimerTimeoutMessage message)
        {
            _gameFlow.OnTimerTimeout(message);
        }

        private void OnCollectEgg(OnCollectEggMessage message)
        {
            _gameFlow.OnCollectEgg(message);
        }
        private void OnCollectBomb(OnCollectBombMessage message)
        {
            _gameFlow.OnCollectBomb(message);
        }
    }
}
