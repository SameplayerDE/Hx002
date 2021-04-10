using Hx002.Framework.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx002.Framework
{
    public enum ProjectionMode
    {
        Orthographic,
        Perspective
    }
    
    public class HxCamera : HxGameObject
    {
        //Projection
        public ProjectionMode ProjectionMode;
        //Clipping
        public float Near = 0.01f;
        public float Far = 1000.0f;
        
        // ? -> In eigene Datei auslagern
        public Vector3 Up = new Vector3(0, 0, 1);
        public Vector3 Down = new Vector3(0, 0, -1);
        public Vector3 Left = new Vector3(-1, 0, 0);
        public Vector3 Right = new Vector3(1, 0, 0);
        public Vector3 Forward = new Vector3(0, 1, 0);
        public Vector3 Backward = new Vector3(0, -1, 0);
        
        // ?
        public Matrix ViewMatrix;
        public Matrix ProjectionMatrix;
        
        //Used for orthographic camera
        public float MinX = 0f;
        public float MaxX = 1f;
        public float MinY = 0f;
        public float MaxY = 1f;
        public float Size = 1f;
        
        //Used for perspective camera
        public float Width = 1f;
        public float Height = 1f;
        public float FOV = 1f;

        public HxCamera(ProjectionMode projectionMode)
        {
            Attach(new HxTransform());
            ProjectionMode = projectionMode;
        }

        public void Init(GraphicsDevice device)
        {
            if (ProjectionMode == ProjectionMode.Orthographic)
            {
                ProjectionMatrix = Matrix.CreateOrthographic(MaxX,MaxY, Near, Far);
            }
            if (ProjectionMode == ProjectionMode.Perspective)
            {
                ProjectionMatrix = Matrix.CreatePerspective(Width, Height, Near, Far);
            }
        }

        public void UpdateProjection()
        {
            if (ProjectionMode == ProjectionMode.Orthographic)
            {
                ProjectionMatrix = Matrix.CreateOrthographic(MaxX * Size,MaxY * Size, Near, Far);
            }
            if (ProjectionMode == ProjectionMode.Perspective)
            {
                ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(FOV), Width/Height, Near, Far);
            }
        }
        
        public void Update(GameTime gameTime)
        {
            UpdateProjection();
            Matrix rotationMatrix = Matrix.Multiply(Matrix.CreateRotationX(MathHelper.ToRadians(Get<HxTransform>().Rotation.X)), Matrix.CreateRotationY(MathHelper.ToRadians(Get<HxTransform>().Rotation.Y)));
            Vector3 target = Vector3.Transform(Vector3.Forward, rotationMatrix);

            //DX = Target.X;
            //DY = Target.Y;
            //DZ = Target.Z;

            //Ray.Direction = Target;
            //Ray.Position = Position;

            //BoundingBox.Min = Position - new Vector3(.25f, .25f, .25f);
            //BoundingBox.Max = Position + new Vector3(.25f, .25f, .25f);
            //ViewMatrix = Matrix.CreateLookAt(Get<HxTransform>().Position, Forward + Get<HxTransform>().Position, Up);
            
            ViewMatrix = Matrix.CreateLookAt(Get<HxTransform>().Position, Get<HxTransform>().Position + target, Vector3.Up);
            
        }
    }
}