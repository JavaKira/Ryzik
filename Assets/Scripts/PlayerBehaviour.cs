using System;
using Content;
using UI;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Vector3 _oldPosition;

    public Vector2 Speed => _oldPosition - transform.position;

    public void Move(Vector2 direction)
    {
        _oldPosition = transform.position;
        
        var moveDirectionForce = new Vector3(direction.x, direction.y , 0.0f);
        moveDirectionForce *= speed;

        transform.Translate(moveDirectionForce * Time.fixedDeltaTime);
    }
}
