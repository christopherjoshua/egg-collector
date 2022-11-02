using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using Collector.Inputs;

namespace Collector.Boot
{
    public class GameMain : BaseMain<GameMain>, IMain
    {
        private InputsController _inputsEditor;
        private SaveLoadController _saveLoad;
        protected override IConnector[] GetConnectors()
        {
            return null;
        }

        protected override IController[] GetDependencies()
        {
            return new IController[]
            {
                new InputsController(),
                new SaveLoadController(),
            };
        }

        protected override IEnumerator StartInit()
        {
            yield return null;
        }
    }
}
