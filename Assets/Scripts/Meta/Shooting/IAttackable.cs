using System;
using UnityEngine;

namespace Meta.Shooting
{
    public interface IAttackable
    {
        public event Action<Vector2> Attacked;
        
        public int Damage { get; }
    }
}
