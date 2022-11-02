using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using Collector.Basket;
using Collector.Movement;
using Collector.Score;
using Collector.Timer;
using Collector.EggGenerator;

namespace Collector.Gameplay
{
    public class GameplayView : BaseView
    {
        public BasketView BasketView;
        public EggGeneratorView EggGeneratorView;
        public MovementView MovementView;
        public TimerView TimerView;
        public ScoreView ScoreView;
    }
}