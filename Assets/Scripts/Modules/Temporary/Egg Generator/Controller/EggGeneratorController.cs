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
            bool createBomb = Random.Range(0, 100) < _view.BombPercentRate;
            List<EggController> eggList = _model.EggList;
            // set small chance to use bomb instead
            for (int q = 0; q < eggList.Count; q++)
            {
                bool isEggBomb = eggList[q].GetComponent<BombController>() == null ? false : true;
                if (!eggList[q].IsActive && createBomb == isEggBomb)
                {
                    reuseEgg = true;
                    eggList[q].SetRandomizePosition();
                    eggList[q].SetEggActive(true);
                    eggList[q].SetEggSpeed(Random.Range(_view.MinEggSpeed, _view.MaxEggSpeed));
                    break;
                }
            }
            if(!reuseEgg)
            {
                EggController newEgg;
                if (createBomb)
                {
                    newEgg = BombController.Instantiate(_view.BombPrefab, _view.EggContainer);
                }
                else
                {
                    newEgg = EggController.Instantiate(_view.EggPrefab, _view.EggContainer);
                }
                newEgg.SetRandomizePosition();
                newEgg.SetEggActive(true);
                newEgg.SetEggSpeed(Random.Range(_view.MinEggSpeed, _view.MaxEggSpeed));
                eggList.Add(newEgg);
            }
            _model.UpdateEggList(eggList);
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
