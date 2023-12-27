using UniRx;
using UnityEngine;

namespace UniRxSample
{
    public class Model
    {
        private const float WORLD_SIZE = 30f;
        private const float SPEED = 8f;

        public ReactiveProperty<Vector3> Position { get; }
        public ReactiveProperty<int> Coins { get; }
        public ReactiveProperty<int> Wallet { get; }

        public Model()
        {
            Position = new(Vector3.zero);
            Coins = new(0);
            Wallet = new(0);
        }

        public void Move(Vector3 direction)
        {
            Vector3 delta = SPEED * Time.deltaTime * direction;
            Vector3 desiredPosition = Position.Value + delta;

            if (Mathf.Abs(desiredPosition.x) < WORLD_SIZE
                && Mathf.Abs(desiredPosition.z) < WORLD_SIZE)
            {
                Position.Value = desiredPosition;
            }
        }

        public void AddCoin() => 
            Coins.Value++;

        public void MoveToWallet()
        {
            if (Coins.Value > 0)
            {
                Coins.Value--;
                Wallet.Value++;
            }
        }
    }
}
