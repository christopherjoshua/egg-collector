using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputsEditButtonController : MonoBehaviour
{
    public TMP_Text ButtonText;
    public TMP_Text ButtonDirectionText;
    public void SetText(string newText)
    {
        ButtonText.text = newText;
    }
    public void SetDirectionText(string newText)
    {
        ButtonDirectionText.text = newText;
    }
}
