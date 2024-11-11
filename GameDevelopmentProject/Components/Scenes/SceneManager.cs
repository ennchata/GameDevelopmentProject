using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Scenes {
    public class SceneManager {
        public Dictionary<string, BaseScene> scenes = new Dictionary<string, BaseScene>();
        public BaseScene activeScene;

        private Game game;
        private static SceneManager instance;
        private static readonly object threadLock = new object();

        private SceneManager(Game game) {
            this.game = game;
            scenes.Add("MainMenu", new App.MainMenu.Scene(game));
            activeScene = scenes["MainMenu"];
        }

        public static SceneManager GetInstance(Game game) {
            if (instance == null) {
                lock (threadLock) {
                    if (instance == null) instance = new SceneManager(game);
                }
            }
            return instance;
        }
    }
}
