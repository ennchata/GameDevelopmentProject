using GameDevelopmentProject.Components.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.App.Levels.Easy {
    public class LevelEasyScene : BaseScene {
        public LevelEasyScene(Game game) : base(game) {
            Add("LevelObjects", new LevelObjectsScreen(game));
        }
    }
}
