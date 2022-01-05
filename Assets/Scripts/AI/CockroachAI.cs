using System;
using Content;
using UnityEngine;

namespace AI
{
    public class CockroachAI : MonoBehaviour
    {
        [SerializeField] private Mob targetMobType;
        
        private Mob _target;
        private bool _targetInBounds;

        private void FixedUpdate()
        {
            if (!_targetInBounds) return;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var target = other.gameObject.GetComponent<Mob>();
            if (target == null || !target.name.Equals(targetMobType.name)) return;
            _targetInBounds = true;
            _target = target;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var target = other.gameObject.GetComponent<Mob>();
            if (target != null && target.Equals(_target))
                _targetInBounds = false;
        }
    }
}