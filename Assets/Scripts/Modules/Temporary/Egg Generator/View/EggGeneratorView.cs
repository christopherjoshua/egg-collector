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

        private List<Coroutine> _generators = new List<Coroutine>();

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
            foreach(EggController egg in eggList)
            {
                if(egg.IsActive && !egg.gameObject.activeSelf)
                {
                    egg.gameObject.SetActive(true);
                }
            }
        }

        public void StartGenerators()
        {
            for (int q = 0; q < 3; q++)
            {
                float delay = Random.Range(1.5f, 3f);
                Coroutine _eggGeneration = StartCoroutine(EggGeneratorCoroutine(delay, () => { OnTimeToGenerateEgg.Invoke(); }));
                _generators.Add(_eggGeneration);
            }
        }

        public void StopGenerators()
        {
            foreach(Coroutine generator in _generators)
            {
                StopCoroutine(generator);
            }
            _generators.Clear();
        }

        private IEnumerator EggGeneratorCoroutine(float delayDuration, UnityAction callback = null)
        {
            float delay = delayDuration;
            while (true)
            {
                yield return new WaitForSeconds(delay);
                delay = Random.Range(1.5f, 3f);
                callback?.Invoke();
            }
        }
    }
}
