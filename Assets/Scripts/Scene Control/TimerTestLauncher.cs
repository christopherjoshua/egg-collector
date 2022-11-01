using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class TimerTestLauncher : SceneLauncher<TimerTestLauncher, TimerTestView>
{

    private TimerController _timer;
    private ScoreController _score;
    public override string SceneName => "TimerTest";

    protected override IConnector[] GetSceneConnectors()
    {
        return null;
    }

    protected override IController[] GetSceneDependencies()
    {
        return new IController[]
        {
            new TimerController(),
            new ScoreController(),
        };
    }

    protected override IEnumerator InitSceneObject()
    {
        yield return null;
        _timer.SetView(_view.TimerView);
        _score.SetView(_view.ScoreView);
    }

    protected override IEnumerator LaunchScene()
    {
        yield return null;
    }
}
