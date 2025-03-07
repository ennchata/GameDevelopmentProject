﻿using GameDevelopmentProject.App.Levels.Easy;
using GameDevelopmentProject.App.MainMenu;
using GameDevelopmentProject.App.Pause;
using GameDevelopmentProject.Components.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevelopmentProject {
    public class BaseGame : Game {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SceneManager sceneManager;

        public BaseGame() {
            graphics = new GraphicsDeviceManager(this);
            sceneManager = SceneManager.GetInstance(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            foreach (var scene in sceneManager.scenes) scene.Value.LoadContent();
        }

        protected override void Update(GameTime gameTime) {
            sceneManager.activeScene.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            sceneManager.activeScene.Draw(gameTime, spriteBatch);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
