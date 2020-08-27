
using UnityEngine;

namespace Game
{
    [ExecuteInEditMode]
    public class SpriteOutline : MonoBehaviour
    {
        [SerializeField]
        private bool _outline = true;

        [SerializeField]
        private Color _lineColor = Color.white;

        public Color LineColor { get => _lineColor; set => _lineColor = value; }
        public bool Outline { get => _outline; set => _outline = value; }

        private SpriteRenderer spriteRenderer;

        void OnEnable()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            UpdateOutline(Outline);
        }

        void OnDisable()
        {
            UpdateOutline(false);
        }

        void Update()
        {
            UpdateOutline(Outline);
        }

        void UpdateOutline(bool outline)
        {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            spriteRenderer.GetPropertyBlock(mpb);
            mpb.SetFloat("_Outline", outline ? 1f : 0);
            mpb.SetColor("_OutlineColor", LineColor);
            spriteRenderer.SetPropertyBlock(mpb);
        }
    }

}
