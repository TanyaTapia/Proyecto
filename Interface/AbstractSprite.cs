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
    abstract class AbstractSprite : IGameXNA
    {
        protected Texture2D image;
        protected Rectangle pos;
        protected bool collision;
        protected Keys up, down, left, right;
        protected int incX = 3, incY = 3;
        protected int heightLimit, widthLimit;  //variables para establecer los limites de las pantallas
        public abstract void Hola();
        public void lupita();
        //Metodos absractos
        public abstract void LoadContent(ContentManager Content, String name);
        //Método para hacer colisiones
        public abstract bool Colision(Rectangle rect);
        public abstract void Draw(SpriteBatch spriteBatch);

        //metodos implementados
        public virtual void Update(GameTime gameTime)
        {
            Rectangle currentPos = this.Pos;
            
          
                if (Keyboard.GetState().IsKeyDown(up))
                {
                    if (currentPos.Y >= 0)
                    {
                        if (collision)
                        {
                            currentPos.Y = 0;
                        }
                        else
                        currentPos.Y -= incY;
                    }
                }

                if (currentPos.Y <= (this.heightLimit - currentPos.Height))
                {
                    if (Keyboard.GetState().IsKeyDown(down))
                    {
                        currentPos.Y += incY;
                    }
                }

                if (currentPos.X >= 0)
                {
                    if (Keyboard.GetState().IsKeyDown(left))
                    {
                        currentPos.X -= incX;
                    }
                }

                if (currentPos.X <= (widthLimit - currentPos.Width))
                {
                    if (Keyboard.GetState().IsKeyDown(right))
                    {
                        currentPos.X += incX;
                    }
                }
            this.Pos = currentPos;

        }
        public void setKeys(Keys Up, Keys Down, Keys Left, Keys Right)
        {
            this.up = Up;
            this.down = Down;
            this.left = Left;
            this.right = Right;
        }
        public void setHeightLimits(int b)
        {
            heightLimit = b;
        }

        public void setWidthLimits(int a)
        {
            widthLimit = a;
        }
        
        
        public Rectangle GetRect()
        {
            return pos;
        }

        //propiedades
        public abstract Rectangle Pos
        {
            set;
            get;
        }

    }
}
