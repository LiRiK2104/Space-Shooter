using AYellowpaper;
using Meta.Shooting;
using UnityEngine;

namespace Meta.VFX
{
    public class DamageEffectSpawner : EffectSpawner
    {
        [SerializeField] private InterfaceReference<IDamagable, MonoBehaviour> damagable;

        private void OnEnable()
        {
            damagable.Value.DamageGet += SpawnEffect;
        }
    
        private void OnDisable()
        {
            damagable.Value.DamageGet -= SpawnEffect;
        }
    }
}