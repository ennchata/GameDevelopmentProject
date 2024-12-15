using GameDevelopmentProject.Components.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.UI.Commands {
    public class GamePauseCommand : BaseCommand {
        private bool? status;

        public GamePauseCommand(Game game, bool? status) : base(game) {
            this.status = status;
        }

        public override void Invoke(GameTime gameTime) {
            SceneManager sceneManager = SceneManager.GetInstance(game);

            if (status != null) sceneManager.GamePaused = !sceneManager.GamePaused;
            else sceneManager.GamePaused = (bool)status;

        }
    }
}
