using GameDevelopmentProject.Components.Drawables;
using GameDevelopmentProject.Components.Screens;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.App.Pause {
    public class ControlScreen : BaseScreen {
        public ControlScreen(Game game) : base(game) {
            Add(new TextDrawable(game) {
                Text = "Game Paused",
                AssetReference = "Fonts/Default",
                Color = Color.White,
                GlobalAnchor = Anchor.TOP_CENTER,
                LocalAnchor = Anchor.TOP_CENTER,
                Position = new Vector2(0, 10)
            });
        }
    }
}
