using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using static Types;

namespace Collector.Inputs
{
    public class InputsModel : BaseModel
    {
        // default input data
        private Dictionary<Direction, KeyCode> InputDictionary = new Dictionary<Direction, KeyCode>() {
            { Direction.RIGHT, KeyCode.D },
            { Direction.LEFT, KeyCode.A },
            { Direction.UP, KeyCode.W },
            { Direction.DOWN, KeyCode.S },
        };

        public Dictionary<Direction, KeyCode> GetInputsSetting()
        {
            return InputDictionary;
        }

        public void UpdateInputsSetting(Dictionary<Direction, KeyCode> newInputsSetting)
        {
            InputDictionary = newInputsSetting;
        }
    }
}
