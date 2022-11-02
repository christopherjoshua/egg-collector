using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine.Events;

namespace Collector.EggGenerator
{
    public class EggGeneratorView : ObjectView<IEggGeneratorModel>
    {
        [SerializeField]
        private EggController _eggPrefab;
        public EggController EggPrefab => _eggPrefab;
        [SerializeField]
        private Transform _eggContainer;
        public Transform EggContainer => _eggContainer;

        public UnityEvent OnTimeToGenerateEgg;

        private float timing = 5;
        private float currtime = 5;

        protected override void InitRenderModel(IEggGeneratorModel model)
        {
            return;
        }

        protected override void UpdateRenderModel(IEggGeneratorModel model)
        {
            InitializeEggs(model.EggList);
        }

        private void InitializeEggs(List<EggController> eggList) {
            if(eggList == null || eggList.Count <= 0)
            foreach(EggController egg in eggList)
            {
                if(egg.IsActive && !egg.gameObject.activeSelf)
                {
                    egg.gameObject.SetActive(true);
                }
            }
        }

        private void Update()
        {
            if(currtime <= 0)
            {
                currtime = timing;
                OnTimeToGenerateEgg?.Invoke();
            }
            currtime -= Time.deltaTime;
        }
    }
}
