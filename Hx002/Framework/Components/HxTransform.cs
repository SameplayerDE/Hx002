using Microsoft.Xna.Framework;

namespace Hx002.Framework.Components
{
    public class HxTransform : HxComponent
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scale;
        
        public Vector2 Position2
        {
            get { return new Vector2(Position.X, Position.Y); }
        }

        public void Translate(float x, float y, float z)
        {
            Position.X += x;
            Position.Y += y;
            Position.Z += z;
        }
        
        public void Translate(Vector3 translation)
        {
            Translate(translation.X, translation.Y, translation.Z);
        }
        
        public void Rotate(float xAngle, float yAngle, float zAngle)
        {
            Rotation.X += xAngle;
            Rotation.Y += yAngle;
            Rotation.Z += zAngle;
        }
    }
}