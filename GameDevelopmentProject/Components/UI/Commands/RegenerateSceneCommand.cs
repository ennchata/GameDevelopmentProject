using GameDevelopmentProject.Components.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.UI.Commands {
    public class RegenerateSceneCommand : BaseCommand {
        private string scene;
        private string origin;

        public RegenerateSceneCommand(Game game, string scene, string origin = "") : base(game) {
            this.scene = scene;
            this.origin = origin;
        }

        public override void Invoke(GameTime gameTime) {
            SceneManager sceneManager = SceneManager.GetInstance(game);

            sceneManager.SetActive(scene);
            foreach (var item in sceneManager.activeScene.gameObjects) {
                item.Value.DestroyObjects();
                item.Value.CreateObjects();
                item.Value.LoadContent();
            }

            if (origin != "") sceneManager.SetActive(origin);
        }

    }
}
