using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Betyar_harc
{
    class Camera2D
    {
        public Camera2D(Viewport viewport)
        {
            Origin = new Vector2(viewport.Width / 2.0f, viewport.Height / 2.0f);
            _viewport = viewport;
        }
 
        public Vector2 Position { get; set; }
        public Vector2 Origin { get; set; }
 
        public Matrix GetViewMatrix(Vector2 parallax)
        {
            // To add parallax, simply multiply it by the position
            return Matrix.CreateTranslation(new Vector3(-Position * parallax, 0.0f)) *
                   // The next line has a catch. See note below.
                   Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                   Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
        }


        public void LookAt(Vector2 position)
        {
            Position = position - new Vector2(_viewport.Width / 2.0f, _viewport.Height / 2.0f);
        }

        public void Move(Vector2 displacement)
        {
            Position += displacement;
        }

        private readonly Viewport _viewport;
    }
}
