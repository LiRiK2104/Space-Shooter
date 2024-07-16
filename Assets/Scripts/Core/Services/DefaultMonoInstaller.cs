using UnityEngine;
using Zenject;

namespace Core.Services
{
    public class DefaultMonoInstaller<T> : MonoInstaller where T : MonoBehaviour
    {
        [SerializeField] private T service;
    
        public override void InstallBindings()
        {
            Container.Bind<T>().FromInstance(service).AsSingle();
        }
    }
}