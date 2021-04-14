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
                    if (component is HxBehaviour)
                    {
                        HxBehaviour behaviour = component as HxBehaviour;
                        behaviour.InvokeMethode(behaviour, "Start");
                    }
                }
            }
        }
        
        public void Update()
        {
            foreach (HxGameObject gameObject in GameObjects)
            {
                foreach (HxComponent component in gameObject.Components)
                {
                    if (component is HxBehaviour)
                    {
                        HxBehaviour behaviour = component as HxBehaviour;
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