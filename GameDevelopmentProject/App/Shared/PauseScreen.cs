using GameDevelopmentProject.Components.Drawables;
using GameDevelopmentProject.Components.Screens;
using GameDevelopmentProject.Components.UI.Commands;
using GameDevelopmentProject.Components.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.App.Shared {
    public class PauseScreen : BaseScreen {
        public PauseScreen(Game game) : base(game) {
            Active = false;
            Visible = false;

            Add(new TextDrawable(game) {
                Text = "Game Paused",
                AssetReference = "Fonts/Default",
                Color = Color.White,
                GlobalAnchor = Anchor.TOP_CENTER,
                LocalAnchor = Anchor.TOP_CENTER,
                Position = new Vector2(0, 10)
            });

            Add(new Button(game) {
                ButtonSize = new Vector2(300, 60),
                Position = new Vector2(0, 100),
                Text = "Resume",
                AssetReference = "Fonts/Default",
                Color = Color.Black,
                GlobalAnchor = Anchor.TOP_CENTER,
                LocalAnchor = Anchor.TOP_CENTER,
                Commands = new IButtonCommand[] {
                    new GamePauseCommand(game, false)
                }
            });

            Add(new Button(game) {
                ButtonSize = new Vector2(300, 60),
                Position = new Vector2(0, 100),
                Text = "Quit",
                AssetReference = "Fonts/Default",
                Color = Color.White,
                BackgroundColor = Color.Red,
                GlobalAnchor = Anchor.TOP_CENTER,
                LocalAnchor = Anchor.TOP_CENTER,
                Commands = new IButtonCommand[] {
                    new DebugCommand(game, "Quit")
                }
            });
        }
    }
}
