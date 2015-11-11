using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace Interface
{
    class BasicSprite : AbstractSprite
    {
              

        public override void LoadContent(ContentManager Content, String name)
        {
            image = Content.Load<Texture2D>(name);
            pos = new Rectangle(0, 0, image.Width, image.Height);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (collision)
            {
                spriteBatch.Draw(image, pos, Color.Red);
            }
            else
            {
                spriteBatch.Draw(image, pos, Color.White);
            }
            spriteBatch.End();
            collision = false;
        }

        public override bool Colision(Rectangle rect)
        {
            bool tempCol = pos.Intersects(rect);
            if (collision || tempCol)

                collision = true;
            return collision;
        }

        public override Rectangle Pos
        {
            get
            {
                return pos;
            }
            set
            {
                pos = value;
            }
        }
    }
}
