using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
//using Microsoft.Xna.Framework.GamerServices;
using System.Collections;

namespace ProyectoBob
{
      enum SideDirection { Jump, Crouch, Stand_Left, Stand_Right, Move_Left, Move_Right, GameOver, cac1, cac2, cac3, cac4}

    class AnimatedCharacter
    {
        // Attributes
        protected BasicSprite standLeft, standRight, jump, crouch, cactus1, cactus2, cactus3, cactus4;

        protected BasicAnimatedSprite  walkRigh;   
        
        protected Rectangle pos;
        protected SideDirection direccion;
        protected int incX = 2;
        protected float incY = 2;
        protected Rectangle col;
        protected int heightLimit, widthLimit;
        protected bool collision;

        protected ArrayList Cactus, Cac2, Cac3; //Cargar muchos enemigos en un arreglo


      //  BasicMap map;

        // Properties
        public virtual Rectangle Pos
        {
            set
            {             
                standRight.Pos = value;
                //jump.Pos = value;
                //crouch.Pos = value;
                walkRigh.Pos = value;
              
            }
            get { return walkRigh.Pos; }
        }




        // Methods 


        //LoadContent para cargar los cactus

        public virtual void Cactus1(ContentManager Content, string dirName, String name)
        {
            Cactus = new ArrayList();

            for (int k = 0; k < 10; k++) // Se generan los primeros tipos de cactus 
            {
                cactus1 = new BasicSprite();
                cactus1.LoadContent(Content, dirName,name);
                    Rectangle tempo = cactus1.Pos;
                    tempo.X = (1000*k);
                    tempo.Y = 310;
                    cactus1.Pos = tempo;
                direccion = SideDirection.cac1;
                Cactus.Add(cactus1);
            }
        }

        public virtual void Cactus2(ContentManager Content, string dirName, String name)
        {
            Cac2 = new ArrayList();

            for (int k = 0; k < 10; k++) // Se generan los primeros tipos de cactus 
            {
                cactus2 = new BasicSprite();
                cactus2.LoadContent(Content, dirName, name);
                Rectangle tempo = cactus2.Pos;
                tempo.X = (800 * k);
                tempo.Y = 310;
                cactus2.Pos = tempo;
                direccion = SideDirection.cac2;
                Cac2.Add(cactus2);
            }
          
        }

        public virtual void Cactus3(ContentManager Content, string dirName, String name)
        {
            Cac3 = new ArrayList();

            for (int k = 0; k < 10; k++) // Se generan los primeros tipos de cactus 
            {
                cactus3 = new BasicSprite();
                cactus3.LoadContent(Content, dirName, name);
                Rectangle tempo = cactus3.Pos;
                tempo.X = (600 * k);
                tempo.Y = 310;
                cactus3.Pos = tempo;
                direccion = SideDirection.cac3;
                Cac3.Add(cactus3);
            }
          
        }

     /*     public virtual void Cactus4(ContentManager Content, string dirName, String name)
        {
            cactus4 = new BasicSprite();
            direccion = SideDirection.cac4;
            cactus4.LoadContent(Content, dirName, name);
        }*/




        //Load content para imagenes estáticas (BasicSprite)

        public virtual void LoadContent_Jump(ContentManager Content, string dirName, String name)
        {
            jump = new BasicSprite();
            direccion = SideDirection.Jump;
            jump.LoadContent(Content, dirName, name);
        }



        public virtual void LoadContent_Crouch(ContentManager Content, string dirName, String name)
        {
            crouch = new BasicSprite();
            direccion = SideDirection.Crouch;
            crouch.LoadContent(Content, dirName, name);
        }
        public virtual void LoadContent_StandLeft(ContentManager Content, string dirName, String name)
        {
            standLeft = new BasicSprite();
            direccion = SideDirection.Stand_Left;
            standLeft.LoadContent(Content, dirName, name);
        }
        public virtual void LoadContent_StandRight(ContentManager Content, string dirName, String name)
        {
            standRight = new BasicSprite();
            direccion = SideDirection.Stand_Right;
            standRight.LoadContent(Content, dirName, name);
        }



        //Loading metodo para animaciones con multiples archivos (BasicAnimatedSprite)

     
       
     
        public virtual void LoadContent_WalkRight(ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame)
        {
            walkRigh = new BasicAnimatedSprite();
            direccion = SideDirection.Move_Right;
            walkRigh.LoadContent(Content, nameDir, nameFile, frameCount, timePerFrame);
        }




       /*PARA IMAGENES EN COLISIONES 
        * public virtual void LoadContent_Collision(ContentManager Content, String nameDir, String nameFile, int frameCount, float timerPerFrame)
        {
            collisi = new BasicAnimatedSprite();
            direccion = SideDirection.Collision;
            collisi.LoadContent(Content, nameDir, nameFile, frameCount, timerPerFrame);

        }*/ 





