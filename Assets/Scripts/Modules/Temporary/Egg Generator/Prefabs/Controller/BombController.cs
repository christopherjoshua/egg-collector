using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using UnityEngine.Events;
using static Types;

namespace Collector.EggGenerator
{
    public class BombController : EggController
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // on collision, set game object IsActive false
            // and then send message depending on the collider tag

            //OnEggCollided?.Invoke(collision.tag, gameObject.tag);
            if (collision.tag == SafeColliderTag)
            {
                PublishSubscribe.Instance.Publish<OnCollectBombMessage>(new OnCollectBombMessage(false));
            }
            else if (collision.tag == PlayerColliderTag)
            {
                PublishSubscribe.Instance.Publish<OnCollectBombMessage>(new OnCollectBombMessage(true));
            }

            SetEggSpeed(0f);
            SetEggActive(false);
        }
    }
}
