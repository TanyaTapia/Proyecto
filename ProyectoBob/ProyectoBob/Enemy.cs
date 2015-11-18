using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;


enum Life { Life0,Life1,Life2,Life3 }

//Los enemigos tendran en comun el movimiento automatico y la capacidad de restar vidas a Bob
namespace ProyectoBob
{


    class Enemy : AnimatedCharacter  
    {
        BasicSprite Life0,Life1, Life2, Life3;
        protected Life Lifes;
        int carga=3;
        float delay = 1800f;

        
        public virtual void LoadLifes(ContentManager Content)
        {
            Life0 = new BasicSprite();
            Life0.LoadContent(Content, "Life", "Cero");

            Life1 = new BasicSprite();
            Life1.LoadContent(Content, "Life", "Uno");

            Life2 = new BasicSprite();
            Life2.LoadContent(Content, "Life", "Dos");

            Life3 = new BasicSprite();
            Life3.LoadContent(Content, "Life", "Tres");

            Lifes = Life.Life3;
            
        }


     
        public virtual void ColisionCactus(Rectangle rect)
        {
            
           // Lifes = Life.Life3;
            //delay++;
            //if (delay >= 2)
            //{
            
                for (int i = 0; i < Cactu.Count; i++)
                {
                    delay++;
                    bool n = ((BasicSprite)Cactu[i]).Colision(rect);
                    
                    if (delay >= 1800)
                    {
                    if (((BasicSprite)Cactu[i]).Colision(rect) && carga == 3)
                    {

                        Lifes = Life.Life2;
                        carga = 2;
                        delay = 0;
                    }
                    else if (((BasicSprite)Cactu[i]).Colision(rect) && carga == 2)
                    {

                        Lifes = Life.Life1;
                        carga = 1;
                        delay = 0;
                    }
                    else if (((BasicSprite)Cactu[i]).Colision(rect) && carga <= 1)
                    {
                        Lifes = Life.Life0;
                        carga = 0;
                        delay = 0;
                    }

                    

                    }                 
                }
                
           // }

         }


            public virtual void DrawLife(SpriteBatch spriteBatch )
            {
                switch(Lifes)
                {
                    case Life.Life3:
                        {
                            Life3.Draw(spriteBatch);
                            break;
                        }
                     case Life.Life2:
                        {
                            Life2.Draw(spriteBatch);
                            break;
                        }
                     case Life.Life1:
                        {
                            Life1.Draw(spriteBatch);
                            break;
                        }
                     case Life.Life0:
                        {
                            Life0.Draw(spriteBatch);
                            break;
                        }
                }
            }
         
        }




    }

