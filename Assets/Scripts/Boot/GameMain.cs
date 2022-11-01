using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class GameMain : BaseMain<GameMain>, IMain
{
    protected override IConnector[] GetConnectors()
    {
        return null;
    }

    protected override IController[] GetDependencies()
    {
        return null;
    }

    protected override IEnumerator StartInit()
    {
        yield return null;
    }
}
