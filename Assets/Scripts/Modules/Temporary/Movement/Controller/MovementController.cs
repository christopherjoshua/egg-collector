using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Agate.MVC.Base;
using UnityEngine.Events;
using static Types;
using Collector.Inputs;

namespace Collector.Movement
{
    public class MovementController : ObjectController<MovementController, MovementView>
    {
        public UnityAction<Direction> OnKeyDirectionPressed;
        private InputsController _inputs;

        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
        }

        public override void SetView(MovementView view)
        {
            base.SetView(view);
            InitMovements();
        }
        private void InitMovements()
        {
            // get left key and right key and attach listener
            _view.AttachStoredKeysSetting(_inputs.GetInputsSetting());
            // invoke will be got from basket
            // basket will need inherit this
            _view.OnKeyDirectionPressed += (Direction direction) => OnKeyDirectionPressed.Invoke(direction);
        }
    }
}