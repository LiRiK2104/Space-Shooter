using AYellowpaper;
using UnityEngine;

namespace Meta.Shooting
{
    [RequireComponent(typeof(Animator))]
    public class DamageAnimator : MonoBehaviour
    {
        [SerializeField] private InterfaceReference<IDamagable, MonoBehaviour> damagable;
        
        private Animator _animator;
    
        private static readonly int HitTrigger = Animator.StringToHash("Hit");


        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            damagable.Value.DamageGet += PlayDamage;
        }
    
        private void OnDisable()
        {
            damagable.Value.DamageGet -= PlayDamage;
        }
    

        private void PlayDamage(Vector2 _)
        {
            _animator.SetTrigger(HitTrigger);
        }
    }
}
