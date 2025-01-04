using GameDevelopmentProject.Components.Scenes;
using GameDevelopmentProject.Components.Screens;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.UI.Commands {
    public class MainMenuCommand : BaseCommand {        
        public MainMenuCommand(Game game) : base(game) { }

        public override void Invoke(GameTime gameTime) {
            SceneManager sceneManager = SceneManager.GetInstance(game);

            sceneManager.SetActive("MainMenu");
            BaseObject difficultySelection = sceneManager.activeScene.GetAsObject("DifficultySelection");
            BaseObject splash = sceneManager.activeScene.GetAsObject("Splash");

            difficultySelection.Visible = false;
            difficultySelection.Active = false;
            splash.Visible = true;
            splash.Active = true;
        }
    }
}
