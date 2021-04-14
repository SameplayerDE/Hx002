using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace Hx002.Framework
{
    public class HxContentLoader<T>
    {

        public Dictionary<string, T> LoadedContent = new Dictionary<string, T>();
        
        public virtual void Load(ContentManager contentManager)
        {
            
        }

        public T Get(string key)
        {
            key = key.ToLower();
            if (LoadedContent.ContainsKey(key))
            {
                return LoadedContent[key];
            }
            return default;
        }
        
    }
}