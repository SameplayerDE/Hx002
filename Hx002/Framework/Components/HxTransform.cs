using Microsoft.Xna.Framework;

namespace Hx002.Framework.Components
{
    public class HxTransform : HxComponent
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scale = Vector3.One;
        
        public void Translate(float x, float y, float z)
        {
            //Translate(new Vector3(x, y, z), HxSpace.Self);
            Translate(new Vector3(x, y, z));
        }
        
        /*public void Translate(float x, float y, float z, HxSpace space)
        {
            Translate(new Vector3(x, y, z), space);
        }*/
        
        public void Translate(Vector3 translation)
        {
            //Translate(translation, HxSpace.Self);
            Position += translation;
        }
        
        /*public void Translate(Vector3 translation, HxSpace space)
        {
            if (space == HxSpace.Self)
            {
                Matrix rotationMatrix = Matrix.CreateRotationX(MathHelper.ToRadians(Rotation.X)) *
                                        Matrix.CreateRotationY(MathHelper.ToRadians(Rotation.Y)) *
                                        Matrix.CreateRotationZ(MathHelper.ToRadians(Rotation.Z));
                translation = Vector3.Transform(translation, rotationMatrix);
            }
            Position += translation;
        }*/
        
        public void Rotate(float xAngle, float yAngle, float zAngle)
        {
            //Rotate(new Vector3(xAngle, yAngle, zAngle), HxSpace.Self);
            Rotate(new Vector3(xAngle, yAngle, zAngle));
        }
        
        /*public void Rotate(float xAngle, float yAngle, float zAngle, HxSpace space)
        {
            Rotate(new Vector3(xAngle, yAngle, zAngle), space);
        }*/
        
        public void Rotate(Vector3 rotation)
        {
            Rotation += rotation;
            if (Rotation.X > 180)
            { 
                Rotation.X -= 360;
            }
            if (Rotation.Y > 360)
            {
                Rotation.Y -= 360;
            }
            if (Rotation.Z > 360)
            {
                Rotation.Z -= 360;
            }
            if (Rotation.X < -180)
            { 
                Rotation.X += 360;
            }
            if (Rotation.Y < 0)
            {
                Rotation.Y += 360;
            }
            if (Rotation.Z < 0)
            {
                Rotation.Z += 360;
            }
        }
        
        /*public void Rotate(Vector3 rotation, HxSpace space)
        {
            if (space == HxSpace.Self)
            {
                Matrix rotationMatrix = Matrix.CreateRotationX(MathHelper.ToRadians(Rotation.X)) *
                                        Matrix.CreateRotationY(MathHelper.ToRadians(Rotation.Y)) *
                                        Matrix.CreateRotationZ(MathHelper.ToRadians(Rotation.Z));
                rotation = Vector3.Transform(rotation, rotationMatrix);
            }
            Rotation += rotation;
        }*/
    }
}