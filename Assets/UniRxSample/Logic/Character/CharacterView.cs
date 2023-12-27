using UniRx;
using UnityEngine;

namespace UniRxSample
{
    public class CharacterView : MonoBehaviour, IModelHandler
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        private Model _model;

        public void SetupModel(Model model)
        {
            _model = model;
            _model.Position.Subscribe(UpdatePosition);
        }

        private void UpdatePosition(Vector3 value) => 
            _rigidbody.MovePosition(value);
    }
}