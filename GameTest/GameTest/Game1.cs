using GameTest.Controllers;
using GameTest.Models;
using GameTest.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// Hier ist der Test kommentar
    /// Test für Merge
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GameContent gameContent;
        private int screenWidth = 0;
        private int screenHeight = 0;
        private Level level;
        private Player player;
        private Enemy[] enemies;
        private int levelSelect;
        private int roundCount;

        private GameState currentGameState = GameState.MainMenu;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1129:Do not use default value type constructor", Justification = "<Weil c# 7.0 veraltet ist>")]
        private MouseState mouseOld = new MouseState(); // Default Constructor verwenden weil Stylecop?

        // Main Menu
        private Button playButton;
        private Button quitButton;
        private Button controlsButton;

        // Level select
        private Button level1Button;
        private Button level2Button;
        private Button level3Button;
        private Button backButton;

        // Victory / Defeat Screen
        private Button retryButton;
        private Button mainMenuButton;
        private Button quitButton2;

        // Controls
        private Button backButton2;

        public Game1()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }

        private enum GameState
        {
            MainMenu,
            Controls,
            Playing,
            Defeat,
            Victory,
            Initialize,
            LevelSelect,
        }

        public static bool PlayerState { get; set; }

        public static bool ShovelInUse { get; set; }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            // TODO: use this.Content to load your game content here
            this.gameContent = new GameContent(this.Content);
            this.screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            this.screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            // set game to 502x700 or screen max if smaller
            if (this.screenWidth >= 1920)
            {
                this.screenWidth = 1056;
            }

            if (this.screenHeight >= 1080)
            {
                this.screenHeight = 1056;
            }

            this.graphics.PreferredBackBufferWidth = this.screenWidth;
            this.graphics.PreferredBackBufferHeight = this.screenHeight;
            this.graphics.ApplyChanges();

            this.IsMouseVisible = true;

            // Main Menu
            this.playButton = new Button(100, 527);  // 350 300

            this.quitButton = new Button(754, 527);

            this.controlsButton = new Button(427, 527);

            // LevelSelect
            this.level1Button = new Button(100, 527);

            this.level2Button = new Button(427, 527);

            this.level3Button = new Button(754, 527);

            this.backButton = new Button(427, 327);

            // Victory / Defeat Screen
            this.retryButton = new Button(100, 745); // 745

            this.mainMenuButton = new Button(427, 745);

            this.quitButton2 = new Button(756, 745);

            // Controls
            this.backButton2 = new Button(100, 900);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (this.IsActive == false)
            {
                return;  // our window is not active don't update
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            // TODO: Add your update logic here

            MouseState mouse = Mouse.GetState();

            switch (this.currentGameState)
            {
                case GameState.MainMenu:
                    this.playButton.Update(mouse, this.mouseOld);
                    if (this.playButton.IsClicked == true)
                    {
                        this.currentGameState = GameState.LevelSelect;
                    }

                    this.quitButton.Update(mouse, this.mouseOld);
                    if (this.quitButton.IsClicked == true)
                    {
                        this.Exit();
                    }

                    this.controlsButton.Update(mouse, this.mouseOld);
                    if (this.controlsButton.IsClicked == true)
                    {
                        this.currentGameState = GameState.Controls;
                    }

                    break;

                case GameState.Playing:
                    this.IsMouseVisible = false;

                    if (ShovelInUse)
                    {
                        Items.UseShovel2(this.player, this.level);
                        return;
                    }

                    Controller.UpdatePlayer(this.player, this.level);

                    if ((this.level.Map[this.player.WorldY, this.player.WorldX].IsExit == true) && this.player.KeyCount == this.level.Keys.Length)
                    {
                        this.currentGameState = GameState.Victory;
                    }

                    // check if dead before it divides by 0 in enemy.update
                    for (int i = 0; i < this.enemies.Length; i++)
                    {
                        if (this.player.WorldX == this.enemies[i].WorldX && this.player.WorldY == this.enemies[i].WorldY)
                        {
                            this.currentGameState = GameState.Defeat;
                            return;
                        }
                    }

                    if (PlayerState == true)
                    {
                        this.roundCount++;

                        if (this.player.CloakedTurns > 0)
                        {
                            this.player.CloakedTurns--;
                        }

                        if (this.player.ViewDistTurns > 0)
                        {
                            this.player.ViewDistTurns--;
                        }

                        if (this.player.ViewDistTurns == 0 && this.player.ViewDist > 5)
                        {
                            this.player.ViewDist = 5;
                        }

                        for (int i = 0; i < this.enemies.Length; i++)
                        {
                            this.enemies[i].Update(this.level, this.player);
                            if (this.player.WorldX == this.enemies[i].WorldX && this.player.WorldY == this.enemies[i].WorldY)
                            {
                                this.currentGameState = GameState.Defeat;
                            }
                        }

                        PlayerState = false;
                    }

                    break;

                case GameState.Controls:
                    this.IsMouseVisible = true;

                    this.backButton2.Update(mouse, this.mouseOld);
                    if (this.backButton2.IsClicked == true)
                    {
                        this.currentGameState = GameState.MainMenu;
                    }

                    break;

                case GameState.Victory:
                    this.IsMouseVisible = true;

                    this.retryButton.Update(mouse, this.mouseOld);
                    if (this.retryButton.IsClicked == true)
                    {
                        this.currentGameState = GameState.Initialize;
                    }

                    this.mainMenuButton.Update(mouse, this.mouseOld);
                    if (this.mainMenuButton.IsClicked == true)
                    {
                        this.currentGameState = GameState.MainMenu;
                    }

                    this.quitButton2.Update(mouse, this.mouseOld);
                    if (this.quitButton2.IsClicked == true)
                    {
                        this.Exit();
                    }

                    break;

                case GameState.Defeat:
                    this.IsMouseVisible = true;

                    this.retryButton.Update(mouse, this.mouseOld);
                    if (this.retryButton.IsClicked == true)
                    {
                        this.currentGameState = GameState.Initialize;
                        this.retryButton.IsClicked = false;
                    }

                    this.mainMenuButton.Update(mouse, this.mouseOld);
                    if (this.mainMenuButton.IsClicked == true)
                    {
                        this.currentGameState = GameState.MainMenu;
                    }

                    this.quitButton2.Update(mouse, this.mouseOld);
                    if (this.quitButton2.IsClicked == true)
                    {
                        this.Exit();
                    }

                    break;

                case GameState.Initialize:
                    PlayerState = false;
                    ShovelInUse = false;
                    this.roundCount = 0;
                    this.enemies = new Enemy[4];

                    if (this.levelSelect == 1)
                    {
                        this.level = new Level(Placeholders.Level1, this.enemies);
                        this.player = new Player(32, 32);
                    }

                    if (this.levelSelect == 2)
                    {
                        this.level = new Level(Placeholders.Level2, this.enemies);
                        this.player = new Player(448, 448);
                    }

                    if (this.levelSelect == 3)
                    {
                        this.level = new Level(Placeholders.Level3, this.enemies);
                        this.player = new Player(32, 32);
                    }

                    this.currentGameState = GameState.Playing;
                    break;

                case GameState.LevelSelect:
                    this.IsMouseVisible = true;

                    // Level1Button
                    this.level1Button.Update(mouse, this.mouseOld);
                    if (this.level1Button.IsClicked == true)
                    {
                        this.levelSelect = 1;
                        this.currentGameState = GameState.Initialize;
                        this.level1Button.IsClicked = false;
                    }

                    // Level2Button
                    this.level2Button.Update(mouse, this.mouseOld);
                    if (this.level2Button.IsClicked == true)
                    {
                        this.levelSelect = 2;
                        this.currentGameState = GameState.Initialize;
                        this.level2Button.IsClicked = false;
                    }

                    // Level3Button
                    this.level3Button.Update(mouse, this.mouseOld);
                    if (this.level3Button.IsClicked == true)
                    {
                        this.levelSelect = 3;
                        this.currentGameState = GameState.Initialize;
                        this.level3Button.IsClicked = false;
                    }

                    // BackButton
                    this.backButton.Update(mouse, this.mouseOld);
                    if (this.backButton.IsClicked == true)
                    {
                        this.currentGameState = GameState.MainMenu;
                        this.backButton.IsClicked = false;
                    }

                    break;
            }

            this.mouseOld = mouse;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            this.spriteBatch.Begin();

            switch (this.currentGameState)
            {
                case GameState.MainMenu:
                    // Background
                    this.spriteBatch.Draw(this.gameContent.MainMenu, new Rectangle(0, 0, this.screenWidth, this.screenHeight), Color.White);

                    // Button Play
                    Drawer.DrawButton(this.spriteBatch, this.gameContent, this.playButton);
                    Drawer.DrawTextInButton(this.spriteBatch, this.gameContent, this.playButton, "Play");

                    // Button Controls
                    Drawer.DrawButton(this.spriteBatch, this.gameContent, this.controlsButton);
                    Drawer.DrawTextInButton(this.spriteBatch, this.gameContent, this.controlsButton, "Controls");

                    // Button Quit
                    Drawer.DrawButton(this.spriteBatch, this.gameContent, this.quitButton);
                    Drawer.DrawTextInButton(this.spriteBatch, this.gameContent, this.quitButton, "Quit");
                    break;

                case GameState.Playing:
                    // Level
                    for (int i = 0; i < 30; i++)
                    {
                        for (int j = 0; j < 30; j++)
                        {
                             Vector2 middleOfPlayer = new Vector2(this.player.X + 16, this.player.Y + 16);
                             Vector2 middleOfTile = new Vector2(this.level.Map[i, j].X + 16, this.level.Map[i, j].Y + 16);
                             float distanceToPlayer = Vector2.Distance(middleOfTile, middleOfPlayer);

                             if (this.player.ViewDist * 32 > distanceToPlayer)
                            {
                                Drawer.DrawLevel(this.level.Map[i, j], this.spriteBatch, this.gameContent);
                            }
                        }
                    }

                    // Items
                    for (int i = 0; i < this.level.Item.Length; i++)
                    {
                        Vector2 middleOfPlayer = new Vector2(this.player.X + 16, this.player.Y + 16);
                        Vector2 middleOfTile = new Vector2(this.level.Item[i].X + 16, this.level.Item[i].Y + 16);
                        float distanceToPlayer = Vector2.Distance(middleOfTile, middleOfPlayer);
                        if (this.player.ViewDist * 32 > distanceToPlayer)
                        {
                            Drawer.DrawItems(this.level.Item[i], this.spriteBatch, this.gameContent);
                        }
                    }

                    // Keys
                    for (int i = 0; i < this.level.Keys.Length; i++)
                    {
                        Vector2 middleOfPlayer = new Vector2(this.player.X + 16, this.player.Y + 16);
                        Vector2 middleOfTile = new Vector2(this.level.Keys[i].X + 16, this.level.Keys[i].Y + 16);
                        float distanceToPlayer = Vector2.Distance(middleOfTile, middleOfPlayer);
                        if (this.player.ViewDist * 32 > distanceToPlayer)
                        {
                            Drawer.DrawKeys(this.level.Keys[i], this.spriteBatch, this.gameContent);
                        }
                    }

                    // Player
                    Drawer.DrawPlayer(this.player, this.spriteBatch, this.gameContent);

                    // Enemies
                    for (int i = 0; i < this.enemies.Length; i++)
                    {
                        Vector2 middleOfPlayer = new Vector2(this.player.X + 16, this.player.Y + 16);
                        Vector2 middleOfTile = new Vector2(this.enemies[i].X + 16, this.enemies[i].Y + 16);
                        float distanceToPlayer = Vector2.Distance(middleOfTile, middleOfPlayer);
                        if (this.player.ViewDist * 32 > distanceToPlayer)
                        {
                            Drawer.DrawEnemy(this.enemies[i], this.spriteBatch, this.gameContent);
                        }
                    }

                    if ((this.level.Map[this.player.WorldY, this.player.WorldX].IsExit == true) && this.player.KeyCount == 4)
                    {
                        this.spriteBatch.DrawString(this.gameContent.Font, "You won", new Vector2(100, 100), Color.White);
                    }

                    // HUD
                    Drawer.DrawHUD(this.spriteBatch, this.gameContent, this.player);

                    string scoreMsg = "Score: " + this.player.KeyCount.ToString("0");
                    this.spriteBatch.DrawString(this.gameContent.Font, scoreMsg, new Vector2(50, 960), Color.White);

                    string roundCountMsg = "Round: " + this.roundCount.ToString("0");
                    this.spriteBatch.DrawString(this.gameContent.Font, roundCountMsg, new Vector2(400, 960), Color.White);
                    break;

                case GameState.Controls:
                    // Background
                    this.spriteBatch.Draw(this.gameContent.Controls, new Rectangle(0, 0, this.screenWidth, this.screenHeight), Color.White);

                    // BackButton2
                    Drawer.DrawButton(this.spriteBatch, this.gameContent, this.backButton2);
                    Drawer.DrawTextInButton(this.spriteBatch, this.gameContent, this.backButton2, "Back");

                    // Text
                    this.spriteBatch.DrawString(this.gameContent.Font, "Movement", new Vector2(100, 425), Color.White);
                    this.spriteBatch.DrawString(this.gameContent.Font, "Items", new Vector2(100, 700), Color.White);
                    break;

                case GameState.Victory:
                    // Background
                    this.spriteBatch.Draw(this.gameContent.Background, new Rectangle(0, 0, this.screenWidth, this.screenHeight), Color.White);

                    // VictoryBanner
                    this.spriteBatch.Draw(this.gameContent.VictoryBanner, new Vector2(0, 411), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);

                    // RetryButton
                    Drawer.DrawButton(this.spriteBatch, this.gameContent, this.retryButton);
                    Drawer.DrawTextInButton(this.spriteBatch, this.gameContent, this.retryButton, "Retry");

                    // MainMenuButton
                    Drawer.DrawButton(this.spriteBatch, this.gameContent, this.mainMenuButton);
                    Drawer.DrawTextInButton(this.spriteBatch, this.gameContent, this.mainMenuButton, "Menu");

                    // QuitButton2
                    Drawer.DrawButton(this.spriteBatch, this.gameContent, this.quitButton2);
                    Drawer.DrawTextInButton(this.spriteBatch, this.gameContent, this.quitButton2, "Quit");
                    break;

                case GameState.Defeat:
                    // Background
                    this.spriteBatch.Draw(this.gameContent.Background, new Rectangle(0, 0, this.screenWidth, this.screenHeight), Color.White);

                    // DefeatBanner
                    this.spriteBatch.Draw(this.gameContent.DefeatBanner, new Vector2(0, 411), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);

                    // RetryButton
                    Drawer.DrawButton(this.spriteBatch, this.gameContent, this.retryButton);
                    Drawer.DrawTextInButton(this.spriteBatch, this.gameContent, this.retryButton, "Retry");

                    // MainMenuButton
                    Drawer.DrawButton(this.spriteBatch, this.gameContent, this.mainMenuButton);
                    Drawer.DrawTextInButton(this.spriteBatch, this.gameContent, this.mainMenuButton, "Menu");

                    // QuitButton2
                    Drawer.DrawButton(this.spriteBatch, this.gameContent, this.quitButton2);
                    Drawer.DrawTextInButton(this.spriteBatch, this.gameContent, this.quitButton2, "Quit");
                    break;

                case GameState.LevelSelect:
                    this.spriteBatch.Draw(this.gameContent.Background2, new Rectangle(0, 0, this.screenWidth, this.screenHeight), Color.White);

                    // Level1Button
                    Drawer.DrawButton(this.spriteBatch, this.gameContent, this.level1Button);
                    Drawer.DrawTextInButton(this.spriteBatch, this.gameContent, this.level1Button, "Level1");

                    // Level2Button
                    Drawer.DrawButton(this.spriteBatch, this.gameContent, this.level2Button);
                    Drawer.DrawTextInButton(this.spriteBatch, this.gameContent, this.level2Button, "Level2");

                    // Level3Button
                    Drawer.DrawButton(this.spriteBatch, this.gameContent, this.level3Button);
                    Drawer.DrawTextInButton(this.spriteBatch, this.gameContent, this.level3Button, "Level3");

                    // BackButton
                    Drawer.DrawButton(this.spriteBatch, this.gameContent, this.backButton);
                    Drawer.DrawTextInButton(this.spriteBatch, this.gameContent, this.backButton, "Back");
                    break;
            }

            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
