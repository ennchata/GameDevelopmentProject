using GameDevelopmentProject.Components.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.App.MainMenu {
    public class MainMenuScene : BaseScene {
        public MainMenuScene(Game game) : base(game) {
            Add(new SplashScreen(game));
        }
    }
}
