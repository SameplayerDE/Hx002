using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Hx002.Framework
{
    public class HxWorld
    {

        public List<HxGameObject> HxGameObjects = new List<HxGameObject>();
        
        public HxWorld() {}

        public void Update(GameTime gameTime)
        {
            for (int i = HxGameObjects.Count - 1; i >= 0; i--)
            {
                HxGameObjects[i].Update(gameTime);
            }
        }

    }
}