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
    
    class BasicSprite
    {



       //Atributos
        Texture2D image;
        Rectangle pos;
        bool collision;




        // Metodo de inicializacion
        public void LoadContent(ContentManager Content,String dirName, String name)
        {
            image = Content.Load<Texture2D>(dirName + "/" + name);
            //Se respetan los valores que tiene la imagen
            pos = new Rectangle(0,0, image.Width,image.Height);
        }


        //Checar colisiones 
        public bool Colision(Rectangle rect)
        {
            bool tempCol = pos.Intersects(rect);
            if (collision || tempCol)

                collision = true;
            return collision;
        }

      




        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
                            spriteBatch.Draw(image, pos, Color.White);                 
            spriteBatch.End();
            collision = false;
        }





        // Regresa/obtiene el valor de la posicion en un momento en especifico
        public Rectangle Pos
        {
            set
            {
                pos = value;
            }
            get
            {
                return pos;
            }
        }
    
    
    
    
    }
}


