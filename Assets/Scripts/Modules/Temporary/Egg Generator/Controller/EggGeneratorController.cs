using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using static Types;
using System.Linq;
using static Collector.EggGenerator.EggGeneratorView;

namespace Collector.EggGenerator
{
    public class EggGeneratorController : ObjectController<EggGeneratorController, EggGeneratorModel, IEggGeneratorModel, EggGeneratorView>
    {
        public override void SetView(EggGeneratorView view)
        {
            _model.UpdateEggList(new List<IEggController>());
            base.SetView(view);
            view.OnTimeToGenerateEgg.AddListener(CreateOrGetEggs);
            view.StartGenerators();
        }
        public void CreateOrGetEggs()
        {
            bool reuseEgg = false;
            List<IEggController> eggList = _model.EggList;
            EggController eggPrefab = GetSelectPrefab(_view.DropObjectList);
            for (int q = 0; q < eggList.Count; q++)
            {
                if (!eggList[q].IsActive && eggPrefab.EggObjectType == eggList[q].EggObjectType)
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
                EggController newEgg = Object.Instantiate(eggPrefab, _view.EggContainer);
                newEgg.SetRandomizePosition();
                newEgg.SetEggActive(true);
                newEgg.SetEggSpeed(Random.Range(_view.MinEggSpeed, _view.MaxEggSpeed));
                eggList.Add(newEgg);
            }
            _model.UpdateEggList(eggList);
        }

        private EggController GetSelectPrefab(List<EggObjectProps> objectPropsList)
        {
            int totalWeight = objectPropsList.Sum(item => { return item.ObjectDropWeight; });
            float weightMultiplierFromPercent = 100 / totalWeight;
            float randomVal = Random.Range(0, totalWeight * weightMultiplierFromPercent);
            float initVal = 0f;
            foreach(EggObjectProps item in objectPropsList)
            {
                float currentWeight = item.ObjectDropWeight * weightMultiplierFromPercent;
                if (randomVal <= initVal + currentWeight)
                {
                    return (EggController)item.ObjectPrefab;
                }
                initVal += currentWeight;
            }
            return null;
        }

        public void StopGenerators()
        {
            List<IEggController> eggList = _model.EggList;
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
