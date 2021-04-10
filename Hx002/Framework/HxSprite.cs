using Hx002.Framework.Components;
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

        public HxSprite()
        {
            Attach(new HxTransform());
        }

        public HxSprite(Vector3 vector3) : this()
        {
            Get<HxTransform>().Position = vector3;
        }

        public HxSprite(Texture2D texture2D) : this()
        {
            _texture2D = texture2D;
        }

        public HxSprite(Vector3 vector3, Texture2D texture2D)
        {
            Get<HxTransform>().Position = vector3;
            _texture2D = texture2D;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 position = new Vector2(Get<HxTransform>().Position.X, Get<HxTransform>().Position.Y);
            spriteBatch.Draw(_texture2D, position, _tint);
        }

    }
}