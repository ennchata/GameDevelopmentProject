using GameDevelopmentProject.Components.Drawables;
using GameDevelopmentProject.Components.Screens;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.App.Levels.Easy {
    public class LevelObjectsScreen : BaseScreen {
        public LevelObjectsScreen(Game game) : base(game) {
            Add(new SpriteSheetDrawable(game) {
                AssetReference = "Images/basic-sheet",
                Source = new Rectangle(0, 0, 25, 25),
                GlobalAnchor = Anchor.CENTER,
                LocalAnchor = Anchor.CENTER
            });
        }
    }
}
