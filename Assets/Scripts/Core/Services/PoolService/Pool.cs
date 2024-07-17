using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Core.Services.PoolService
{
    public class Pool : MonoBehaviour
    {
        private readonly Dictionary<ObjectType, LocalPool> _localPools = new();

        private DiContainer _diContainer;
        

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        
        public void Spawn(SpawnableObject template, Vector2 position, Quaternion rotation)
        {
            if (_localPools.TryGetValue(template.Type, out LocalPool localPool) == false)
            {
                localPool = CreateLocalPool(template.Type);
                Create(template, position, rotation, localPool);
            }
            else if (localPool.Stack.TryPop(out SpawnableObject instance) == false)
            {
                Create(template, position, rotation, localPool);
            }
        }

        public void Add(SpawnableObject spawnableObject)
        {
            if (_localPools.Keys.Contains(spawnableObject.Type) == false)
            {
                CreateLocalPool(spawnableObject.Type);
            }
            
            foreach (var localPool in _localPools)
            {
                if (localPool.Key == spawnableObject.Type)
                {
                    localPool.Value.Stack.Push(spawnableObject);
                }
            }
        }

        private LocalPool CreateLocalPool(ObjectType objectType)
        {
            LocalPool localPool = new (objectType);
            
            _localPools.Add(objectType, localPool);

            return localPool;
        }

        private void Create(SpawnableObject template, Vector2 position, Quaternion rotation, LocalPool localPool)
        {
            _diContainer.InstantiatePrefabForComponent<SpawnableObject>
                (template, position, rotation, localPool.Parent.transform);
        }
    }
}
