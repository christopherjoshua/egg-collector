using Collector.EggGenerator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Types;

namespace Collector.Basket
{
    public class BasketObjectController : MonoBehaviour
    {
        public UnityEvent<Direction> OnCollideWithLimit;
        public UnityEvent OnExitCollideWithLimit;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.name.Contains("Limit"))
                return;
            bool isCollidedLeft = collision.GetComponent<Collider2D>().transform.position.x < gameObject.transform.position.x;
            if (isCollidedLeft)
            {
                OnCollideWithLimit?.Invoke(Direction.LEFT);
            }
            else
            {
                OnCollideWithLimit?.Invoke(Direction.RIGHT);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            OnExitCollideWithLimit?.Invoke();
        }
    }
}