using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Utils
{
    public static KeyCode? GetCurrentKeyPressed(KeyCode[] keyCodes)
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKey(keyCodes[i]))
            {
                return keyCodes[i];
            }
        }
        return null;
    }
}
