using UnityEngine;

namespace Meta.VFX
{
    public abstract class EffectSpawner : MonoBehaviour
    {
        [SerializeField] private ParticleSystem effectTemplate;
        [SerializeField] private bool setParent;

        protected void SpawnEffect(Vector2 position)
        {
            Transform parent = setParent ? transform : null;
            
            Instantiate(effectTemplate, position, Quaternion.identity, parent);
        }
    }
}
