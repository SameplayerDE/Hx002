using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Effect = Microsoft.Xna.Framework.Graphics.Effect;

namespace Hx002.Framework
{
    public class HxMaterial
    {
        public Color Color = Color.White;
        public Texture2D MainTexture;

        public Effect Effect;

        public HxMaterial(Effect effect)
        {
            Effect = effect;
        }
        
        public HxMaterial(HxMaterial material)
        {
            Effect = material.Effect;
            Color = material.Color;
        }
        
        public HxMaterial(HxMaterial material, Color color)
        {
            Effect = material.Effect;
            Color = color;
        }
    }
}