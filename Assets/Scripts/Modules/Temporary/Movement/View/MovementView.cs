using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using UnityEngine.Events;
using static Types;
using static Utils;

namespace Collector.Movement
{
    public class MovementView : BaseView
    {
        public UnityAction<Direction> OnKeyDirectionPressed;
        private Dictionary<KeyCode, Direction> keyToDirectionDictionary = new Dictionary<KeyCode, Direction>();
        private static KeyCode[] keyCodes = new KeyCode[4];

        public void AttachStoredKeysSetting(Dictionary<Direction, KeyCode> dictionary)
        {
            int index = 0;
            foreach(KeyValuePair<Direction, KeyCode> item in dictionary)
            {
                keyToDirectionDictionary.Add(item.Value, item.Key);
                keyCodes[index] = item.Value;
                index++;
            }
        }

        private void FixedUpdate()
        {
            if (Input.anyKey)
            {
                KeyCode? keyPressed = GetCurrentKeyPressed(keyCodes);
                if(!string.IsNullOrEmpty(keyPressed.ToString()))
                {
                    OnKeyDirectionPressed.Invoke(keyToDirectionDictionary[(KeyCode)keyPressed]);
                }
                return;
            }
        }
    }
}
