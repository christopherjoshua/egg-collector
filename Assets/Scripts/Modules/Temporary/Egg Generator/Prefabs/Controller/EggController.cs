using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using UnityEngine.Events;

namespace Collector.EggGenerator
{
    public class EggController : MonoBehaviour
    {
        private bool _isActive;
        public bool IsActive => _isActive;
        private float _speed;
        public float Speed => _speed;
        private Transform _parent;
        public Transform Parent => _parent ?? transform.parent;

        public UnityEvent<string, string> OnEggCollided;

        public List<string> TagCollidable;

        public void SetRandomizePosition()
        {
            RectTransform parentRect = Parent.GetComponent<RectTransform>();
            transform.localPosition = new Vector2(Random.Range(parentRect.rect.xMin, parentRect.rect.xMax), Random.Range(parentRect.rect.yMin, parentRect.rect.yMax));
        }

        public void SetEggActive(bool isActive)
        {
            _isActive = isActive;
            gameObject.SetActive(isActive);
        }
        public void SetEggSpeed(float speed)
        {
            _speed = speed;
        }
        private void FixedUpdate()
        {
            if (IsActive)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - Speed);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // on collision, set game object IsActive false
            // and then send message depending on the collider tag
            if (!TagCollidable.Contains(collision.tag))
                return;
            OnEggCollided?.Invoke(collision.tag, gameObject.tag);

            SetEggSpeed(0f);
            SetEggActive(false);
        }
    }
}
