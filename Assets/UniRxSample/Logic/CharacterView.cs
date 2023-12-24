using UniRx;
using UnityEngine;

namespace UniRxSample
{
    public class CharacterView : MonoBehaviour
    {
        private CharacterModel _characterModel;

        public void SetupModel(CharacterModel characterModel)
        {
            _characterModel = characterModel;
            _characterModel.Position.Subscribe(UpdatePosition);
        }

        private void UpdatePosition(Vector3 value) => 
            transform.position = value;
    }
}