using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using Collector.Boot;
using Collector.Basket;
using Collector.Movement;
using Collector.Score;
using Collector.Timer;

namespace Collector.Gameplay
{
    public class GameplayLauncher : BaseLauncher<GameplayLauncher, GameplayView>
    {
        private BasketController _basket;
        private MovementController _movement;
        private ScoreController _score;
        private TimerController _timer;
        public override string SceneName => "Gameplay";

        protected override ILoad GetLoader()
        {
            return SceneLoader.Instance;
        }

        protected override IMain GetMain()
        {
            return GameMain.Instance;
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return null;
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
               {
                new MovementController(),
                new BasketController(),
                new TimerController(),
                new ScoreController(),
               };
        }

        protected override ISplash GetSplash()
        {
            return SplashScreen.Instance;
        }

        protected override IEnumerator InitSceneObject()
        {
            _movement.SetView(_view.MovementView);
            _basket.SetView(_view.BasketView);
            _timer.SetView(_view.TimerView);
            _score.SetView(_view.ScoreView);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}
