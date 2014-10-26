using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using Microsoft.Devices.Sensors;

namespace Game_IfreannCorp
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Main : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager _Graphics;
        public GraphicsDevice _Device;
        public SpriteBatch Spritebatch;

        public Accelerometer _Motion;
        public List<Entity> _Enemies;
        public List<Projectile> _EnProjectiles;

        private static Main _Instance;
        TankGame _Game;
        public bool _Working;


        public static Main Instance
        {
            get
            {
                return _Instance;
            }
        }


        // Screen Width
        public int Width
        {
            get
            {
                return GraphicsDevice.Viewport.Width;
            }
        }
        // Screen height 
        public int Height
        {
            get
            {
                return GraphicsDevice.Viewport.Height;
            }
        }

        
       


        public Main()
        {
            _Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _Graphics.IsFullScreen = true;
            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Extend battery life under lock.
            InactiveSleepTime = TimeSpan.FromSeconds(1);

            _Graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft;
            _Graphics.ApplyChanges();

            _Instance = this;
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
            _Enemies = new List<Entity>();
            _EnProjectiles = new List<Projectile>();
            _Game = new TankGame();
            _Motion = new Accelerometer();

            try
            {
                _Motion.Start();
                _Working = true;
            }
            catch (AccelerometerFailedException e)
            {
                _Working = false;
            }
            catch (UnauthorizedAccessException e)
            {
                _Working = false;
            }

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            Spritebatch = new SpriteBatch(GraphicsDevice);
            _Game.LoadContent();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            _Game.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            
            Spritebatch.Begin();
            _Game.Draw(gameTime);
            Spritebatch.End();
            

            base.Draw(gameTime);
        }
    }
}
