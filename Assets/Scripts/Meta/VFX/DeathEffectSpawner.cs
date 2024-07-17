using AYellowpaper;
using Meta.Shooting;
using UnityEngine;

namespace Meta.VFX
{
    public class DeathEffectSpawner : EffectSpawner
    {
        [SerializeField] private InterfaceReference<IDamagable, MonoBehaviour> damagable;
    
        
        private void OnEnable()
        {
            damagable.Value.Died += SpawnEffect;
        }
    
        private void OnDisable()
        {
            damagable.Value.Died -= SpawnEffect;
        }


        private void SpawnEffect()
        {
            SpawnEffect(damagable.Value.Position);
        }
    }
}
