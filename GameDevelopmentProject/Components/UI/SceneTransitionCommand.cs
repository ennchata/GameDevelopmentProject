using GameDevelopmentProject.Components.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.UI {
    public class SceneTransitionCommand : ButtonCommand {
        private string scene;

        public SceneTransitionCommand(Game game, string scene) : base(game) {
            this.scene = scene;
        }

        public override void Invoke(GameTime gameTime) {
            SceneManager.GetInstance(game).SetActive(scene);
        }
    }
}
