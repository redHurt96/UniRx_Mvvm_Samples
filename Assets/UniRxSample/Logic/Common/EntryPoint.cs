using System;
using UniRx;
using UnityEngine;

namespace UniRxSample
{
    public class EntryPoint : MonoBehaviour
    {
        private const float SPAWN_TIME = 2f;
        
        [SerializeField] private GameObject _view;
        [SerializeField] private CoinsPanel _coinsPanel;
        [SerializeField] private WalletPanel _walletPanel;
        [SerializeField] private SpendPoint _spendPoint;

        private MoveController _controller;
        private CoinsSpawner _coinsSpawner;
        
        private readonly CompositeDisposable _disposable = new();

        private void Start()
        {
            Model model = new();
            _coinsSpawner = new();
            _controller = new(model);

            foreach (IModelHandler modelHandler in _view.GetComponents<IModelHandler>())
                modelHandler.SetupModel(model);
            
            _coinsPanel.SetupModel(model);
            _walletPanel.SetupModel(model);
            _spendPoint.SetupModel(model);

            Observable.EveryUpdate()
                .Subscribe(_ => _controller.Update())
                .AddTo(_disposable);
            
            Observable
                .Interval(TimeSpan.FromSeconds(SPAWN_TIME))
                .Subscribe(_ => _coinsSpawner.Spawn())
                .AddTo(_disposable);
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }
    }
}