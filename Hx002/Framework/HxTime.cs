using Microsoft.Xna.Framework;

namespace Hx002.Framework
{
    public static class HxTime
    {

        public static GameTime GameTime;
        public static float DeltaTime;

        public static void Update(GameTime gameTime)
        {
            GameTime = gameTime;
            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

    }
}