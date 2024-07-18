using System.Collections;
using AYellowpaper;
using AYellowpaper.SerializedCollections;
using Core.Services.Progress;
using Meta.Shooting;
using UnityEngine;

namespace Meta.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private EnemiesKillsProgress enemiesKillsProgress;
        [SerializeField] private InterfaceReference<IDamagable, MonoBehaviour> player;
        [SerializeField] private InterfaceReference<IDamagable, MonoBehaviour> ship;
        [SerializeField, Range(0, 5f)] private float finishDelay;
    
        [SerializeField, SerializedDictionary("View", "GameObject")] 
        private SerializedDictionary<View, GameObject> viewObjects;

        private bool _switchLocked;
    

        private void OnEnable()
        {
            enemiesKillsProgress.AllKilled += SetVictoryView;
            player.Value.Died += SetFailView;
            ship.Value.Died += SetFailView;
        }
    
        private void OnDisable()
        {
            enemiesKillsProgress.AllKilled -= SetVictoryView;
            player.Value.Died -= SetFailView;
            ship.Value.Died -= SetFailView;
        }

        private void Start()
        {
            SetGameView();
        }


        private void SetGameView()
        {
            StartCoroutine(SwitchView(View.Game));
        }
    
        private void SetFailView()
        {
            StartCoroutine(SwitchView(View.Fail, true, finishDelay));
        }
    
        private void SetVictoryView()
        {
            StartCoroutine(SwitchView(View.Victory, true, finishDelay));
        }
    
        private IEnumerator SwitchView(View view, bool lockSwitches = false, float delay = 0)
        {
            if (_switchLocked) 
                yield break;

            if (lockSwitches)
            {
                _switchLocked = true;
            }

            yield return new WaitForSeconds(delay);
        
            foreach (var viewObject in viewObjects)
            {
                viewObject.Value.SetActive(view == viewObject.Key);
            }
        }
    }
}
