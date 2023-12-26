using UnityEngine;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace UniRxSample
{
    public class SpendPoint : MonoBehaviour
    {
        private const float SPEND_TIME = .5f;
        
        private bool _canSpend;
        private float _spendCooldown;
        private Model _model;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CharacterView _))
                _canSpend = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out CharacterView _))
                _canSpend = false;
        }

        private void Update()
        {
            if (!_canSpend)
                return;

            _spendCooldown = Max(_spendCooldown - deltaTime, 0f);

            if (Approximately(_spendCooldown, 0f) && _model.Coins.Value > 0)
            {
                _model.MoveToWallet();
                _spendCooldown = SPEND_TIME;
            }
        }

        public void SetupModel(Model model) => 
            _model = model;
    }
}