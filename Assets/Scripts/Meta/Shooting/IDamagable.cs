using System;
using UnityEngine;

namespace Meta.Shooting
{
    public interface IDamagable
    {
        public event Action<Vector2> DamageGet;
        public event Action Died;
        
        public Vector2 Position { get; }
        public int HealthPoints { get; }

        public void GetDamage(IAttackable attackable, Vector2 position);
        
        public void Die();
    }
}