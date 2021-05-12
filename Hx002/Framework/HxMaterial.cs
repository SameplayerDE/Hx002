using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Effect = Microsoft.Xna.Framework.Graphics.Effect;

namespace Hx002.Framework
{
    public class HxMaterial
    {
        public Color Color = Color.White;
        public Texture2D MainTexture;
        
        public Vector2 Tiling = new Vector2(1, 1);
        public Vector2 Offset = new Vector2(0, 0);

        public Effect Effect;

        public HxMaterial(Effect effect)
        {
            Effect = effect;
        }
        
        public HxMaterial(HxMaterial material)
        {
            Effect = material.Effect;
            Color = material.Color;
            MainTexture = material.MainTexture;
            Tiling = material.Tiling;
            Offset = material.Offset;
        }
        
        public HxMaterial(HxMaterial material, Color color)
        {
            Effect = material.Effect;
            Color = color;
        }
    }
}