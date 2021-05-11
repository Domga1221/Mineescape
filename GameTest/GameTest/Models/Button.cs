using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameTest.Models
{
    public class Button
    {
        private bool down;

        public Button(int x, int y)
        {
            this.Size = new Vector2(200, 100);
            this.X = x;
            this.Y = y;
            this.Color = new Color(255, 255, 255, 255);
        }

        public Color Color { get; private set; }

        public int X { get; private set; }

        public int Y { get; private set; }

        public Vector2 Size { get; private set; }

        public bool IsClicked { get; set; }

        public void Update(MouseState mouse, MouseState oldMouse)
        {
            Rectangle rectangle = new Rectangle(this.X, this.Y, (int)this.Size.X, (int)this.Size.Y);
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);
            Console.WriteLine("rectX: " + this.X + "rectY:" + this.Y);
            Console.WriteLine("MouseX: " + mouse.X + "MouseY: " + mouse.Y);

            bool b = mouseRectangle.Intersects(rectangle);

            if (b)
            {
                Console.WriteLine("intersect: " + b);
                if (this.Color.A == 255)
                {
                    this.down = false;
                }

                if (this.Color.A == 0)
                {
                    this.down = true;
                }

                if (this.down == true)
                {
                    var c = this.Color;
                    c.A += +3;
                    this.Color = c;
                }
                else
                {
                    var c = this.Color;
                    c.A -= 3;
                    this.Color = c;
                }

                if (mouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released)
                {
                    this.IsClicked = true;
                }
            }
            else if (this.Color.A < 255)
            {
                var c = this.Color;
                c.A += +3;
                this.Color = c;
                this.IsClicked = false;
            }
        }
    }
}