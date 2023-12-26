using UnityEngine;

namespace UniRxSample
{
    public class PickupHandler : MonoBehaviour, IModelHandler
    {
        private CharacterModel _characterModel;

        public void SetupModel(CharacterModel characterModel) => 
            _characterModel = characterModel;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PickupView _))
                _characterModel.AddCoin();
        }
    }
}