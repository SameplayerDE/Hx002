using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx002.Framework
{
    public class HxSprite : HxGameObject
    {

        private Texture2D _texture2D;
        private Color _tint = Color.White;

        public Texture2D Texture2D
        {
            get => _texture2D;
            set => _texture2D = value;
        }

        public Color Tint
        {
            get => _tint;
            set => _tint = value;
        }

        public HxSprite() {}

        public HxSprite(Vector3 vector3)
        {
            _vector3 = vector3;
        }

        public HxSprite(Texture2D texture2D)
        {
            _texture2D = texture2D;
        }

        public HxSprite(Vector3 vector3, Texture2D texture2D)
        {
            _vector3 = vector3;
            _texture2D = texture2D;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture2D, Vector2, _tint);
        }

    }
}