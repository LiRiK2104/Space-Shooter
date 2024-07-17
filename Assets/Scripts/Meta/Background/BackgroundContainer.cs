using Helpers;
using UnityEngine;

namespace Meta.Background
{
    public class BackgroundContainer : MonoBehaviour
    {
        [SerializeField] private BackgroundPreset[] backgroundPresets;
    
        [SerializeField] private SpriteRenderer dust;
        [SerializeField] private SpriteRenderer nebulae;
        [SerializeField] private SpriteRenderer planets;
        [SerializeField] private SpriteRenderer stars;

        private void Start()
        {
            BackgroundPreset backgroundPreset = Utils.GetRandomElement(backgroundPresets);

            dust.sprite = backgroundPreset.Dust;
            nebulae.sprite = backgroundPreset.Nebulae;
            planets.sprite = backgroundPreset.Planets;
            stars.sprite = backgroundPreset.Stars;

            if (Camera.main != null)
            {
                Camera.main.backgroundColor = backgroundPreset.Color;
            }
        }
    }
}
