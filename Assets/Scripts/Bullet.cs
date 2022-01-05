using System.Collections;
using System.Collections.Generic;
using Content;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float lifetime = 5;

    private float _time;
    private Mob _owner;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var mob = other.gameObject.GetComponent<Mob>();
        if (mob != null && !mob.Equals(_owner))
            mob.ApplyDamage(damage);
        Destroy(gameObject);
    }

    public IEnumerator StartMove(Vector2 direction, float speedMultiplier)
    {
        while (_time <= lifetime)
        {
            _time += Time.deltaTime;
            transform.Translate(
                direction.x * Time.deltaTime * speedMultiplier, 
                direction.y * Time.deltaTime * speedMultiplier,
                0
            );
            yield return null;
        }
        
        Destroy(gameObject);
    }

    public void SetOwner(Mob mob)
    {
        _owner = mob;
    }
}