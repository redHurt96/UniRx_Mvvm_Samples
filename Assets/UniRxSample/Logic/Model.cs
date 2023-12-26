using System;
using UniRx;
using UnityEngine;

namespace UniRxSample
{
    public class Model
    {
        private const float WORLD_SIZE = 30f;
        private const float SPEED = 8f;

        public event Action Updated;
        
        public Vector3 Position { get; private set; }
        public int Coins { get; private set; }
        public int Wallet { get; private set; }

        public void Move(Vector3 direction)
        {
            Vector3 delta = SPEED * Time.deltaTime * direction;
            Vector3 desiredPosition = Position + delta;

            if (Mathf.Abs(desiredPosition.x) < WORLD_SIZE
                && Mathf.Abs(desiredPosition.z) < WORLD_SIZE)
            {
                Position = desiredPosition;
                Updated?.Invoke();
            }
        }

        public void AddCoin()
        {
            Coins++;
            Updated?.Invoke();
        }

        public void MoveToWallet()
        {
            if (Coins > 0)
            {
                Coins--;
                Wallet++;
                Updated?.Invoke();
            }
        }
    }
}
