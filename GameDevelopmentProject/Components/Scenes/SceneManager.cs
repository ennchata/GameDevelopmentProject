﻿using GameDevelopmentProject.App.GameOver;
using GameDevelopmentProject.App.Levels.Easy;
using GameDevelopmentProject.App.Levels.Normal;
using GameDevelopmentProject.App.MainMenu;
using GameDevelopmentProject.App.Pause;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Scenes {
    public class SceneManager {
        public Dictionary<string, BaseScene> scenes;
        public BaseScene activeScene;

        private Game game;
        private static SceneManager instance;
        private static readonly object threadLock = new object();

        private SceneManager(Game game) {
            this.game = game;
            scenes =  new Dictionary<string, BaseScene>();

            SetActive("MainMenu", new MainMenuScene(game));
            Add("LevelEasy", new LevelEasyScene(game));
            Add("PauseLevelEasy", new PauseScene(game, "LevelEasy"));
            Add("LevelNormal", new LevelNormalScene(game));
            Add("PauseLevelNormal", new PauseScene(game, "LevelNormal"));

            Add("GameOver", new GameOverScene(game));
            Add("GameWon", new GameOverScene(game, "You Won!"));
        }

        public static SceneManager GetInstance(Game game) {
            if (instance == null) {
                lock (threadLock) {
                    if (instance == null) instance = new SceneManager(game);
                }
            }
            return instance;
        }

        public void Add(string identifier, BaseScene scene) {
            scenes.Add(identifier, scene);
        }

        public void SetActive(string identifier) {
            BaseScene scene;
            if (scenes.TryGetValue(identifier, out scene)) activeScene = scene;
        }

        public void SetActive(string identifier, BaseScene scene) {
            Add(identifier, scene);
            SetActive(identifier);
        }
    }
}
