using UnityEngine;

namespace Meta.Background
{
    [CreateAssetMenu(menuName = "BackgroundPreset", fileName = "BackgroundPreset", order = 51)]
    public class BackgroundPreset : ScriptableObject
    {
        [SerializeField] private Color color;
        [SerializeField] private Sprite dust;
        [SerializeField] private Sprite nebulae;
        [SerializeField] private Sprite planets;
        [SerializeField] private Sprite stars;

        public Color Color => color;
        public Sprite Dust => dust;
        public Sprite Nebulae => nebulae;
        public Sprite Planets => planets;
        public Sprite Stars => stars;
    }
}
