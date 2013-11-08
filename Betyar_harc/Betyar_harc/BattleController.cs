using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Betyar_harc
{
    class BattleController : Controller
    {

        public BattleController(Camera2D cam) {
            camera = cam;
        }

        public override void right()
        {
            System.Diagnostics.Debug.WriteLine("right");
        }

        public override void left()
        {
            System.Diagnostics.Debug.WriteLine("left");
        }

        public override void up()
        {
            System.Diagnostics.Debug.WriteLine("up");
        }

        public override void down()
        {
            System.Diagnostics.Debug.WriteLine("down");
        }

        public override void use()
        {
            System.Diagnostics.Debug.WriteLine("use");
        }

        public override void redo()
        {
            System.Diagnostics.Debug.WriteLine("redo");
        }

        public override void moveRight(GameTime gt) {
            camera.Move(new Vector2(400.0f * (float)gt.ElapsedGameTime.TotalSeconds, 0.0f));
        }

        public override void moveLeft(GameTime gt) {
            camera.Move(new Vector2(-400.0f * (float)gt.ElapsedGameTime.TotalSeconds, 0.0f));
        }

        public override void moveUp(GameTime gt) {
            camera.Move(new Vector2(0.0f, -400.0f * (float)gt.ElapsedGameTime.TotalSeconds));
        }

        public override void moveDown(GameTime gt) {
            camera.Move(new Vector2(0.0f, 400.0f * (float)gt.ElapsedGameTime.TotalSeconds));
        }

        private Camera2D camera;
    }
}
