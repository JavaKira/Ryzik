using UnityEngine;

namespace Content.Weapon
{
    public class MeleeWeapon : Weapon
    {
        [SerializeField] private int damage;
        [SerializeField] private Animation attackAnimation;
    
        private Collider2D _bounds;

        public override void Attack()
        {
            attackAnimation.Play();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (attackAnimation.isPlaying)
                other.gameObject.GetComponent<Mob>()?.ApplyDamage(damage);
        }
    }
}