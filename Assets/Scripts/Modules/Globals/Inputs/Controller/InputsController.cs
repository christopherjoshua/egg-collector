using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using static Types;

namespace Collector.Inputs
{
    public class InputsController : DataController<InputsController, InputsModel>
    {
        private SaveLoadController _saveLoad;
        public Dictionary<Direction, KeyCode> GetInputsSetting()
        {
            if(PlayerPrefs.HasKey("InputsSetting"))
            {
                return _saveLoad.LoadInputDictionary();
            }
            return _model.GetInputsSetting();
        }

        public void UpdateInputsSetting(Dictionary<Direction, KeyCode> newInputsSetting)
        {
            _model.UpdateInputsSetting(newInputsSetting);
            _saveLoad.SaveInputDictionary(newInputsSetting);
        }
    }
}
