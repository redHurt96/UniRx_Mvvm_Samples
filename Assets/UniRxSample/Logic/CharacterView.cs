using UnityEngine;

namespace UniRxSample
{
    public class CharacterView : MonoBehaviour
    {
        private CharacterModel _characterModel;

        public void SetupModel(CharacterModel characterModel)
        {
            _characterModel = characterModel;
            _characterModel.PositionChanged += UpdatePosition;
        }

        private void UpdatePosition() => 
            transform.position = _characterModel.Position;
    }
}