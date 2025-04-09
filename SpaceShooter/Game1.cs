using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace SpaceShooter
{
    enum Stat
    {
        SpaceMenu,
        Game,
        Final,
        Pause
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Stat Stat = Stat.SpaceMenu;
        KeyboardState keyboardState, oldKeyboardState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;            
        }

        protected override void Initialize()
        {
            // Инициализация 

            _graphics.PreferredBackBufferWidth = 1320;
            _graphics.PreferredBackBufferHeight = 690;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            SpaceMenu.Background = Content.Load<Texture2D>("Background");
            SpaceMenu.Font = Content.Load<SpriteFont>("MenuFont");
            Asteroids.Init(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            Star.Texture2D = Content.Load<Texture2D>("star");
            StarShip.Texture2D = Content.Load<Texture2D>("spece_shuttle");
            Fure.Texture2D = Content.Load<Texture2D>("Blaster_shot");
            // Загрузка контента
        }
               

        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            switch(Stat)
            {
                case Stat.SpaceMenu:
                    SpaceMenu.Update();
                    if (keyboardState.IsKeyDown(Keys.Space)) Stat = Stat.Game;
                    break;
                case Stat.Game:
                    Asteroids.Updete();
                    if (keyboardState.IsKeyDown(Keys.Escape)) Stat = Stat.SpaceMenu;
                    if (keyboardState.IsKeyDown(Keys.Up)) Asteroids.StarShip.Up();
                    if (keyboardState.IsKeyDown(Keys.Down)) Asteroids.StarShip.Down();
                    if (keyboardState.IsKeyDown(Keys.Left)) Asteroids.StarShip.Left();
                    if (keyboardState.IsKeyDown(Keys.Right)) Asteroids.StarShip.Right();
                    if (keyboardState.IsKeyDown(Keys.Space) && oldKeyboardState.IsKeyUp(Keys.Space))Asteroids.ShipFire();
                    break;
            }

            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Escape))
               //Exit();

            // Обработка клавиш с клавиатуры

            oldKeyboardState = keyboardState;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            
            switch(Stat)
            {
                case Stat.SpaceMenu:
                    SpaceMenu.Draw(_spriteBatch);
                    break;
                case Stat.Game:
                    Asteroids.Draw();
                    break;
            }
            _spriteBatch.End();
            // Графика

            base.Draw(gameTime);
        }
    }
}
