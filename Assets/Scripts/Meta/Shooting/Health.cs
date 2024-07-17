using System;
using UnityEngine;

namespace Meta.Shooting
{
    public class Health : MonoBehaviour, IDamagable
    {
        [SerializeField] private int healthPoints;
        [SerializeField] private ParticleSystem deathEffect;

        private int _maxHealth;
        
        public event Action DamageGet;
        
        public int HealthPoints => healthPoints;
        public float Percent => healthPoints / (float)_maxHealth;

        
        private void Awake()
        {
            _maxHealth = healthPoints;
        }


        public void GetDamage(IAttackable attackable)
        {
            healthPoints -= attackable.Damage;
            
            DamageGet?.Invoke();

            if (healthPoints <= 0)
            {
                Death();
            }
        }

        private void Death()
        {
            gameObject.SetActive(false);
            PlayDeathEffect();
        }
        
        private void PlayDeathEffect()
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity, null);
        }
    }
}