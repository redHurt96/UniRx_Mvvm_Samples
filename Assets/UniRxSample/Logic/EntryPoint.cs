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
        [SerializeField] private WalletPanel _walletPanel;
        [SerializeField] private SpendPoint _spendPoint;

        private MoveController _controller;
        private CoinsSpawner _coinsSpawner;
        private float _spawnTime;

        private void Start()
        {
            Model model = new();
            _coinsSpawner = new();
            _controller = new(model);

            foreach (IModelHandler modelHandler in _view.GetComponents<IModelHandler>())
                modelHandler.SetupModel(model);
            
            _coinsPanel.SetupModel(model);
            _walletPanel.SetupModel(model);
            _spendPoint.SetupModel(model);
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