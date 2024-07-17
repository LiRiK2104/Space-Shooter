using AYellowpaper;
using Meta.Shooting;
using UnityEngine;

namespace Meta.VFX
{
    public class AttackEffectSpawner : EffectSpawner
    {
        [SerializeField] private InterfaceReference<IAttackable, MonoBehaviour> attackable;
    
        private void OnEnable()
        {
            attackable.Value.Attacked += SpawnEffect;
        }
    
        private void OnDisable()
        {
            attackable.Value.Attacked -= SpawnEffect;
        }
    }
}