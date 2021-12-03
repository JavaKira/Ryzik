using System;
using UnityEngine;

public class PlayerAnimationInspector : MonoBehaviour
{
    private Animator _animator;
    private PlayerBehaviour _player;
    private static readonly int Walk = Animator.StringToHash("Walk");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<PlayerBehaviour>();
    }

    private void Update()
    {
        _animator.SetBool(Walk, _player.Speed != Vector2.zero);
    }
}