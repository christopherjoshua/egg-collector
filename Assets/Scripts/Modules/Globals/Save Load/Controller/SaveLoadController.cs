using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using static Types;

public class SaveLoadController : DataController<SaveLoadController, SaveLoadModel>
{
    public Dictionary<Direction, KeyCode> LoadInputDictionary()
    {
        return _model.LoadInputDictionary();
    }
    public void SaveInputDictionary(Dictionary<Direction, KeyCode> dictionary)
    {
        _model.SaveInputDictionary(dictionary);
    }
}
