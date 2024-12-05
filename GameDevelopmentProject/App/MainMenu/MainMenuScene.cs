using GameDevelopmentProject.Components.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.App.MainMenu {
    public class MainMenuScene : BaseScene {
        SplashScreen splashScreen;
        DifficultySelectionScreen difficultySelectionScreen;

        public MainMenuScene(Game game) : base(game) {
            splashScreen = new SplashScreen(game);
            difficultySelectionScreen = new DifficultySelectionScreen(game) {
                Active = false,
                Visible = false
            };

            Add(splashScreen);
            Add(difficultySelectionScreen);
        }
    }
}
