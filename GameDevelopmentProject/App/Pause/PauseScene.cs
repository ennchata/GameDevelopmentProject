using GameDevelopmentProject.Components.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameDevelopmentProject.App.Pause {
    public class PauseScene : BaseScene {
        private string origin;
        public PauseScene(Game game, string origin) : base(game) {
            this.origin = origin;

            Add("Control", new ControlScreen(game));
        }
    }
}
