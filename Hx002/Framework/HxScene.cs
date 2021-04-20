using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx002.Framework
{
    public class HxScene
    {
        public List<HxObject> Objects = new List<HxObject>();

        public void Add(HxObject gameObject)
        {
            Objects.Add(gameObject);
        }

        public void Start()
        {
            foreach (HxGameObject gameObject in Objects)
            {
                foreach (HxComponent component in gameObject.Components)
                {
                    if (component is HxBehaviour behaviour)
                    {
                        behaviour.InvokeMethode(behaviour, "Start");
                    }
                }
            }
        }
        
        public void Update(object sender, EventArgs e)
        {
            foreach (HxGameObject gameObject in Objects)
            {
                foreach (HxComponent component in gameObject.Components)
                {
                    if (component is HxBehaviour behaviour)
                    {
                        behaviour.InvokeMethode(behaviour, "Update");
                    }
                }
                if (gameObject is HxCamera camera)
                {
                    camera.Update(HxTime.GameTime);
                }
            }
        }

        public void Draw(Effect effect, HxCamera camera)
        {
            foreach (HxGameObject gameObject in Objects)
            {
                if (gameObject is HxMesh mesh)
                {
                    mesh.Draw(Hx.GraphicsDevice, effect, camera);
                }
            }
        }
    }
}