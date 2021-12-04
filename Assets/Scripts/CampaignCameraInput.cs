using System;
using UnityEngine;

public class CampaignCameraInput : MonoBehaviour
{
    private void Update()
    {
        if (Input.touchCount == 0) return;

        var touch = Input.GetTouch(Input.touchCount - 1);
        transform.position -= new Vector3(touch.deltaPosition.x * touch.deltaTime, touch.deltaPosition.y * touch.deltaTime);
    }
}