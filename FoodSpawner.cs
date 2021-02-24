using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
namespace Template
{
    class FoodSpawner
    {
        private List<Food> foods = new List<Food>();
        private float time = 7;
        private float timer = 0;
        private Random rnd = new Random();

        public FoodSpawner(List<Food> foods)
        {
            this.foods = foods;
        }

        public void Update(GameTime gameTime)
        {
            if (timer >= time)
            {
                timer -= time;
                int x, y;
                if (foods.Count <= 5)
                {
                    x = 1000;
                    y = rnd.Next(0, 420);
                    foods.Add(new Food(Assets.Food, new Vector2(x, y),(float)(Math.PI / 4), CollisionOrigin.food));

                }


            }

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        }
    }
}
