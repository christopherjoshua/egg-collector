using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using static Types;
using Collector.Inputs;

namespace Collector.InputsEditor
{
    public class InputsEditorController : ObjectController<InputsEditorController, InputsEditorModel, IInputsEditorModel, InputsEditorView>
    {
        private InputsController _inputs;
        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
            _model.SetKeyInputs(_inputs.GetInputsSetting());
        }
        public override void SetView(InputsEditorView view)
        {
            base.SetView(view);
            _view.OnMapKey += OnMapKey;
        }

        public void DisableRemap()
        {
            _view.ExitRemap();
        }

        private void OnMapKey(Direction direction, KeyCode keyCode)
        {
            if (_model.InputsSettings.ContainsKey(direction))
            {
                // check if button is already used, switch them
                if (_model.InputsSettings.ContainsValue(keyCode))
                {
                    KeyCode dupeKeycode = keyCode;
                    Direction dupeDirection = Direction.LEFT;
                    foreach (KeyValuePair<Direction, KeyCode> item in _model.InputsSettings)
                    {
                        if (direction == item.Key)
                        {
                            dupeKeycode = item.Value;
                        }
                        if (keyCode == item.Value)
                        {
                            dupeDirection = item.Key;
                        }
                    }
                    _model.UpdateKeySettings(dupeDirection, dupeKeycode);
                }
                _model.UpdateKeySettings(direction, keyCode);
                _inputs.UpdateInputsSetting(_model.InputsSettings);
            }
        }
    }

}
