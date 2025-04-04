using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    internal class Asteroids
    {
        public static int width, height;
        public static Random random = new Random();
        static public SpriteBatch SpriteBatch { get; set; }
        static Star[] stars;
        static public StarShip StarShip { get; set; }
        static public int GenereteRandom(int min, int max)
        {
            return random.Next(min, max);
        }
        static public void Init(SpriteBatch SpriteBatch, int Width, int Height)
        {
            Asteroids.width = Width;
            Asteroids.height = Height;
            Asteroids.SpriteBatch = SpriteBatch;
            stars = new Star[50];
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star(new Vector2(-random.Next(1, 10), 0));
            }
            StarShip = new StarShip(new Vector2(0, Height / 2 -25));
        }
        static public void Draw()
        {
            foreach (Star star in stars)
                star.Drow();
            StarShip.Drow();
            

        }
        static public void Updete()
        {
            foreach (Star star in stars)
            {
                star.Update();
            }
        }
    }
    class Star
    {
        Vector2 Pos;
        Vector2 Dir;
        Color color;

        public static Texture2D Texture2D { get; set; }

        public Star(Vector2 pos, Vector2 dir, Color color)
        {
            this .Pos = pos;
            this .Dir = dir;
        }   
        public Star(Vector2 dir) 
        { 
            this .Dir = dir;
            RandomSet();
        }
        public void Update() 
        {
            Pos += Dir;
            if (Pos.X < 0)
            {
                RandomSet();
            }
        }
        public void RandomSet()
        {
            Pos = new Vector2(Asteroids.GenereteRandom(Asteroids.width, Asteroids.width + 300), Asteroids.GenereteRandom(0, Asteroids.height));
            color = Color.FromNonPremultiplied(Asteroids.GenereteRandom(0, 256), Asteroids.GenereteRandom(0, 256), Asteroids.GenereteRandom(0, 256), 255);
        }

        public void Drow()
        {
            Asteroids.SpriteBatch.Draw(Texture2D, Pos, color);
        }
    }

    class StarShip
    {
        Vector2 Pos;        
        Color color = Color.White;
        public int Speed { get; set; } = 3;

        public static Texture2D Texture2D { get; set; }

        public StarShip(Vector2 pos)
        {
            this.Pos = pos;
            
        }       
        public void Up()
        {
            this.Pos.Y -= Speed;
        }
        public void Down()
        {
            this.Pos.Y += Speed;
        }
        public void Left()
        {
            this.Pos.X -= Speed;
        }
        public void Right()
        {
            this.Pos.X += Speed;
        }

        public void Drow()
        {
            Asteroids.SpriteBatch.Draw(Texture2D, Pos, color);
        }
    }
}
