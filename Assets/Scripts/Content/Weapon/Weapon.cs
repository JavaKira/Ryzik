namespace Content.Weapon
{
    public abstract class Weapon : Item
    {
        protected Mob Owner;
    
        public abstract void Attack();
    
        public void SetOwner(Mob mob)
        {
            Owner = mob;
        }
    }
}