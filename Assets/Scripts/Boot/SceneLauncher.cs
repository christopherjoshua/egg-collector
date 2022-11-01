using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public abstract class SceneLauncher<TController, TView> : BaseLauncher<TController, TView>
        where TController : BaseLauncher<TController, TView>
        where TView : View
{
    protected override ILoad GetLoader()
    {
        return SceneLoader.Instance;
    }
    protected override IMain GetMain()
    {
        return GameMain.Instance;
    }
    protected override ISplash GetSplash()
    {
        return SplashScreen.Instance;
    }
}
