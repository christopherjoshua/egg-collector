using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using static Types;

public class InputsEditorModel : BaseModel, IInputsEditorModel
{
    public Dictionary<Direction, KeyCode> InputsSettings { get; private set; }
    public void UpdateKeySettings(Direction direction, KeyCode keyCode)
    {
        InputsSettings.Remove(direction);
        InputsSettings.Add(direction, keyCode);
        SetDataAsDirty();
    }
    public void SetKeyInputs(Dictionary<Direction, KeyCode> newInputsSettings)
    {
        InputsSettings = newInputsSettings;
        SetDataAsDirty();
    }

}
