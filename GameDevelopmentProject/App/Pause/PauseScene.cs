using GameDevelopmentProject.Components.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameDevelopmentProject.App.Pause {
    public class PauseScene : BaseScene {
        private string origin;
        private bool debounce = true;

        public PauseScene(Game game, string origin) : base(game) {
            this.origin = origin;

            Add("Control", new ControlScreen(game));
        }

        public override void Update(GameTime gameTime) {
            KeyboardState state = Keyboard.GetState();
            if (!debounce && state.IsKeyDown(Keys.Escape)) SceneManager.GetInstance(game).SetActive(origin);

            debounce = state.IsKeyDown(Keys.Escape);
            base.Update(gameTime);
        }
    }
}
