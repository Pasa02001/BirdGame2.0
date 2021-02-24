using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Template
{
    abstract class BaseClass
    {
        protected Texture2D texture;
        protected Vector2 texturePos;
        protected Rectangle hitbox;
        protected float angle = 0;


        protected CollisionOrigin collisionOrigin;

        public CollisionOrigin GetCollisionOrigin
        {
            get => collisionOrigin;
            set => collisionOrigin = value;

        }

        public BaseClass(Texture2D texture, Vector2 texturePos)
        {
            this.texture = texture;
            this.texturePos = texturePos;
           
        }
        public BaseClass(Texture2D texture, Vector2 texturePos, float angle, CollisionOrigin collisionOrigin)
        {
            this.texture = texture;
            this.texturePos = texturePos;
            this.angle = angle;
            this.collisionOrigin = collisionOrigin;
        }
        public Rectangle Hitbox
        {
            get => hitbox;

        }
        public abstract void Update();

        public abstract void Draw(SpriteBatch spriteBatch);
        
    }
    public enum CollisionOrigin
    {
        enemy,food
    }
}
