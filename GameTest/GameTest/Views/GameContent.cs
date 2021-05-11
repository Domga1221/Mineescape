using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameTest.Views
{
    public class GameContent
    {
        public GameContent(ContentManager content)
        {
            // load images
            // Ground
            this.GroundBasic = content.Load<Texture2D>("GroundBasic");

            this.Ground1 = content.Load<Texture2D>("Ground-1");

            this.Ground2 = content.Load<Texture2D>("Ground-2");

            this.Ground3 = content.Load<Texture2D>("Ground-3");

            // Border
            this.CornerBorder = content.Load<Texture2D>("CornerBorder");

            this.BottomBorder = content.Load<Texture2D>("BottomBorderV2");

            this.LeftBorder = content.Load<Texture2D>("LeftBorder");

            this.RightBorder = content.Load<Texture2D>("RightBorderBlue");

            this.TopBorder = content.Load<Texture2D>("TopBorder");

            // Wall
            this.Wall1 = content.Load<Texture2D>("WallV1");

            this.Wall2 = content.Load<Texture2D>("WallV2");

            this.Wall3 = content.Load<Texture2D>("WallV3");

            // Exit
            this.Exit = content.Load<Texture2D>("Exit");

            // Player
            this.Player = content.Load<Texture2D>("PlayerHolderRed");

            // Enemy
            this.Enemy = content.Load<Texture2D>("EnemyV1");

            // Item
            this.Boot = content.Load<Texture2D>("ItemBootV2");

            this.Cape = content.Load<Texture2D>("ItemCape");

            this.Hook = content.Load<Texture2D>("ItemHookV1");

            this.Key = content.Load<Texture2D>("ItemKey");

            this.Pistol = content.Load<Texture2D>("ItemPistolV1");

            this.Shield = content.Load<Texture2D>("ItemShieldV2");

            this.Shovel = content.Load<Texture2D>("ItemShovel");

            this.Torch = content.Load<Texture2D>("ItemTorch");

            // HUD
            this.Sidebar = content.Load<Texture2D>("Sidebar");

            this.Bottombar = content.Load<Texture2D>("Bottombar");

            this.Emblem = content.Load<Texture2D>("Emblem");

            this.Boot64 = content.Load<Texture2D>("ItemBoot64");

            this.Cape64 = content.Load<Texture2D>("ItemCape64");

            this.Hook64 = content.Load<Texture2D>("ItemHook64");

            this.Pistol64 = content.Load<Texture2D>("ItemPistol64");

            this.Shield64 = content.Load<Texture2D>("ItemShield64");

            this.Shovel64 = content.Load<Texture2D>("ItemShovel64");

            this.Torch64 = content.Load<Texture2D>("ItemTorch64");

            // Menu
            this.Button = content.Load<Texture2D>("Button");

            this.MainMenu = content.Load<Texture2D>("Main Menu");

            this.Background = content.Load<Texture2D>("Background");

            this.Background2 = content.Load<Texture2D>("Background2");

            this.VictoryBanner = content.Load<Texture2D>("VictoryBanner");

            this.DefeatBanner = content.Load<Texture2D>("DefeatBanner");

            this.Controls = content.Load<Texture2D>("Controls");

            // Font
            this.Font = content.Load<SpriteFont>("Arial20");
        }

        // Ground
        public Texture2D GroundBasic { get; set; } // 1

        public Texture2D Ground1 { get; set; } // 2

        public Texture2D Ground2 { get; set; } // 3

        public Texture2D Ground3 { get; set; } // 4

        // Border
        public Texture2D CornerBorder { get; set; } // 5

        public Texture2D BottomBorder { get; set; } // 6

        public Texture2D LeftBorder { get; set; } // 7

        public Texture2D RightBorder { get; set; } // 8

        public Texture2D TopBorder { get; set; } // 9

        // Wall
        public Texture2D Wall1 { get; set; } // 10

        public Texture2D Wall2 { get; set; } // 11

        public Texture2D Wall3 { get; set; } // 12

        // Exit
        public Texture2D Exit { get; set; } // 13

        // Player
        public Texture2D Player { get; set; } // 14

        // Enemy
        public Texture2D Enemy { get; set; } // 15

        // Item
        public Texture2D Boot { get; set; } // 16

        public Texture2D Cape { get; set; } // 17

        public Texture2D Hook { get; set; } // 18

        public Texture2D Key { get; set; } // 19

        public Texture2D Pistol { get; set; } // 20

        public Texture2D Shield { get; set; } // 21

        public Texture2D Shovel { get; set; } // 22

        public Texture2D Torch { get; set; }

        // HUD
        public Texture2D Sidebar { get; set; }

        public Texture2D Bottombar { get; set; }

        public Texture2D Emblem { get; set; }

        public Texture2D Boot64 { get; set; }

        public Texture2D Cape64 { get; set; }

        public Texture2D Hook64 { get; set; }

        public Texture2D Pistol64 { get; set; }

        public Texture2D Shield64 { get; set; }

        public Texture2D Shovel64 { get; set; }

        public Texture2D Torch64 { get; set; }

        // Menu
        public Texture2D Button { get; set; }

        public Texture2D MainMenu { get; set; }

        public Texture2D Background { get; set; }

        public Texture2D Background2 { get; set; }

        public Texture2D VictoryBanner { get; set; }

        public Texture2D DefeatBanner { get; set; }

        public Texture2D Controls { get; set; }

        // Font
        public SpriteFont Font { get; set; }
    }
}
