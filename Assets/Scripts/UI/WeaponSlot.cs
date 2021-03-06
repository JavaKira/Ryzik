using Content.Weapon;
using UnityEngine;

namespace UI
{
    public class WeaponSlot : MonoBehaviour
    {
        private Weapon _weapon;
 
        public Weapon Build(Weapon weapon)
        {
            _weapon = Instantiate(weapon, transform);
            return _weapon;
        }

        public void RemoveWeapon()
        {
            Destroy(_weapon);
        }
    }
}