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
    class Cactus : Enemy
    {

        Random myRand = new Random();


        public void LoadCac1(ContentManager Content)
        {
            this.Cactus1(Content, "Cactus", "Cactus1");
        }
        public void LoadCac2(ContentManager Content)
        {
            this.Cactus2(Content, "Cactus", "Cactus2");

        }
        public void LoadCac3(ContentManager Content)
        {
            this.Cactus3(Content, "Cactus", "Cactus3");
        }

        
    }
}
