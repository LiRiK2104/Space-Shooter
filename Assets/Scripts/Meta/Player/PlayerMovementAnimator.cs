using UnityEngine;

namespace Meta.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerMovementAnimator : MonoBehaviour
    {
        private static readonly int BlendParameter = Animator.StringToHash("Blend");
        private Animator _animator;


        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            float progress = Mathf.InverseLerp(-1, 1, Input.GetAxis("Horizontal"));
            
            UpdateRotation(progress);
            UpdateAnimation(progress);
        }

        private void UpdateRotation(float progress)
        {
            const float minAngle = 20;
            const float maxAngle = -20;
        
            float z = Mathf.Lerp(minAngle, maxAngle, progress);
        
            transform.rotation = Quaternion.Euler(0, 0, z);
        }
        
        private void UpdateAnimation(float progress)
        {
            const float minBlendValue = 0;
            const float maxBlendValue = 1;
        
            float blendValue = Mathf.Lerp(minBlendValue, maxBlendValue, progress);
        
            _animator.SetFloat(BlendParameter, blendValue);
        }
    }
}
