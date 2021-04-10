using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx002.Framework
{
    public class HxObject
    {

        protected Vector3 _vector3;

        public Vector3 Vector3
        {
            get => _vector3;
            set => _vector3 = value;
        }
        
        public Vector2 Vector2
        {
            get => new Vector2(_vector3.X, _vector3.Y);
            set
            {
                _vector3.X = value.X;
                _vector3.Y = value.Y;
            }
        }
        
        public void Add(float x, float y, float z)
        {
            _vector3.X += x;
            _vector3.Y += y;
            _vector3.Z += z;
        }
        
    }
}