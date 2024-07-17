using System.Collections.Generic;
using UnityEngine;

namespace Core.Services.PoolService
{
    public class LocalPool
    {
        public Stack<SpawnableObject> Stack = new();
        public readonly GameObject Parent;

        public LocalPool(ObjectType objectType)
        {
            Parent = new GameObject($"{objectType} Pool");
        }
    }
}