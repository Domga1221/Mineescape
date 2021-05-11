namespace GameTest.Models
{
    public class Tiles
    {
        public Tiles(float x, float y, bool solid, bool isExit, int id)
        {
            this.Id = id;
            this.X = x;
            this.Y = y;
            this.Visible = true;
            this.Solid = solid;
            this.IsExit = isExit;
        }

        public int Id { get; set; }

        public float X { get; set; } // x position of brick on screen

        public float Y { get; set; } // y position of brick on screen

        public bool Visible { get; set; } // does brick still exist?

        public bool Solid { get; set; }

        public bool IsExit { get; set; }
    }
}
