using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MOBA
{
    public class Game1 : Game
    {
        
        public Game1()
        {
            Globals.Graphics              = new GraphicsDeviceManager(this);
            Globals.Content               = this.Content;
            Globals.Content.RootDirectory = "Content";

            this.IsMouseVisible = true;
            Globals.Graphics.PreferredBackBufferWidth  = (int)Globals.WINDOW_WIDTH;
            Globals.Graphics.PreferredBackBufferHeight = (int)Globals.WINDOW_HEIGHT;
            this.Window.Title                          = Globals.WINDOW_TITLE;
            this.Window.AllowUserResizing = false;
            IsFixedTimeStep = false;
            Globals.Graphics.SynchronizeWithVerticalRetrace = Globals.WINDOW_VSYNC;
            Globals.Graphics.ApplyChanges();
        }

        private float fpsUpdateTimer = 0.1f;
        private float framePerSecond;

        private World world;


        protected override void Initialize()
        {
            System.Console.WriteLine("Game has started!");
            base.Initialize();

            Globals.UserInterface = new UI();

            world = new World();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);

           

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            fpsUpdateTimer -= 0.001f;
            if (fpsUpdateTimer <= 0)
            {
                framePerSecond = 1f / (float)gameTime.ElapsedGameTime.TotalSeconds;
                Globals.UserInterface.fps.text = decimal.Round(((decimal)framePerSecond), 2) + "fps";
                fpsUpdateTimer = 0.1f;
            }

            world.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.GhostWhite);
            
            Globals.SpriteBatch.Begin();

            Globals.UserInterface.Draw();
            world.Draw();
            // TODO: Add your drawing code here

            Globals.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
