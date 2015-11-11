using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace ProyectoBob
{
      enum SideDirection { Jump, Crouch, Stand_Left, Stand_Right, Move_Left, Move_Right, GameOver}

    class AnimatedCharacter
    {
        // Attributes
        protected BasicSprite standLeft, standRight, jump, crouch;

        protected BasicAnimatedSprite  walkRigh;   
        
        protected Rectangle pos;
        protected SideDirection direccion;
        protected int incX = 2;
        protected float incY = 2;
        protected Rectangle col;
        protected int heightLimit, widthLimit;
        protected bool collision;
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


            /*if (collision)
            {
             * PARA IMAGENES EN COLISIONES
                direccion = SideDirection.Collision;
            }*/ 


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
                case SideDirection.Jump:
                    {
                        jump.Draw(spriteBatch);
                        break;
                    }
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


