using UnityEngine;

namespace UI.Joystick
{
    public class EditorCameraJoystickInspector : MonoBehaviour
    {
        [SerializeField] private GameObject cameraPoint;
        [SerializeField] private float speedMultiplier;

        private Joystick _joystick;

        private void Awake()
        {
            _joystick = GetComponent<Joystick>();
        }

        private void FixedUpdate()
        {
            UpdateCameraPoint();
        }

        private void UpdateCameraPoint()
        {
            var pos = _joystick.GetNormalized() * (speedMultiplier * Time.deltaTime);
            cameraPoint.transform.position += new Vector3(pos.x, pos.y, 0);
        }
    }
}