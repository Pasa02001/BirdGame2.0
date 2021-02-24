using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Player : BaseClass
    {
        public Player(Texture2D texture, Vector2 texturePos) : base(texture, texturePos)
        {
            hitbox.Size = new Point(60, 60);
        }

        public override void Update()
        {
            KeyboardState keyS = Keyboard.GetState();

            if (keyS.IsKeyDown(Keys.W))
            {
                texturePos.Y -=5;
                
            }
            if (keyS.IsKeyDown(Keys.S))
            {
                texturePos.Y += 5;
            }
            if (texturePos.Y <= 0)
            {
                texturePos.Y = 0;
            }
            if (texturePos.Y >= 420)
            {
                texturePos.Y = 420;
            }
            hitbox.Location = texturePos.ToPoint();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.Bird, new Rectangle((int)texturePos.X, (int)texturePos.Y, 60, 60), Color.White);
        }
        
    }
}
