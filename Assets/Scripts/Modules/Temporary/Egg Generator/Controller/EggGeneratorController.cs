using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using static Types;

namespace Collector.EggGenerator
{
    public class EggGeneratorController : ObjectController<EggGeneratorController, EggGeneratorModel, IEggGeneratorModel, EggGeneratorView>
    {
        public override void SetView(EggGeneratorView view)
        {
            _model.UpdateEggList(new List<EggController>());
            base.SetView(view);
            view.OnTimeToGenerateEgg.AddListener(CreateOrGetEggs);
            view.StartGenerators();
        }

        public void CreateOrGetEggs()
        {
            bool reuseEgg = false;
            List<EggController> eggList = _model.EggList;
            for (int q = 0; q < eggList.Count; q++)
            {
                if(!eggList[q].IsActive)
                {
                    reuseEgg = true;
                    eggList[q].SetRandomizePosition();
                    eggList[q].SetEggActive(true);
                    eggList[q].SetEggSpeed(Random.Range(2f, 2.5f));
                    break;
                }
            }
            if(!reuseEgg)
            {
                EggController newEgg = EggController.Instantiate(_view.EggPrefab, _view.EggContainer);
                newEgg.SetRandomizePosition();
                newEgg.SetEggActive(true);
                newEgg.SetEggSpeed(Random.Range(2f, 2.5f));
                newEgg.OnEggCollided.AddListener(SendCollidedMessage);
                eggList.Add(newEgg);
            }
            _model.UpdateEggList(eggList);
        }

        public void SendCollidedMessage(string type)
        {
            Publish<OnGetObjectMessage>(new OnGetObjectMessage(type));
        }

        public void StopGenerators()
        {
            List<EggController> eggList = _model.EggList;
            for (int q = 0; q < eggList.Count; q++)
            {
                eggList[q].SetEggActive(false);
            }
            eggList.Clear();
            _model.UpdateEggList(eggList);
            _view.StopGenerators();
        }
    }
}
