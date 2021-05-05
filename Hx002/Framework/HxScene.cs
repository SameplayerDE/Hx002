using System;
using System.Collections.Generic;
using Hx002.Framework.Components;
using Hx002.Framework.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx002.Framework
{
    public class HxScene
    {
        public List<HxObject> Objects = new List<HxObject>();
        //Behaviour
        public List<HxIUpdate> IUpdates = new List<HxIUpdate>();
        public List<HxIStart> IStarts = new List<HxIStart>();
        //Collision
        public List<HxIOnCollisionEnter> HxIOnCollisionEnters = new List<HxIOnCollisionEnter>();

        public void Add(HxObject hxObject)
        {
            Objects.Add(hxObject);
            if (hxObject is HxGameObject gameObject)
            {
                foreach (HxComponent component in gameObject.Components)
                {
                    if (component is HxBehaviour behaviour)
                    {
                        if (behaviour is HxIUpdate iUpdate)
                        {
                            IUpdates.Add(iUpdate);
                        }
                        if (behaviour is HxIStart iStart)
                        {
                            IStarts.Add(iStart);
                        }
                        if (behaviour is HxIOnCollisionEnter iOnCollisionEnter)
                        {
                            HxIOnCollisionEnters.Add(iOnCollisionEnter);
                        }
                    }
                }
            }
        }

        public void Start()
        {
            foreach (HxIStart iStart in IStarts)
            {
                iStart.Start();
            }
        }
        
        public void Update(object sender, EventArgs e)
        {
            foreach (HxIUpdate iUpdate in IUpdates)
            {
                iUpdate.Update();
            }
            
            foreach (HxGameObject gameObject in Objects)
            {
                foreach (HxComponent component in gameObject.Components)
                {
                    if (component is HxRigidbody rigidbody)
                    {
                        rigidbody.Position = gameObject.Get<HxTransform>().Position;
                        if (rigidbody.UseGravity)
                        {
                            rigidbody.Velocity += (HxTime.DeltaTime * Hx.Gravity); // Gravity Pull
                            rigidbody.Position += HxTime.DeltaTime * rigidbody.Velocity;
                        }
                        gameObject.Get<HxTransform>().Position = rigidbody.Position;
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
                if (gameObject.Has<HxMeshRenderer>())
                {
                    HxMeshRenderer meshRenderer = gameObject.Get<HxMeshRenderer>();
                    meshRenderer.Render(Hx.GraphicsDevice, camera);
                }
                /*if (gameObject is HxMesh mesh)
                {
                    mesh.Draw(Hx.GraphicsDevice, effect, camera);
                }*/
            }
        }
    }
}