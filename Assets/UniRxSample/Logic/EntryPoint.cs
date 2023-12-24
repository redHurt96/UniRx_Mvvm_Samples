using UnityEngine;

namespace UniRxSample
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private CharacterView _view;
        
        private CharacterController _controller;

        private void Start()
        {
            CharacterModel characterModel = new();
            _controller = new(characterModel);
            _view.SetupModel(characterModel);
        }

        private void Update() => 
            _controller.Update();
    }
}