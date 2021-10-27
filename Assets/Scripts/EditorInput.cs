using System;
using UnityEngine;

public class EditorInput : MonoBehaviour
{
    [SerializeField] private GameObject cameraPoint;
    [SerializeField] private float moveSpeed;
    private void FixedUpdate()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.W)) Move(Vector2.up);
        
        if (Input.GetKey(KeyCode.S)) Move(Vector2.down);
        
        if (Input.GetKey(KeyCode.A)) Move(Vector2.left);
        
        if (Input.GetKey(KeyCode.D)) Move(Vector2.right);
    }

    private void Move(Vector3 direction)
    {
        cameraPoint.transform.position += direction * (moveSpeed * Time.fixedDeltaTime);
    }
}