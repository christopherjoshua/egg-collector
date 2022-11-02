using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

namespace Collector.EggGenerator
{
    public class EggGeneratorController : ObjectController<EggGeneratorController, EggGeneratorModel, IEggGeneratorModel, EggGeneratorView>
    {
        public override void SetView(EggGeneratorView view)
        {
            _model.UpdateEggList(new List<EggController>());
            base.SetView(view);
            view.OnTimeToGenerateEgg.AddListener(CreateOrGetEggs);
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
                    eggList[q].SetEggActive(true);
                    eggList[q].SetEggSpeed(Random.Range(0.8f, 1.2f));
                    break;
                }
            }
            if(!reuseEgg)
            {
                EggController newEgg = EggController.Instantiate(_view.EggPrefab, _view.EggContainer);
                newEgg.SetEggActive(true);
                newEgg.SetEggSpeed(Random.Range(0.8f, 1.2f));
                eggList.Add(newEgg);
            }
            _model.UpdateEggList(eggList);
        }
    }
}
