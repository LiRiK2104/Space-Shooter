using AYellowpaper;
using Meta.Shooting;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace Meta.UI
{
    public class Bar : MonoBehaviour
    {
        [SerializeField] 
        private InterfaceReference<IPercentable, MonoBehaviour> percentable;
        
        [SerializeField] 
        private Slider slider;
        
        [SerializeField] 
        private bool dynamicColor;
        
        [SerializeField, ShowIf(nameof(dynamicColor))] 
        private Image filler;
        
        [SerializeField, ShowIf(nameof(dynamicColor))] 
        private Gradient gradient;


        private void OnEnable()
        {
            if (percentable.Value != null)
            {
                percentable.Value.Changed += UpdateBar;   
            }
        }
    
        private void OnDisable()
        {
            if (percentable.Value != null)
            {
                percentable.Value.Changed -= UpdateBar;
            }
        }
    

        private void UpdateBar()
        {
            float progress = percentable.Value.Percent;

            slider.value = progress;
            
            if (dynamicColor)
            {
                filler.color = gradient.Evaluate(progress);
            }
        }
    }
}
