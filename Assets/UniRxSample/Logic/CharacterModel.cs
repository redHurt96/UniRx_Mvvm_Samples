using System;
using UniRx;
using UnityEngine;

namespace UniRxSample
{
    public class CharacterModel
    {
        public const float WORLD_SIZE = 30f;
        public const float SPEED = 5f;

        public ReactiveProperty<Vector3> Position { get; }

        public CharacterModel()
        {
            Position = new(Vector3.zero);
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
    }
}
