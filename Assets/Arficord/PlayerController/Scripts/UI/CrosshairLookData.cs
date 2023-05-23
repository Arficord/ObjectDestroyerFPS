using UnityEngine;

namespace Arf.UI.HUD
{
    [CreateAssetMenu(fileName = "CrosshairLookData", menuName = "Arficord/UI/CrosshairLookData", order = 0)]
    public class CrosshairLookData : ScriptableObject
    {
        [SerializeField] private float transitDuration = 0.1f;
        [SerializeField] private Vector2 partsOffset = new Vector2(100f,100f);
        [SerializeField] private Color centralPartColor = Color.white;
        [SerializeField] private Color upPartColor = Color.white;
        [SerializeField] private Color downPartColor = Color.white;
        [SerializeField] private Color leftPartColor = Color.white;
        [SerializeField] private Color rightPartColor = Color.white;
        
        public float TransitDuration => transitDuration;
        public Vector2 PartsOffset => partsOffset;
        
        public Color CentralPartColor => centralPartColor;
        public Color UpPartColor => upPartColor;
        public Color DownPartColor => downPartColor;
        public Color LeftPartColor => leftPartColor;
        public Color RightPartColor => rightPartColor;
    }
}
