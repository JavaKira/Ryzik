using System;
using UnityEngine;
using Random = System.Random;

namespace AI
{
    public class BackgroundCockroachAI : MonoBehaviour
    {
        [SerializeField] private Vector2 bounds;
        [SerializeField] private Vector2 direction;
        [Min(2)]
        [SerializeField] private int speedScatter;
        [SerializeField] private float speedMultiplier = 1;

        private Vector2 _startPosition;
        private Vector2 _currentSpeedMultiplier;
        private Random _random;

        private void Start()
        {
            _startPosition = transform.localPosition;
            _random = new Random();
            Reset();
        }

        private void FixedUpdate()
        {
            var movement = direction * (Time.fixedDeltaTime * _currentSpeedMultiplier);
            transform.Translate(movement.x, movement.y, 0);
            
            if (transform.localPosition.x > bounds.x ||
                transform.localPosition.y > bounds.y)
                Reset();
        }

        private void Reset()
        {
            transform.localPosition = new Vector3(_startPosition.x, _startPosition.y);
            var random = _random.Next(1, speedScatter);
            _currentSpeedMultiplier = new Vector2(random, random);
            _currentSpeedMultiplier *= speedMultiplier;
        }
    }
}