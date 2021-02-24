using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        private int score; 
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Player player;
        private Food foodclass;
        private Enemy enemy;

        private Texture2D texture;
        private Vector2 texturePos;
        private float angle;

        private EnemySpawner enemySpawner;
        private FoodSpawner foodSpawner;

        private List<Enemy> bomb = new List<Enemy>();
        private List<Food> food = new List<Food>();

        //BG

        //KOmentar
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            enemySpawner = new EnemySpawner(bomb);
            foodSpawner = new FoodSpawner(food);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Assets.LoadAssets(Content);

            player = new Player(Assets.Bird, texturePos);

            foodclass = new Food(Assets.Food, texturePos, angle, CollisionOrigin.food);

            enemy = new Enemy(Assets.Bomb, texturePos, angle, CollisionOrigin.enemy);

            // TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            // TODO: Add your update logic here

            base.Update(gameTime);
            player.Update();
            foodclass.Update();
            enemy.Update();
            foreach(Enemy item in bomb)
            {
                item.Update();
            }
            foreach(Food item in food)
            {
                item.Update();
            }
            
            enemySpawner.Update(gameTime);
            foodSpawner.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            player.Draw(spriteBatch);
            foreach(Enemy item in bomb)
            {
                item.Draw(spriteBatch);
            }
            foreach(Food item in food)
            {
                item.Draw(spriteBatch);
            }


            spriteBatch.End();
            base.Draw(gameTime);
        }
        public void Collision()
        {
            for (int i = 0; i < bomb.Count; i++)
            {
                if (bomb[i].GetCollisionOrigin == CollisionOrigin.enemy && bomb[i].Hitbox.Intersects(player.Hitbox)) //Enum är helt onödig i detta fallet men vill bara visa att jag kan använda den :P
                {
                    Exit();
                }
            }

            for (int i = 0; i < food.Count; i++)
            {
                if (food[i].GetCollisionOrigin == CollisionOrigin.food && food[i].Hitbox.Intersects(player.Hitbox)) 
                {
                    food.RemoveAt(i);
                    i--;
                    score++;
                }
            }
        }
    }
}
