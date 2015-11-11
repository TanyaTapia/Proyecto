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
    class Hero:AnimatedCharacter
    {
        Keys jump, crouch, right;
        BasicMap map;

        bool jum = true;

        public virtual void setKeys(Keys jump, Keys crouch, Keys Right)
        {
            this.jump = jump;
            this.crouch = crouch;
            this.right = Right;
        }

       public void SetMap(BasicMap theMap)
        {
            map = theMap;
        }
        

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Rectangle currentPos = this.Pos;

        
           
           /* if (Keyboard.GetState().IsKeyDown(crouch))
            {
               
            }*/

            /*if (Keyboard.GetState().IsKeyDown(jump))
            {
              
            }*/
            
            if (Keyboard.GetState().IsKeyDown(right))
            {
                if (currentPos.X <= (widthLimit - currentPos.Width))
                {

                    direccion = SideDirection.Move_Right;
                    walkRigh.Update(gameTime);

                    Rectangle pos = new Rectangle(currentPos.X, currentPos.Y, currentPos.Width, currentPos.Height);
                    
                    pos.X += incX;
                    if (map.VallidateCollision(pos))
                    {
                        currentPos.X += incX;
                        
                    }
                }
            }

            this.Pos = currentPos;


        }
    }
}
