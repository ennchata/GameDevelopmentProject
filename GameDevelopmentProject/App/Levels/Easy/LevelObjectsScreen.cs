using GameDevelopmentProject.Components.Drawables;
using GameDevelopmentProject.Components.Gameplay;
using GameDevelopmentProject.Components.Screens;
using GameDevelopmentProject.Components.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.App.Levels.Easy {
    public class LevelObjectsScreen : BaseScreen {
        public LevelObjectsScreen(Game game) : base(game) {
            Add(new Collectible(game) {
                Position = new Vector2(0, 50)
            });

            Add(new Player(game));
            Add(new PauseHandler(game, "LevelEasy"));
        }
    }
}
