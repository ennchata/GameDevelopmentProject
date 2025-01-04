using GameDevelopmentProject.Components.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.App.GameOver {
    public class GameOverScene : BaseScene {
        public GameOverScene(Game game) : base(game) {
            Add("Control", new ControlScreen(game));
        }
    }
}
