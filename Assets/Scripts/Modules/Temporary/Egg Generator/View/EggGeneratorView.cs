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
        [Header("Game Objects")]
        [SerializeField]
        private EggController _eggPrefab;
        public EggController EggPrefab => _eggPrefab;
        [SerializeField]
        private BombController _bombPrefab;
        public BombController BombPrefab => _bombPrefab;
        [SerializeField]
        private Transform _eggContainer;
        public Transform EggContainer => _eggContainer;


        [Header("Generator Properties")]
        [SerializeField]
        private int _generatorCount;
        public int GeneratorCount => _generatorCount;
        private bool _generatorStarted;

        [Header("Egg Properties")]
        [SerializeField]
        private float _minEggSpeed;
        [SerializeField]
        private float _maxEggSpeed;
        [SerializeField]
        private float _minInitialDelay;
        [SerializeField]
        private float _maxInitialDelay;
        [SerializeField]
        private float _minDelay;
        [SerializeField]
        private float _maxDelay;
        [SerializeField]
        private float _additionalDelay;
        public float MinEggSpeed => _minEggSpeed;
        public float MaxEggSpeed => _maxEggSpeed;
        public float MinInitialDelay => _minInitialDelay;
        public float MaxInitialDelay => _maxInitialDelay;
        public float MinDelay => _minDelay;
        public float MaxDelay => _maxDelay;
        public float AdditionalDelay => _additionalDelay;


        [Header("Bomb Properties")]
        [SerializeField]
        private float _bombPercentRate;
        public float BombPercentRate => _bombPercentRate;

        private List<Coroutine> _generators = new List<Coroutine>();

        public UnityEvent OnTimeToGenerateEgg;

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
            for (int q = 0; q < GeneratorCount; q++)
            {
                float delay = Random.Range(MinInitialDelay, MaxInitialDelay) + (AdditionalDelay * q);
                Coroutine _eggGeneration = StartCoroutine(EggGeneratorCoroutine(delay, () => { OnTimeToGenerateEgg.Invoke(); }));
                _generators.Add(_eggGeneration);
            }
            _generatorStarted = true;
        }

        public void StopGenerators()
        {
            _generatorStarted = false;
            foreach (Coroutine generator in _generators)
            {
                StopCoroutine(generator);
            }
            _generators.Clear();
        }

        private IEnumerator EggGeneratorCoroutine(float delayDuration, UnityAction callback = null)
        {
            float delay = delayDuration;
            while (_generatorStarted)
            {
                yield return new WaitForSeconds(delay);
                delay = Random.Range(MinDelay, MaxDelay);
                callback?.Invoke();
            }
        }
    }
}
