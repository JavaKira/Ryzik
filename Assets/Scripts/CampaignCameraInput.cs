using System;
using UnityEngine;

public class CampaignCameraInput : MonoBehaviour
{
    [SerializeField] private Vector2 xBounds;
    [SerializeField] private float speedMultiplier;

    private float _oldX;

    private void Update()
    {
        if (Input.touchCount == 0) return;

        var touch = Input.GetTouch(Input.touchCount - 1);
        
        transform.position += new Vector3(-touch.deltaPosition.x * Time.deltaTime, 0) * speedMultiplier;

        if (transform.position.x < xBounds.x)
            StopCameraMove();

        if (transform.position.x > xBounds.y)
            StopCameraMove();
        
        _oldX = transform.position.x;
    }

    private void StopCameraMove()
    {
        transform.position = new Vector3(_oldX, transform.position.y, transform.position.z);
    }
}