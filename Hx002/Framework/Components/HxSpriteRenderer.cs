using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;

namespace Hx002.Framework.Components
{
    public class HxSpriteRenderer : HxRenderer
    {
        public Texture2D Texture2D;
        public Color Color;

        private static HxMeshData _data = new HxMeshData();
        private static HxMesh _quad;
        private static bool _generated = false;


        public HxSpriteRenderer()
        {
            if (!_generated) 
            {
                _data.Add(new VertexPositionNormalTexture(new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector2(1, 1)));
                _data.Add(new VertexPositionNormalTexture(new Vector3(-1, 0, 0), new Vector3(0, 0, 0), new Vector2(0, 1)));
                _data.Add(new VertexPositionNormalTexture(new Vector3(-1, 1, 0), new Vector3(0, 0, 0), new Vector2(0, 0)));

                _data.Add(new VertexPositionNormalTexture(new Vector3(-1, 1, 0), new Vector3(0, 0, 0), new Vector2(0, 0)));
                _data.Add(new VertexPositionNormalTexture(new Vector3(0, 1, 0), new Vector3(0, 0, 0), new Vector2(1, 0)));
                _data.Add(new VertexPositionNormalTexture(new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector2(1, 1)));
                
                _quad = new HxMesh(_data);
                _generated = true;
            }
        }
        

        public void Render(GraphicsDevice graphicsDevice, HxCamera hxCamera)
        {
        
            if (Texture2D != null)
            {
                Matrix translationMatrix = Matrix.CreateTranslation(HxGameObject.Get<HxTransform>().Position);
                Matrix rotationMatrix =
                Matrix.CreateRotationX(MathHelper.ToRadians(HxGameObject.Get<HxTransform>().Rotation.X)) *
                Matrix.CreateRotationY(MathHelper.ToRadians(HxGameObject.Get<HxTransform>().Rotation.Y)) *
                Matrix.CreateRotationZ(MathHelper.ToRadians(HxGameObject.Get<HxTransform>().Rotation.Z));
                Matrix world = rotationMatrix * translationMatrix;
                _quad.Effect.Parameters["WorldViewProjection"].SetValue(world * hxCamera.ViewMatrix * hxCamera.ProjectionMatrix);

                foreach (EffectPass effectPass in _quad.Effect.CurrentTechnique.Passes)
                {
                    effectPass.Apply();
                    graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, _quad.HxMeshData.VertexData, 0,
                        _quad.HxMeshData.VertexCount / 3);
                }
                    
            }
            
        }
        
        
    }
}