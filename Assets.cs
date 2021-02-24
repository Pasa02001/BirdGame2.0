using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
namespace Template
{
    class Assets
    {
        public static Texture2D Bird
        {
            get;
            private set;
        }
        public static Texture2D Food
        {
            get;
            private set;
        }

        public static Texture2D Bomb
        {
            get;
            private set;
        }
        public static void LoadAssets(ContentManager contentManager)
        {
            Bomb = contentManager.Load<Texture2D>("Bomb");
            Bird = contentManager.Load<Texture2D>("Bird");
            Food = contentManager.Load<Texture2D>("Apple");
        }

    }
}
