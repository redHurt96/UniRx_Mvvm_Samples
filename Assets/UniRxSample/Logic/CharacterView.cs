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
            _model.Updated += UpdatePosition;
        }

        private void OnDestroy() => 
            _model.Updated -= UpdatePosition;

        private void UpdatePosition() => 
            _rigidbody.MovePosition(_model.Position);
    }
}