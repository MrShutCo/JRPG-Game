using JRPG_Game.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

namespace JRPG_Game {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public StateStack gGameMode = new StateStack();


        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here
            gGameMode.Add("mainmenu", new MainMenuState());
            gGameMode.Add("gamestate", new GameState());

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            TexturePool.AddTexture("menuscreen", Content.Load<Texture2D>("mainmenu"));
            TexturePool.AddTexture("button", Content.Load<Texture2D>("button"));

            TexturePool.AddTexture("dialogue", Content.Load<Texture2D>("DialogueBox"));
            TexturePool.AddTexture("select", Content.Load<Texture2D>("Selector"));

            TexturePool.AddFont("dialogue_font", Content.Load<SpriteFont>("Main Font"));

            TexturePool.AddTexture("robot_l", Content.Load<Texture2D>("robot_l"));
            TexturePool.AddTexture("robot_r", Content.Load<Texture2D>("robot_r"));
            TexturePool.AddTexture("robot_u", Content.Load<Texture2D>("robot_u"));
            TexturePool.AddTexture("robot_d", Content.Load<Texture2D>("robot_d"));

            //ReadTileSheets();
            TexturePool.AddTileSheet("World Tiles",new TileSheet(GraphicsDevice, Content.Load<Texture2D>("World Tiles"),32,32));
            TexturePool.AddTileSheet("Objects", new TileSheet(GraphicsDevice, Content.Load<Texture2D>("Objects"), 32, 32));

            gGameMode.Push("mainmenu");
            gGameMode.Push("gamestate");

            // TODO: use this.Content to load your game content here
        }

        public void ReadTileSheets() {
            string[] sheets = Directory.GetFiles("../../../../tilesheets/", "*.png");
            List<string> sheetss = new List<string>();
            foreach (string s in sheets) {
                sheetss.Add(s.TrimEnd('.', 'p', 'n', 'g'));
            }
            foreach (string s in sheets) {
                
                TexturePool.AddTileSheet(Path.GetFileName(s), new TileSheet(GraphicsDevice, Content.Load<Texture2D>(Path.GetFileName(s)),32,32));
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            gGameMode.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            gGameMode.Render(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
