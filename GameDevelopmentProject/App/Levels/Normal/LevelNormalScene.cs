using GameDevelopmentProject.Components.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.App.Levels.Normal {
    public class LevelNormalScene : BaseScene {
        public LevelNormalScene(Game game) : base(game) {
            Add("Objects", new ObjectsScreen(game));
        }
    }
}
