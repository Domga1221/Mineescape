using GameTest.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameTest.Views
{
    public class Drawer
    {
        public static void DrawPlayer(Player player, SpriteBatch spriteBatch, GameContent gameContent)
        {
            Texture2D texture = gameContent.Player;

            if (player.CloakedTurns > 0)
            {
                spriteBatch.Draw(texture, new Vector2(player.X, player.Y), null, new Color(Color.Violet, 0.5f), 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
                return;
            }

            spriteBatch.Draw(texture, new Vector2(player.X, player.Y), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
        }

        public static void DrawEnemy(Enemy enemy, SpriteBatch spriteBatch, GameContent gameContent)
        {
            Texture2D texture = gameContent.Enemy;

            spriteBatch.Draw(texture, new Vector2(enemy.X, enemy.Y), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
        }

        public static void DrawLevel(Tiles tile, SpriteBatch spriteBatch, GameContent gameContent)
        {
            Texture2D texture = gameContent.Ground1;
            int id = tile.Id;

            switch (id)
            {
                case 1:
                    texture = gameContent.GroundBasic;
                    break;
                case 2:
                    texture = gameContent.Ground1;
                    break;
                case 3:
                    texture = gameContent.Ground2;
                    break;
                case 4:
                    texture = gameContent.Ground3;
                    break;
                case 5:
                    texture = gameContent.CornerBorder;
                    break;
                case 6:
                    texture = gameContent.BottomBorder;
                    break;
                case 7:
                    texture = gameContent.LeftBorder;
                    break;
                case 8:
                    texture = gameContent.RightBorder;
                    break;
                case 9:
                    texture = gameContent.TopBorder;
                    break;
                case 10:
                    texture = gameContent.Wall1;
                    break;
                case 11:
                    texture = gameContent.Wall2;
                    break;
                case 12:
                    texture = gameContent.Wall3;
                    break;
                case 13:
                    texture = gameContent.Exit;
                    break;
            }

            if (tile.Visible)
            {
                spriteBatch.Draw(texture, new Vector2(tile.X, tile.Y), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
            }
        }

        public static void DrawItems(Items item, SpriteBatch spriteBatch, GameContent gameContent)
        {
            Texture2D texture = gameContent.Key;
            int id = item.Id;

            // 0-Key 1-Boot 2-Cape 3-Hook 4-Pistol 5-Shield 6-Shovel
            switch (id)
            {
                case 1:
                    texture = gameContent.Boot;
                    break;
                case 2:
                    texture = gameContent.Cape;
                    break;
                case 3:
                    texture = gameContent.Torch;
                    break;
                case 4:
                    texture = gameContent.Pistol;
                    break;
                case 5:
                    texture = gameContent.Shield;
                    break;
                case 6:
                    texture = gameContent.Shovel;
                    break;
            }

            if (item.Visible)
            {
                spriteBatch.Draw(texture, new Vector2(item.X, item.Y), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
            }
        }

        public static void DrawKeys(Items item, SpriteBatch spriteBatch, GameContent gameContent)
        {
            Texture2D texture = gameContent.Key;

            if (item.Visible)
            {
                spriteBatch.Draw(texture, new Vector2(item.X, item.Y), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
            }
        }

        public static void DrawTiles(Tiles tile, SpriteBatch spriteBatch, GameContent gameContent)
        {
            Texture2D texture = gameContent.Ground1;
            if (tile.Visible)
            {
                spriteBatch.Draw(texture, new Vector2(tile.X, tile.Y), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
            }
        }

        public static void DrawHUD(SpriteBatch spriteBatch, GameContent gameContent, Player player)
        {
            Texture2D texture = gameContent.Sidebar;
            int a = 32 * 30;

            // Sidebar
            spriteBatch.Draw(texture, new Vector2(a, 0), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);

            // Emblem
            texture = gameContent.Emblem;
            spriteBatch.Draw(texture, new Vector2(a, a), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);

            // Bottombar
            texture = gameContent.Bottombar;
            spriteBatch.Draw(texture, new Vector2(0, a), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);

            int b = texture.Width;
            spriteBatch.Draw(texture, new Vector2(b, a), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);

            b = b + texture.Width;
            spriteBatch.Draw(texture, new Vector2(b, a), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);

            // Items
            // 0-Key 1-Boot 2-Cape 3-Hook 4-Pistol 5-Shield 6-Shovel
            // 976 71
            // 976 222
            // 976 373

            // 976 523
            // 976 674
            // 976 825

            int x = 976;
            int y;

            for (int i = 0; i < player.Inventory.Length; i++)
            {
                y = 71;

                if (i == 4)
                {
                    y = y - 1;
                }

                if (player.Inventory[i] == null)
                {
                    continue;
                }

                y = y + (i * 151);

                switch (player.Inventory[i].Id)
                {
                    case 1:
                        texture = gameContent.Boot64;
                        spriteBatch.Draw(texture, new Vector2(x, y), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
                        break;
                    case 2:
                        texture = gameContent.Cape64;
                        spriteBatch.Draw(texture, new Vector2(x, y), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
                        break;
                    case 3:
                        texture = gameContent.Torch64;
                        spriteBatch.Draw(texture, new Vector2(x, y), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
                        break;
                    case 4:
                        texture = gameContent.Pistol64;
                        spriteBatch.Draw(texture, new Vector2(x, y), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
                        break;
                    case 5:
                        texture = gameContent.Shield64;
                        spriteBatch.Draw(texture, new Vector2(x, y), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
                        break;
                    case 6:
                        texture = gameContent.Shovel64;
                        spriteBatch.Draw(texture, new Vector2(x, y), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
                        break;
                }
            }
        }

        public static void DrawButton(SpriteBatch spriteBatch, GameContent gameContent, Button button)
        {
            Texture2D texture = gameContent.Button;
            spriteBatch.Draw(texture, new Vector2(button.X, button.Y), null, button.Color, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
        }

        public static void DrawTextInButton(SpriteBatch spriteBatch, GameContent gameContent, Button button, string str)
        {
            Vector2 middlePoint = new Vector2(button.X + (button.Size.X / 2), button.Y + (button.Size.Y / 2));
            Vector2 textSize = gameContent.Font.MeasureString(str);
            Vector2 textMiddlePoint = new Vector2(textSize.X / 2, textSize.Y / 2);
            Vector2 textPosition = new Vector2((int)(middlePoint.X - textMiddlePoint.X), (int)(middlePoint.Y - textMiddlePoint.Y));
            spriteBatch.DrawString(gameContent.Font, str, textPosition, Color.White);
        }
    }
}
