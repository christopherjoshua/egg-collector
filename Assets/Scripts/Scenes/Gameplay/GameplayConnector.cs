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
            Subscribe<OnGetObjectMessage>(OnGetObject);
        }

        protected override void Disconnect()
        {
            Unsubscribe<OnTimerTimeoutMessage>(OnTimerTimeout);
            Unsubscribe<OnGetObjectMessage>(OnGetObject);
        }

        private void OnTimerTimeout(OnTimerTimeoutMessage message)
        {
            _gameFlow.OnTimeout();
        }

        private void OnGetObject(OnGetObjectMessage message)
        {
            _gameFlow.OnGetObject(message);
        }
    }
}
