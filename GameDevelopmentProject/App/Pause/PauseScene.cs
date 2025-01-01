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
        public PauseScene(Game game, string origin) : base(game) {
            Add("Control", new ControlScreen(game, origin));
        }
    }
}
