using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Core.Services.PoolService
{
    public class Pool : MonoBehaviour
    {
        private readonly Dictionary<ObjectType, Stack<SpawnableObject>> _localPools = new();

        private DiContainer _diContainer;
        

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        
        public void Spawn(SpawnableObject template, Vector2 position, Quaternion rotation)
        {
            if (_localPools.TryGetValue(template.Type, out Stack<SpawnableObject> localPool) == false)
            {
                Create(template, position, rotation);
            }
            else if (localPool.TryPop(out SpawnableObject instance) == false)
            {
                Create(template, position, rotation);
            }
        }

        public void Add(SpawnableObject spawnableObject)
        {
            if (_localPools.Keys.Contains(spawnableObject.Type) == false)
            {
                _localPools.Add(spawnableObject.Type, new Stack<SpawnableObject>());
            }
            
            foreach (var localPool in _localPools)
            {
                if (localPool.Key == spawnableObject.Type)
                {
                    localPool.Value.Push(spawnableObject);
                }
            }
        }

        private void Create(SpawnableObject template, Vector2 position, Quaternion rotation)
        {
            _diContainer.InstantiatePrefabForComponent<SpawnableObject>
                (template, position, rotation, null);
        }
    }
}
