using GameTest.Models;
using Microsoft.Xna.Framework.Input;

namespace GameTest.Controllers
{
    public class Controller
    {
        private static KeyboardState oldKeyboardState; // static für access in UpdatePlayer

        public static void UpdatePlayer(Player player, Level level)
        {
            KeyboardState newKeyboardState = Keyboard.GetState();

            // Items
            if (newKeyboardState.IsKeyDown(Keys.D1) && oldKeyboardState.IsKeyUp(Keys.D1))
            {
                if (player.Inventory[0] != null)
                {
                    player.Inventory[0].Use(player);
                    player.Inventory[0] = null;
                }
            }

            if (newKeyboardState.IsKeyDown(Keys.D2) && oldKeyboardState.IsKeyUp(Keys.D2))
            {
                if (player.Inventory[1] != null)
                {
                    player.Inventory[1].Use(player);
                    player.Inventory[1] = null;
                }
            }

            if (newKeyboardState.IsKeyDown(Keys.D3) && oldKeyboardState.IsKeyUp(Keys.D3))
            {
                if (player.Inventory[2] != null)
                {
                    player.Inventory[2].Use(player);
                    player.Inventory[2] = null;
                }
            }

            if (newKeyboardState.IsKeyDown(Keys.D4) && oldKeyboardState.IsKeyUp(Keys.D4))
            {
                if (player.Inventory[3] != null)
                {
                    player.Inventory[3].Use(player);
                    player.Inventory[3] = null;
                }
            }

            if (newKeyboardState.IsKeyDown(Keys.D5) && oldKeyboardState.IsKeyUp(Keys.D5))
            {
                if (player.Inventory[4] != null)
                {
                    player.Inventory[4].Use(player);
                    player.Inventory[4] = null;
                }
            }

            if (newKeyboardState.IsKeyDown(Keys.D6) && oldKeyboardState.IsKeyUp(Keys.D6))
            {
                if (player.Inventory[5] != null)
                {
                    player.Inventory[5].Use(player);
                }
            }

            // Movement
            if (newKeyboardState.IsKeyDown(Keys.Left) && oldKeyboardState.IsKeyUp(Keys.Left))
            {
                player.MoveLeft(player.MoveDist, level);
                player.MoveDist = 1;
                Game1.PlayerState = true;
                oldKeyboardState = newKeyboardState;
                return;
            }

            if (newKeyboardState.IsKeyDown(Keys.Right) && oldKeyboardState.IsKeyUp(Keys.Right))
            {
                player.MoveRight(player.MoveDist, level);
                player.MoveDist = 1;
                Game1.PlayerState = true;
                oldKeyboardState = newKeyboardState;
                return;
            }

            if (newKeyboardState.IsKeyDown(Keys.Up) && oldKeyboardState.IsKeyUp(Keys.Up))
            {
                player.MoveUp(player.MoveDist, level);
                player.MoveDist = 1;
                Game1.PlayerState = true;
                oldKeyboardState = newKeyboardState;
                return;
            }

            if (newKeyboardState.IsKeyDown(Keys.Down) && oldKeyboardState.IsKeyUp(Keys.Down))
            {
                player.MoveDown(player.MoveDist, level);
                player.MoveDist = 1;
                Game1.PlayerState = true;
                oldKeyboardState = newKeyboardState; // damit diagonal laufen nicht möglich ist
                return;
            }

            oldKeyboardState = newKeyboardState; // save old state

            // Check Items
            for (int i = 0; i < level.Item.Length; i++)
            {
                if (level.Item[i].WorldX == player.WorldX && level.Item[i].WorldY == player.WorldY && level.Item[i].Visible == true)
                {
                    int b = level.Item[i].Id - 1;
                    player.Inventory[b] = level.Item[i];
                    level.Item[i].Visible = false;
                }
            }

            // Check Keys
            for (int i = 0; i < level.Keys.Length; i++)
            {
                if ((player.WorldX == level.Keys[i].WorldX) && (player.WorldY == level.Keys[i].WorldY && (level.Keys[i].Visible == true)))
                {
                    player.KeyCount++;
                    level.Keys[i].Visible = false;
                }
            }
        }
    }
}
