using UnityEngine;

namespace UniRxSample
{
    public class PickupHandler : MonoBehaviour, IModelHandler
    {
        private Model _model;

        public void SetupModel(Model model) => 
            _model = model;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PickupView pickupView))
            {
                _model.AddCoin();
                Destroy(pickupView.gameObject);
            }
        }
    }
}