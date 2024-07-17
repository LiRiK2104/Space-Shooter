using Meta.Shooting;
using UnityEngine;

namespace Meta.Player
{
    [RequireComponent(typeof(Animator), typeof(Health))]
    public class HealthAnimator : MonoBehaviour
    {
        private static readonly int HealthParameter = Animator.StringToHash("Health");
        
        private Animator _animator;
        private Health _health;


        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _health = GetComponent<Health>();
        }

        private void Update()
        {
            UpdateAnimation();
        }
        

        private void UpdateAnimation()
        {
            const float minHealthValue = 0;
            const float maxHealthValue = 1;
            
            float blendValue = Mathf.Lerp(minHealthValue, maxHealthValue, _health.Percent);
        
            _animator.SetFloat(HealthParameter, blendValue);
        }
    }
}