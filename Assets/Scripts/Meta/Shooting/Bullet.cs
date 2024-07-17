using System;
using Core.Services.PoolService;
using UnityEngine;
using Zenject;

namespace Meta.Shooting
{
    public class Bullet : MonoBehaviour, IAttackable
    {
        [SerializeField] private int damage;
        [SerializeField, Min(0)] private float speed;
        [SerializeField] private ParticleSystem hitEffectTemplate;
        
        public int Damage => damage;

        
        private void Update()
        {
            float distance = speed * Time.deltaTime;
            Vector3 translation = Vector3.right * distance;
            
            transform.Translate(translation);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            PlayEffect();
            gameObject.SetActive(false);

            if (other.gameObject != null && other.transform.TryGetComponent(out IDamagable damagable))
            {
                damagable.GetDamage(this);
            }
        }


        private void PlayEffect()
        {
            Instantiate(hitEffectTemplate, transform.position, Quaternion.identity, null);
        }
    }
}