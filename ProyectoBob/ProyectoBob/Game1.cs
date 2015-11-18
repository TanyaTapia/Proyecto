﻿#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
// using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace ProyectoBob
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Bob bob;
        BasicMap theMap, theMap2;

        Cactus cactus;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);


         


            theMap = new BasicMap();
            theMap2 = new BasicMap();

            bob = new Bob();
            bob.LoadContent(Content);
            Rectangle temp = bob.Pos;
            temp.X = 100;
            temp.Y = 270;
            temp.Width = 100;
            temp.Height = 150;
            bob.Pos = temp;
            bob.SetMap(theMap);

            //Cactus
            cactus = new Cactus();
            cactus.LoadCac(Content);
            cactus.LoadLifes(Content);
           
            
            //Mapas
            theMap.LoadContent_Transitable(Content, "Transitable", 0, -1);
            theMap.LoadContent_Notransitable("NoTransitable", Content, 0, 420);
            theMap.SetIncrement(5);

            theMap2.LoadContent_Transitable(Content, "Transitable", 4080, -1);
            theMap2.LoadContent_Notransitable("NoTransitable", Content, 8972, 420);
            theMap2.SetIncrement(5);

            bob.setHeightLimits(graphics.GraphicsDevice.Viewport.Height);
            bob.setWidthLimits(graphics.GraphicsDevice.Viewport.Width);


        }
        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            theMap.Update(gameTime);
            theMap2.Update(gameTime);
            bob.Update(gameTime);

            cactus.Update(gameTime);

            cactus.ColisionCactus(bob.GetRect());



            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Brown);
            base.Draw(gameTime);

            
            theMap.DrawOver(spriteBatch);
            theMap2.DrawOver(spriteBatch);


            bob.Draw(spriteBatch);
            cactus.Draw(spriteBatch);
            cactus.DrawLife(spriteBatch);

            theMap.DrawUnder(spriteBatch);
            theMap2.DrawUnder(spriteBatch);
        }
    }
}
