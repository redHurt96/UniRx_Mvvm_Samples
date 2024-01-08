using System;
using UniRx;
using UnityEngine;

namespace UniRxSample
{
    public class SpendPoint : MonoBehaviour
    {
        private const float SPEND_TIME = .5f;
        
        private float _spendCooldown;
        private Model _model;
        private CompositeDisposable _disposable = new();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CharacterView _))
            {
                Observable
                    .Interval(TimeSpan.FromSeconds(SPEND_TIME))
                    .Subscribe(_ => _model.MoveToWallet())
                    .AddTo(_disposable = new());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out CharacterView _))
                _disposable.Dispose();
        }
        
        public void SetupModel(Model model) => 
            _model = model;
    }
}