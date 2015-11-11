#region Using Statements
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
        BasicMap theMap;
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
            bob = new Bob();
            bob.LoadContent(Content);
            Rectangle temp = bob.Pos;
            temp.X = 100;
            temp.Y = 250;
            bob.Pos = temp;
            bob.SetMap(theMap);
            theMap.LoadContent_Transitable(Content, "Transitable");
            theMap.LoadContent_Notransitable( "NoTransitable",Content);

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

            bob.Update(gameTime);

            base.Update(gameTime);
        }

     





        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);


            theMap.DrawOver(spriteBatch);
            bob.Draw(spriteBatch);
            theMap.DrawUnder(spriteBatch);
        }
    }
}
