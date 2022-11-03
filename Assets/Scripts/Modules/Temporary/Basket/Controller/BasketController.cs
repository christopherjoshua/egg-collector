using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using Collector.Movement;
using static Types;
using Collector.Inputs;

namespace Collector.Basket
{
    public class BasketController : ObjectController<BasketController, BasketView>
    {
        private MovementController _movement;
        private InputsController _inputs;

        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
        }

        public override void SetView(BasketView view)
        {
            base.SetView(view);
            InitMovement();
        }

        private void InitMovement()
        {
            _movement.OnKeyDirectionPressed += ((Direction direction) =>
            {
                switch (direction)
                {
                    case Direction.LEFT:
                        _view.OnDirectionKeyPressed(Direction.LEFT);
                        break;
                    case Direction.RIGHT:
                        _view.OnDirectionKeyPressed(Direction.RIGHT);
                        break;
                    default:
                        break;
                }
            });
            _view.InitializeLimit(_inputs.GetInputsSetting());
        }
    }
}
