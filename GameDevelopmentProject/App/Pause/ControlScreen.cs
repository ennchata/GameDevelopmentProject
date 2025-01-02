using GameDevelopmentProject.Components.Drawables;
using GameDevelopmentProject.Components.Screens;
using GameDevelopmentProject.Components.UI;
using GameDevelopmentProject.Components.UI.Commands;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.App.Pause {
    public class ControlScreen : BaseScreen {
        public ControlScreen(Game game, string origin) : base(game) {
            Add(new PauseHandler(game, origin, true));
            Add(new TextDrawable(game) {
                Text = "Game Paused",
                AssetReference = "Fonts/Default",
                Color = Color.White,
                GlobalAnchor = Anchor.TOP_CENTER,
                LocalAnchor = Anchor.TOP_CENTER,
                Position = new Vector2(0, 10)
            });

            Add(new TextDrawable(game) {
                Text = "Press Esc to continue game",
                AssetReference = "Fonts/Default",
                Color = Color.Yellow,
                GlobalAnchor = Anchor.TOP_CENTER,
                LocalAnchor = Anchor.TOP_CENTER,
                Position = new Vector2(0, 50)
            });

            Add(new Button(game) {
                ButtonSize = new Vector2(300, 60),
                Position = new Vector2(0, 100),
                Text = "Quit Game",
                AssetReference = "Fonts/Default",
                Color = Color.White,
                BackgroundColor = Color.Red,
                HoverColor = Color.Lerp(Color.Red, Color.Black, 0.15f),
                GlobalAnchor = Anchor.TOP_CENTER,
                LocalAnchor = Anchor.TOP_CENTER,
                Commands = new IButtonCommand[] {
                    new GameExitCommand(game)
                }
            });
        }
    }
}
