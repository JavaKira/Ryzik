using Content;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private Animation attackAnimation;
    
    private Collider2D _bounds;

    public override void Attack()
    {
        attackAnimation.Play();
    }
}