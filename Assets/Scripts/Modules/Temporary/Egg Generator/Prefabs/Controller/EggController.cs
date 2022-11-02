using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Collector.EggGenerator
{
    public class EggController : MonoBehaviour
    {
        private bool _isActive;
        public bool IsActive => _isActive;
        private float _speed;

        public void SetEggActive(bool isActive)
        {
            _isActive = isActive;
        }
        public void SetEggSpeed(float speed)
        {
            _speed = speed;
        }
        private void Update()
        {
            if (_isActive)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - _speed);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.name.Contains("Limit"))
            {

            }
        }
    }
}
