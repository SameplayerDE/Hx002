using System;
using System.Collections.Generic;

namespace Hx002.Framework
{
    public class HxScene
    {
        public List<HxGameObject> GameObjects = new List<HxGameObject>();

        public void Add(HxGameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }

        public void Start()
        {
            foreach (HxGameObject gameObject in GameObjects)
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
            foreach (HxGameObject gameObject in GameObjects)
            {

                if (gameObject is HxCamera camera)
                {
                    camera.Update(HxTime.GameTime);
                }
                
                foreach (HxComponent component in gameObject.Components)
                {
                    if (component is HxBehaviour behaviour)
                    {
                        behaviour.InvokeMethode(behaviour, "Update");
                    }
                }
            }
        }

        public void Draw()
        {
            
        }
    }
}