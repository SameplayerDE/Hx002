using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Hx002.Framework
{
    public class HxGameObject : HxObject
    {

        private readonly List<HxComponent> _components = new List<HxComponent>();

        public List<HxComponent> Components
        {
            get { return _components; }
        }

        public void Attach(HxComponent component)
        {
            component.HxGameObject = this;
            this._components.Add(component);
        }

        public T Get<T>() where T : HxComponent
        {
            foreach (HxComponent component in this._components)
            {
                if (component is T obj)
                    return obj;
            }
            return default (T);
        }

        public void Detach(HxComponent component)
        {
            this._components.Remove(component);
        }
        
    }
}