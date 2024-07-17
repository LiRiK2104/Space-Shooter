using System;
using UnityEngine;

namespace Meta.Shooting
{
    public class Health : MonoBehaviour, IDamagable
    {
        [SerializeField] private int healthPoints;
        [SerializeField] private bool resetOnEnable = true;

        private int _maxHealth;
        
        public event Action<Vector2> DamageGet;
        public event Action Died;
        
        public Vector2 Position => transform.position;
        public int HealthPoints => healthPoints;
        public float Percent => healthPoints / (float)_maxHealth;

        
        private void Awake()
        {
            _maxHealth = healthPoints;
        }

        private void OnEnable()
        {
            if (resetOnEnable)
            {
                healthPoints = _maxHealth;   
            }
        }


        public void GetDamage(IAttackable attackable, Vector2 hitPosition)
        {
            healthPoints -= attackable.Damage;
            
            DamageGet?.Invoke(hitPosition);

            if (healthPoints <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            Died?.Invoke();
            gameObject.SetActive(false);
        }
    }
}