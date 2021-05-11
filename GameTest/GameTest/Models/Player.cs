namespace GameTest.Models
{
    public class Player
    {
        public Player(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.WorldX = x / 32;
            this.WorldY = y / 32;
            this.KeyCount = 0;
            this.MoveDist = 1;
            this.CloakedTurns = 0;
            this.ViewDist = 5;
            this.ViewDistTurns = 0;
            this.Visible = true;
            this.Inventory = new Items[6];
        }

        public float X { get; set; }

        public float Y { get; set; }

        public int WorldX { get; set; }

        public int WorldY { get; set; }

        public int KeyCount { get; set; }

        public int MoveDist { get; set; }

        public int CloakedTurns { get; set; }

        public int ViewDist { get; set; }

        public int ViewDistTurns { get; set; }

        public bool Visible { get; set; }

        public Items[] Inventory { get; set; }

        // Bewegung
        // WorldX entspricht der Spalte im Array
        // WorldY entspricht der Zeile im Array
        public void MoveLeft(int i, Level level)
        {
            for (int j = 1; j <= i; j++)
            {
                if (level.Map[this.WorldY, this.WorldX - j].Solid == true)
                {
                    return;
                }
            }

            this.X = this.X - (i * 32);
            this.WorldX = this.WorldX - i;
        }

        public void MoveRight(int i, Level level)
        {
            for (int j = 1; j <= i; j++)
            {
                if (level.Map[this.WorldY, this.WorldX + j].Solid == true)
                {
                    return;
                }
            }

            this.X = this.X + (i * 32);
            this.WorldX = this.WorldX + i;
        }

        public void MoveUp(int i, Level level)
        {
            for (int j = 1; j <= i; j++)
            {
                if (level.Map[this.WorldY - j, this.WorldX].Solid == true)
                {
                    return;
                }
            }

            this.Y = this.Y - (i * 32);
            this.WorldY = this.WorldY - i;
        }

        public void MoveDown(int i, Level level)
        {
            for (int j = 1; j <= i; j++)
            {
                if (level.Map[this.WorldY + j, this.WorldX].Solid == true)
                {
                    return;
                }
            }

            this.Y = this.Y + (i * 32);
            this.WorldY = this.WorldY + i;
        }
    }
}
