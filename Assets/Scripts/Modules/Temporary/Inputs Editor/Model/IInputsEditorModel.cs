using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using static Types;

public interface IInputsEditorModel: IBaseModel
{
    public Dictionary<Direction, KeyCode> InputsSettings { get; }
}
