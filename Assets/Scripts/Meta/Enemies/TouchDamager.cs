using System;
using Meta.Shooting;
using UnityEngine;

namespace Meta.Enemies
{
    public class TouchDamager : MonoBehaviour, IAttackable
    {
        [SerializeField] private int damage;
        [SerializeField] private bool killSelfOnAttack;
        [SerializeField] private bool disableOnAttack;

        public event Action<Vector2> Attacked;
        
        public int Damage => damage;
    
    
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.contactCount <= 0 ||
                other.gameObject == null ||
                !other.transform.TryGetComponent(out IDamagable damagable)) 
                return;
            
            damagable.GetDamage(this, other.contacts[0].point);
            
            Attacked?.Invoke(other.contacts[0].point);
                
            if (killSelfOnAttack && TryGetComponent(out IDamagable thisDamagable))
            {
                thisDamagable.Die();
            }
                
            if (disableOnAttack)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
