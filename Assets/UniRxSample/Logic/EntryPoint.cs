using UnityEngine;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace UniRxSample
{
    public class EntryPoint : MonoBehaviour
    {
        private const float SPAWN_TIME = 2f;
        
        [SerializeField] private GameObject _view;
        [SerializeField] private CoinsPanel _coinsPanel;

        private CharacterController _controller;
        private CoinsSpawner _coinsSpawner;
        private float _spawnTime;

        private void Start()
        {
            CharacterModel characterModel = new();
            _coinsSpawner = new();
            _controller = new(characterModel);

            foreach (IModelHandler modelHandler in _view.GetComponents<IModelHandler>())
                modelHandler.SetupModel(characterModel);
            
            _coinsPanel.SetupModel(characterModel);
            _spawnTime = SPAWN_TIME;
        }

        private void Update()
        {
            _controller.Update();
            UpdateSpawner();
        }

        private void UpdateSpawner()
        {
            _spawnTime = Max(_spawnTime - deltaTime, 0f);

            if (Approximately(_spawnTime, 0f))
            {
                _coinsSpawner.Spawn();
                _spawnTime = SPAWN_TIME;
            }
        }
    }
}