        //Loading metodo para animaciones con un solo archivo (BasicAnimatedSprite)

       
        public virtual void LoadContent_WalkRight(ContentManager Content, string dirName, String name, int frameWidth, int frameHeight, int frameCount, float timePerFrame)
        {
            walkRigh = new BasicAnimatedSprite();
            direccion = SideDirection.Move_Right;
            walkRigh.LoadContent(Content, dirName, name, frameWidth, frameHeight, frameCount, timePerFrame);
        }




       /*
        * PARA IMAGENES EN COLISIONES
        * public virtual void LoadContent_Collision(ContentManager Content, String dirName, String name, int frameWidth, int frameHeight, int frameCount, float timePerFrame)
        {
            collisi = new BasicAnimatedSprite();
            direccion = SideDirection.Collision;
            collisi.LoadContent(Content, dirName, name, frameWidth, frameHeight, frameCount, timePerFrame);

        }*/


        //Los siguientes dos metodos (setHeightLimits, setWidth) son para delimitar la pantalla 
        public void setHeightLimits(int b)
        {
            heightLimit = b;
        }

        public void setWidthLimits(int a)
        {
            widthLimit = a;
        }

        //Checar colisiones
        public virtual bool Collision(Rectangle rect)
        {
            
            standRight.Colision(rect);
            jump.Colision(rect);
            crouch.Colision(rect);
            walkRigh.Colision(rect);
            collision= standLeft.Colision(rect);
            return collision;

        }

        public virtual Rectangle GetRect()
        {
            col = walkRigh.Pos;
            return col;
        }
     
        public virtual void Update(GameTime gameTime)
        {
            //Poner los valores por default         
            if (direccion == SideDirection.Move_Right)
                direccion = SideDirection.Stand_Right;
            
            //PARA CACTUS 1
            if (direccion== SideDirection.cac1)
            {
            for (int k = 0; k < Cactus.Count; k++)
            {

                // ((Basic)TheArray[k]).Collision(jugador.GetRect());
                ((BasicSprite)Cactus[k]).SetMove(true);
                ((BasicSprite)Cactus[k]).SetIncrement(new Vector2(-2, 0));
                ((BasicSprite)Cactus[k]).Update(gameTime);

            }
            }
            else
                if (direccion == SideDirection.cac2)
                {
                    for (int k = 0; k < Cac2.Count; k++)
                    {

                        // ((Basic)TheArray[k]).Collision(jugador.GetRect());
                        ((BasicSprite)Cac2[k]).SetMove(true);
                        ((BasicSprite)Cac2[k]).SetIncrement(new Vector2(-2, 0));
                        ((BasicSprite)Cac2[k]).Update(gameTime);

                    }
                }
                else
                    if (direccion == SideDirection.cac3)
                    {
                        for (int k = 0; k < Cac3.Count; k++)
                        {

                            // ((Basic)TheArray[k]).Collision(jugador.GetRect());
                            ((BasicSprite)Cac3[k]).SetMove(true);
                            ((BasicSprite)Cac3[k]).SetIncrement(new Vector2(-2, 0));
                            ((BasicSprite)Cac3[k]).Update(gameTime);

                        }
                    }


        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            switch (direccion)
            {
                case SideDirection.Move_Right:
                    {
                        walkRigh.Draw(spriteBatch);
                        break;
                    }
              /*  case SideDirection.Jump:
                    {
                        jump.Draw(spriteBatch);
                        break;
                    }*/
                case SideDirection.Crouch:
                    {
                        crouch.Draw(spriteBatch);
                        break;
                    }
                case SideDirection.Stand_Left:
                    {
                        standLeft.Draw(spriteBatch);
                        break;
                    }
                case SideDirection.Stand_Right:
                    {
                        standRight.Draw(spriteBatch);
                        break;
                    }
                case SideDirection.cac1:
                    {
                        for (int k = 0; k < Cactus.Count; k++)
                            ((BasicSprite)Cactus[k]).Draw(spriteBatch);
                        break;
                    }

                case SideDirection.cac2:
                    {
                        for (int k = 0; k < Cac2.Count; k++)
                            ((BasicSprite)Cac2[k]).Draw(spriteBatch);
                        break;
                    }
                case SideDirection.cac3:
                    {
                        for (int k = 0; k < Cac3.Count; k++)
                            ((BasicSprite)Cac3[k]).Draw(spriteBatch);
                        break;
                    }
               /* case SideDirection.cac4:
                    {
                        cactus4.Draw(spriteBatch);
                        break;
                    }*/
                    
                
             
              /* 
               * PARA IMAGENES EN COLISIONES
               * case SideDirection.Collision:
                    {
                        collisi.Draw(spriteBatch);
                        
                        break;
                    }*/ 
            }
        }
    }
}


