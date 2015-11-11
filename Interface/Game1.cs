#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
#endregion

namespace Interface
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BasicSprite kirby, fantasma;
        int heightLimit, widthLimit;  //variables para establecer los limites de las pantallas
        BasicAnimatedSprite link, man;

        public Game1()
            : base()
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
            kirby = new BasicSprite();
            fantasma = new BasicSprite();
            link = new BasicAnimatedSprite();
            man = new BasicAnimatedSprite();
            man = new BasicAnimatedSprite();
            this.widthLimit = graphics.GraphicsDevice.Viewport.Width;
            this.heightLimit = graphics.GraphicsDevice.Viewport.Height;
            
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

            // TODO: use this.Content to load your game content here

            //uno.SetParameters("kirby");
            kirby.setKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right);
            kirby.LoadContent(Content, "kirby");
            Rectangle pos = kirby.Pos;
            pos.X = 200;
            pos.Y = 200;
            pos.Width = 65;
            pos.Height = 60;
            kirby.Pos = pos;
            kirby.setHeightLimits(heightLimit);
            kirby.setWidthLimits(widthLimit);

            fantasma.setKeys(Keys.W, Keys.Z, Keys.A, Keys.D);
            fantasma.LoadContent(Content, "fantasma");
            Rectangle temp = fantasma.Pos;
            temp.X = 300;
            temp.Y = 300;
            temp.Width = 65;
            temp.Height = 60;
            fantasma.Pos = temp;
            fantasma.setHeightLimits(heightLimit);
            fantasma.setWidthLimits(widthLimit);

            link.setKeys(Keys.U, Keys.N, Keys.H, Keys.K);
            link.SetParameters("LinkLeft", 8, 0.12f);
            link.LoadContent(Content, "LinkLeft_f");
            link.setHeightLimits(heightLimit);
            link.setWidthLimits(widthLimit);

            man.setKeys(Keys.T, Keys.V, Keys.F, Keys.G);
            man.SetParameters("ManRight", 50, 50, 8, 0.12f);
            man.LoadContent(Content, "ManRight");
            man.setHeightLimits(heightLimit);
            man.setWidthLimits(widthLimit);


           
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            kirby.Update(gameTime);
            kirby.Colision(fantasma.GetRect());
            kirby.Colision(man.GetRect());
            kirby.Colision(link.GetRect());
            fantasma.Update(gameTime);
            fantasma.Colision(kirby.GetRect());
            fantasma.Colision(man.GetRect());
            fantasma.Colision(link.GetRect());
            link.Update(gameTime);
            link.Colision(man.GetRect());
            link.Colision(kirby.GetRect());
            link.Colision(fantasma.GetRect());
            man.Update(gameTime);
            man.Colision(link.GetRect());
            man.Colision(fantasma.GetRect());
            man.Colision(kirby.GetRect());
          
           

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            kirby.Draw(spriteBatch);
            fantasma.Draw(spriteBatch);
            link.Draw(spriteBatch);
            man.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
