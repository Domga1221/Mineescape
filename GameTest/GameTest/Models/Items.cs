using Microsoft.Xna.Framework.Input;

namespace GameTest.Models
{
    public class Items
    {
        private static KeyboardState oldKeyboardState;
        private readonly string name;

        // 0-Key 1-Boot 2-Cape 3-Hook 4-Pistol 5-Shield 6-Shovel

        public Items(string name, int id, int x, int y)
        {
            this.name = name;
            this.Id = id;
            this.X = x;
            this.Y = y;
            this.WorldX = x / 32;
            this.WorldY = y / 32;
            this.Visible = true;
        }

        public int Id { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public int WorldX { get; set; }

        public int WorldY { get; set; }

        public bool Visible { get; set; }

        public static void UseShovel2(Player player, Level level)
        {
            KeyboardState newKeyboardState = Keyboard.GetState();
            int x = player.WorldX;
            int y = player.WorldY;

            if (newKeyboardState.IsKeyDown(Keys.Left) && oldKeyboardState.IsKeyUp(Keys.Left))
            {
                x = x - 1;
                if (level.Map[y, x].Solid == true && level.Map[y, x].Id != 5 && level.Map[y, x].Id != 6
                    && level.Map[y, x].Id != 7 && level.Map[y, x].Id != 8 && level.Map[y, x].Id != 9)
                {
                    level.Map[y, x].Solid = false;
                    level.Map[y, x].Id = 1;
                    Game1.ShovelInUse = false;
                    player.Inventory[5] = null;
                    return;
                }
            }

            if (newKeyboardState.IsKeyDown(Keys.Right) && oldKeyboardState.IsKeyUp(Keys.Right))
            {
                x = x + 1;
                if (level.Map[y, x].Solid == true && level.Map[y, x].Id != 5 && level.Map[y, x].Id != 6
                    && level.Map[y, x].Id != 7 && level.Map[y, x].Id != 8 && level.Map[y, x].Id != 9)
                {
                    level.Map[y, x].Solid = false;
                    level.Map[y, x].Id = 1;
                    Game1.ShovelInUse = false;
                    player.Inventory[5] = null;
                    return;
                }
            }

            if (newKeyboardState.IsKeyDown(Keys.Up) && oldKeyboardState.IsKeyUp(Keys.Up))
            {
                y = y - 1;
                if (level.Map[y, x].Solid == true && level.Map[y, x].Id != 5 && level.Map[y, x].Id != 6
                    && level.Map[y, x].Id != 7 && level.Map[y, x].Id != 8 && level.Map[y, x].Id != 9)
                {
                    level.Map[y, x].Solid = false;
                    level.Map[y, x].Id = 1;
                    Game1.ShovelInUse = false;
                    player.Inventory[5] = null;
                    return;
                }
            }

            if (newKeyboardState.IsKeyDown(Keys.Down) && oldKeyboardState.IsKeyUp(Keys.Down))
            {
                y = y + 1;
                if (level.Map[y, x].Solid == true && level.Map[y, x].Id != 5 && level.Map[y, x].Id != 6
                    && level.Map[y, x].Id != 7 && level.Map[y, x].Id != 8 && level.Map[y, x].Id != 9)
                {
                    level.Map[y, x].Solid = false;
                    level.Map[y, x].Id = 1;
                    Game1.ShovelInUse = false;
                    player.Inventory[5] = null;
                    return;
                }
            }

            if (newKeyboardState.IsKeyDown(Keys.Z) && oldKeyboardState.IsKeyUp(Keys.Z))
            {
                Game1.ShovelInUse = false;
                return;
            }

            oldKeyboardState = newKeyboardState;
        }

        public void Use(Player player)
        {
            if (this.Id == 1)
            {
                player.MoveDist = 3;
            }

            if (this.Id == 2)
            {
                player.CloakedTurns = 5;
            }

            if (this.Id == 3)
            {
                player.ViewDist = 8;
                player.ViewDistTurns = 10;
            }

            if (this.Id == 6)
            {
                Game1.ShovelInUse = true;
            }
        }
    }
}
