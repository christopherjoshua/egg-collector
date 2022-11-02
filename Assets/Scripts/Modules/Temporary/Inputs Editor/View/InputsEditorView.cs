using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using static Types;
using static Utils;
using UnityEngine.UI;
using System;
using System.Linq;
using UnityEngine.Events;
using TMPro;

public class InputsEditorView : ObjectView<IInputsEditorModel>
{

    [SerializeField]
    private Button _upButton;
    [SerializeField]
    private Button _downButton;
    [SerializeField]
    private Button _leftButton;
    [SerializeField]
    private Button _rightButton;

    [SerializeField]
    private TMP_Text _guideText;

    private Dictionary<Direction, Button> _directionButtonsDictionary = new Dictionary<Direction, Button>();

    public UnityAction<Direction, KeyCode> OnMapKey;

    private bool IsRemapKey = false;
    private Direction MapKeyDirection;

    private static readonly KeyCode[] keyCodes = Enum.GetValues(typeof(KeyCode))
                                                 .Cast<KeyCode>()
                                                 .Where(k => ((int)k < (int)KeyCode.Mouse0))
                                                 .ToArray();

    protected override void InitRenderModel(IInputsEditorModel model)
    {
        _directionButtonsDictionary.Add(Direction.DOWN, _downButton);
        _directionButtonsDictionary.Add(Direction.UP, _upButton);
        _directionButtonsDictionary.Add(Direction.RIGHT, _rightButton);
        _directionButtonsDictionary.Add(Direction.LEFT, _leftButton);
        return;
    }

    protected override void UpdateRenderModel(IInputsEditorModel model)
    {
        InitializeButtons(model.InputsSettings);
    }

    public void InitializeButtons(Dictionary<Direction, KeyCode> inputsSetting)
    {
        foreach(KeyValuePair<Direction, Button> item in _directionButtonsDictionary)
        {
            item.Value.onClick.RemoveAllListeners();
            InputsEditButtonController buttonController = item.Value.GetComponent<InputsEditButtonController>();
            buttonController.SetText(inputsSetting[item.Key].ToString());
            buttonController.SetDirectionText(item.Key.ToString());
            item.Value.onClick.AddListener(() => { StartRemapProcess(item.Key); });
        }
    }

    public void StartRemapProcess(Direction direction)
    {
        if (IsRemapKey)
        {
            ExitRemap();
            return;
        }
        IsRemapKey = true;
        _guideText.text = string.Format("Press new key for {0} button", direction.ToString());
        MapKeyDirection = direction;
    }
    public void ExitRemap()
    {
        IsRemapKey = false;
        _guideText.text = string.Format("Select a key to change");
    }

    private void Update()
    {
        if(IsRemapKey)
        {
            // get the key being pressed
            if (Input.anyKey)
            {
                KeyCode? keyPressed = GetCurrentKeyPressed(keyCodes);
                if(string.IsNullOrEmpty(keyPressed.ToString()))
                {
                    ExitRemap();
                    return;
                }
                OnMapKey?.Invoke(MapKeyDirection, (KeyCode)keyPressed);
                ExitRemap();
                Debug.Log(string.Format("Remapping {0} to {1}", MapKeyDirection.ToString(), keyPressed.ToString()));
            }
        }
    }
}
