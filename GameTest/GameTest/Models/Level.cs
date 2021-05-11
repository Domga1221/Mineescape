namespace GameTest.Models
{
    public class Level
    {
        public Level(LevelPlaceholder level, Enemy[] enemies)
        {
            this.Item = new Items[level.IitemId.Length];

            // Tiles
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    switch (level.Map[i, j])
                    {
                        case 1:
                            this.Map[i, j] = new Tiles(j * 32, i * 32, false, false, 1);
                            break;
                        case 2:
                            this.Map[i, j] = new Tiles(j * 32, i * 32, false, false, 2);
                            break;
                        case 3:
                            this.Map[i, j] = new Tiles(j * 32, i * 32, false, false, 3);
                            break;
                        case 4:
                            this.Map[i, j] = new Tiles(j * 32, i * 32, false, false, 4);
                            break;
                        case 5:
                            this.Map[i, j] = new Tiles(j * 32, i * 32, true, false, 5);
                            break;
                        case 6:
                            this.Map[i, j] = new Tiles(j * 32, i * 32, true, false, 6);
                            break;
                        case 7:
                            this.Map[i, j] = new Tiles(j * 32, i * 32, true, false, 7);
                            break;
                        case 8:
                            this.Map[i, j] = new Tiles(j * 32, i * 32, true, false, 8);
                            break;
                        case 9:
                            this.Map[i, j] = new Tiles(j * 32, i * 32, true, false, 9);
                            break;
                        case 10:
                            this.Map[i, j] = new Tiles(j * 32, i * 32, true, false, 10);
                            break;
                        case 11:
                            this.Map[i, j] = new Tiles(j * 32, i * 32, true, false, 11);
                            break;
                        case 12:
                            this.Map[i, j] = new Tiles(j * 32, i * 32, true, false, 12);
                            break;
                        case 13:
                            this.Map[i, j] = new Tiles(j * 32, i * 32, false, true, 13);
                            break;
                    }
                }
            }

            // Items
            for (int i = 0; i < level.IitemId.Length; i++)
            {
                switch (level.IitemId[i])
                {
                    case 1:
                        this.Item[i] = new Items("boot", 1, level.ItemLoc[i, 0], level.ItemLoc[i, 1]);
                        break;
                    case 2:
                        this.Item[i] = new Items("cape", 2, level.ItemLoc[i, 0], level.ItemLoc[i, 1]);
                        break;
                    case 3:
                        this.Item[i] = new Items("hook", 3, level.ItemLoc[i, 0], level.ItemLoc[i, 1]);
                        break;
                    case 6:
                        this.Item[i] = new Items("shovel", 6, level.ItemLoc[i, 0], level.ItemLoc[i, 1]);
                        break;
                }
            }

            // Enemies
            for (int i = 0; i < 4; i++)
            {
                enemies[i] = new Enemy(level.EnemyLoc[i, 0], level.EnemyLoc[i, 1]);
            }

            // Keys
            for (int i = 0; i < this.Keys.Length; i++)
            {
                this.Keys[i] = new Items("key", 0, level.KeyLoc[i, 0], level.KeyLoc[i, 1]);
            }
        }

        public Tiles[,] Map { get; set; } = new Tiles[30, 30];

        public Items[] Item { get; }

        public Items[] Keys { get; set; } = new Items[4];
    }
}
