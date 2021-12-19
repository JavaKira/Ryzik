using System;
using UnityEngine;

namespace UI.Joystick
{
    public class PlayerAttackJoystickInspector : MonoBehaviour
    {
        [SerializeField] private PlayerBehaviour player;
        
        private Joystick _joystick;

        private void Start()
        {
            _joystick = GetComponent<Joystick>();
        }

        private void Update()
        {
            if (_joystick.GetNormalized() != Vector2.zero)
                player.Mob.Weapon.Attack();
        }
        
        public void SetPlayer(PlayerBehaviour newPlayer)
        {
            player = newPlayer;
        }
    }
}