using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.Collections;

namespace Interface
{
    class BasicAnimatedSprite : AbstractSprite
    {
        //Atributos

        int frameCount;          //LLeva el numero de cuadros
        int currentFrame;        //Cuadro actual dibujar
        ArrayList textureList;   //Arreglo para las imagenes multiples
        float timer;             //Calcular tiempo para mostrar cada cuadro
        float timePerFrame;      //cuanto tiempo va a ser mostrado cada cuadro
        bool multipleFiles;      //para sabes si se estan cargando animaciones multiples o no
        int frameWidth;          //ancho del cuadro
        int frameHeight;         //alto del cuadro
        bool collision;          //Regresa un verdadero o falso para saber si hubo colision
        String dirName;


        //Parámetros para una sola imagen
        public void SetParameters(String dirName, int frameWidth, int frameHeight, int frameCount, float timePerFrame)
         {
            this.dirName = dirName;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameCount = frameCount;
            this.timePerFrame = timePerFrame;
            multipleFiles = false;
         }

        public void SetParameters(String dirName, int frameCount, float timePerFrame)
        {
            this.frameCount = frameCount;
            this.dirName = dirName;
            this.timePerFrame = timePerFrame;
            multipleFiles = true;
        }

        public override void LoadContent(ContentManager Content, string name)
        {
            if (multipleFiles)
            {
                this.textureList = new ArrayList();
                // Carga todas las imagenes
                for (int k = 1; k <= frameCount; k++)
                {
                    Texture2D tex;
                    tex = Content.Load<Texture2D>(dirName + "/" + name + k.ToString("00"));
                    textureList.Add(tex);
                }
                pos = new Rectangle(0, 0, ((Texture2D)textureList[0]).Width, ((Texture2D)textureList[0]).Height);
            }
            else
            {
                image = Content.Load<Texture2D>(dirName + "/" + name);

                // Este rectangulo es para la imagen en general, no para el tamaño del cuadro a recorrer
                pos = new Rectangle(0, 0, frameWidth, frameHeight);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            timer = timer + (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= timePerFrame)
            {
                currentFrame = (currentFrame + 1) % frameCount;
                timer = timer - timePerFrame;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            // Draw animated sprite based on multiple files
            if (multipleFiles)
            {
                if (currentFrame < textureList.Count)
                {
                    if (collision)
                    {
                        Texture2D tex = (Texture2D)textureList[currentFrame];
                        spriteBatch.Draw(tex, pos, Color.Red);
                    }
                    else
                    {
                        Texture2D tex = (Texture2D)textureList[currentFrame];
                        spriteBatch.Draw(tex, pos, Color.White);
                    }
                }
            }
            // Draw animated sprite based on single file with multiple frames
            else
            {
                int xTex, yTex;
                Rectangle sourceRect;

                xTex = currentFrame * frameWidth;
                yTex = 0;
                sourceRect = new Rectangle(xTex, yTex, frameWidth, frameHeight);
                if (collision)
                {
                    spriteBatch.Draw(image, pos, sourceRect, Color.Red);
                }
                else
                    spriteBatch.Draw(image, pos, sourceRect, Color.White);
            }
            collision = false;
            spriteBatch.End();
        }

        public override bool Colision(Rectangle rect)
        {
            collision = pos.Intersects(rect);
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
