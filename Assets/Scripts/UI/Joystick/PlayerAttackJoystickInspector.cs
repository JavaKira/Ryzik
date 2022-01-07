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
            
            if (_joystick.GetNormalized().x > 0)
                player.SetFlip(true);
            else if (_joystick.GetNormalized().x < 0)
                player.SetFlip(false);
        }
        
        public void SetPlayer(PlayerBehaviour newPlayer)
        {
            player = newPlayer;
        }
    }
}