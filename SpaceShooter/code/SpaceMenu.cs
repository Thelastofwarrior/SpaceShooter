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
    static internal class SpaceMenu
    {
        public static Texture2D Background {  get; set; }
        static int timeCounter = 0;
        static Color color;
        public static SpriteFont Font { get; set; }
        static Vector2 textposition = new Vector2 (400, 100);

        static public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background,new Rectangle(0,0, 1320, 690), Color.White);
            spriteBatch.DrawString(Font, "Космические Астеройды", textposition, color);
        }
        static public void Update() 
        {
            color = Color.FromNonPremultiplied(255, 255, 255, timeCounter % 256);
            timeCounter++;
        }

    }
}
