using UnityEngine;

namespace UniRxSample
{
    public class CharacterController
    {
        private readonly CharacterModel _model;

        public CharacterController(CharacterModel model) => 
            _model = model;

        public void Update()
        {
            Vector3 input = new Vector3(
                Input.GetAxis("Horizontal"),
                0f,
                Input.GetAxis("Vertical"));

            if (input != Vector3.zero)
                _model.Move(input.normalized);
        }
    }
}