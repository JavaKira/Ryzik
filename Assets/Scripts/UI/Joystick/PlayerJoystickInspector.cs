using UnityEngine;

namespace UI.Joystick
{
    public class PlayerJoystickInspector : MonoBehaviour
    {
        [SerializeField] private PlayerBehaviour player;

        private Joystick _joystick;
        private Vector2 _oldJoystickPosition;

        private void Start()
        {
            _joystick = GetComponent<Joystick>();
        }

        private void FixedUpdate()
        {
            if (player != null)
                UpdatePlayer();

            _oldJoystickPosition = _joystick.GetNormalized();
        }

        private void UpdatePlayer()
        {
            player.Move(new Vector2(_joystick.GetNormalized().x, _joystick.GetNormalized().y));
        }
    }
}