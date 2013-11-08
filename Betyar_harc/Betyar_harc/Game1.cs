using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Betyar_harc
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Controller controller;
        Background bg;
        Camera2D camera;


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
            camera = new Camera2D(GraphicsDevice.Viewport);
            bg = new Background(Content, @"Textures/Dildozer");
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
            // TODO: Add your update logic here
            KeyboardState keystate = Keyboard.GetState();
            GamePadState gamepadstate = GamePad.GetState(PlayerIndex.One);

            controller = new BattleController(camera);

            if (keystate.IsKeyDown(Keys.A) || gamepadstate.ThumbSticks.Left.X < 0)
                controller.left();
            else if (keystate.IsKeyDown(Keys.D) || gamepadstate.ThumbSticks.Left.X > 0)
                controller.right();
            else if (keystate.IsKeyDown(Keys.W) || gamepadstate.ThumbSticks.Left.Y > 0)
                controller.up();
            else if (keystate.IsKeyDown(Keys.S) || gamepadstate.ThumbSticks.Left.Y < 0)
                controller.down();
            else if (keystate.IsKeyDown(Keys.Left) || gamepadstate.DPad.Left.Equals(1)) //terkep mozgatasok
                controller.moveLeft(gameTime);
            else if (keystate.IsKeyDown(Keys.Right) || gamepadstate.DPad.Right.Equals(1)) //terkep mozgatasok
                controller.moveRight(gameTime);
            else if (keystate.IsKeyDown(Keys.Up) || gamepadstate.DPad.Up.Equals(1)) //terkep mozgatasok
                controller.moveUp(gameTime);
            else if (keystate.IsKeyDown(Keys.Down) || gamepadstate.DPad.Down.Equals(1)) //terkep mozgatasok
                controller.moveDown(gameTime);
            if (keystate.IsKeyDown(Keys.Enter) || gamepadstate.Buttons.A > 0)
                controller.use();
            if (keystate.IsKeyDown(Keys.Back) || gamepadstate.Buttons.X > 0)
                controller.redo();
            if ((keystate.IsKeyDown(Keys.Escape) || gamepadstate.Buttons.Back == ButtonState.Pressed))
                this.Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            

            // TODO: Add your drawing code here
            Vector2 parallax = new Vector2(0.5f);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetViewMatrix(parallax));
            bg.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
