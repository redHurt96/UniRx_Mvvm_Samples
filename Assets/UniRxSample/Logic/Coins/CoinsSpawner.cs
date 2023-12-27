using UnityEngine;
using static UnityEngine.Object;
using static UnityEngine.Random;
using static UnityEngine.Resources;

namespace UniRxSample
{
    public class CoinsSpawner
    {
        private const float WORLD_SIZE = 10f;
        
        public void Spawn()
        {
            GameObject instance = Instantiate(Load("Coin")) as GameObject;
            instance.transform.position = new Vector3(
                Range(-WORLD_SIZE, WORLD_SIZE),
                0f,
                Range(-WORLD_SIZE, WORLD_SIZE));
        }
    }
}