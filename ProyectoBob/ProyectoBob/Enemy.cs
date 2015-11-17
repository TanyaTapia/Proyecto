using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;


//Los enemigos tendran en comun el movimiento automatico y la capacidad de restar vidas a Bob
namespace ProyectoBob
{
    class Enemy : AnimatedCharacter  
    {
        
        public virtual void ColisionCactus(Rectangle rect)
        {
            for ( int i=0; i< Cactu.Count; i++)
            {
                ((BasicSprite)Cactu[i]).Colision(rect);
            }
        }


    }
}
