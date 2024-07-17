using System;

namespace Meta.Shooting
{
    public interface IDamagable
    {
        public event Action DamageGet;
        
        public int HealthPoints { get; }

        public void GetDamage(IAttackable attackable);
    }
}