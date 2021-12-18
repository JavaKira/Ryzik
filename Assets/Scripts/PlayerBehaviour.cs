using System;
using Content;
using UI;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour Instance;
    
    [SerializeField] private float speed;
    
    private Vector3 _oldPosition;
    private Mob _player;

    public Vector2 Speed => _oldPosition - transform.position;
    public Mob Mob => _player;

    private void Awake()
    {
        Instance = this;
        var mainCamera = Camera.main;
        mainCamera?.GetComponent<ObjectPurse>().SetPurseObject(gameObject);
    }

    private void Start()
    {
        _player = GetComponentInChildren<Mob>();
    }

    public void Move(Vector2 direction)
    {
        _oldPosition = transform.position;
        
        var moveDirectionForce = new Vector3(direction.x, direction.y , 0.0f);
        moveDirectionForce *= speed;

        transform.Translate(moveDirectionForce * Time.fixedDeltaTime);
    }
}
