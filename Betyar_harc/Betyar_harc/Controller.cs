using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Betyar_harc
{
    abstract class Controller
    {
        abstract public void right();
        abstract public void left();
        abstract public void up();
        abstract public void down();
        abstract public void use(); // enter
        abstract public void redo(); // backspace
        abstract public void moveRight(GameTime gt);
        abstract public void moveLeft(GameTime gt);
        abstract public void moveUp(GameTime gt);
        abstract public void moveDown(GameTime gt);
    }
}
