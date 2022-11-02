using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using static Types;
using System;
using System.Linq;

namespace Collector.Basket
{
    public class BasketView : BaseView
    {
        [SerializeField]
        private BasketObjectController _basketObject;
        [SerializeField]
        private float _baseSpeed = 1;

        private List<float> _speedList = new List<float>();

        public void OnDirectionKeyPressed(Direction direction)
        {
            int _targetDirection = ((int)direction - 1) * -1;
            _basketObject.transform.position = new Vector2(_basketObject.transform.position.x + (_targetDirection * _speedList[(int)direction]), _basketObject.transform.position.y);
        }

        public void InitializeLimit(Dictionary<Direction, KeyCode> dictionary)
        {
            foreach(Direction direction in Enum.GetValues(typeof(Direction)).Cast<Direction>())
            {
                _speedList.Add(_baseSpeed);
            }
            _basketObject.OnCollideWithLimit.AddListener(DisableDirection);
            _basketObject.OnExitCollideWithLimit.AddListener(EnableDirection);
        }

        private void DisableDirection(Direction direction)
        {
            _speedList[(int)direction] = 0;
        }
        private void EnableDirection()
        {
            for(int q = 0; q < _speedList.Count; q++)
            {
                _speedList[q] = _baseSpeed;
            }
        }
    }
}

