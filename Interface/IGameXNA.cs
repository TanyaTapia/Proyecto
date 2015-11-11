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
    interface IGameXNA
    {
        void LoadContent(ContentManager Content, String name);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        //Método para hacer colisiones
        bool Colision(Rectangle rect);
    }
}
