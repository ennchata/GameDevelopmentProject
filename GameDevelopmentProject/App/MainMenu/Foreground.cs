using GameDevelopmentProject.Components.Screens;
using GameDevelopmentProject.Components.UI;
using GameDevelopmentProject.Components.Drawables;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDevelopmentProject.Components.UI.Commands;

namespace GameDevelopmentProject.App.MainMenu
{
    public class Foreground : BaseScreen {
        public Foreground(Game game) : base(game) {
            Add(new ImageDrawable(game) {
                AssetReference = "Images/templogo",
                GlobalAnchor = Anchor.TOP_CENTER,
                LocalAnchor = Anchor.TOP_CENTER,
                Position = new Vector2(0, 10)
            });

            Add(new TextDrawable(game) {
                Text = "game made by Thibo Maes",
                AssetReference = "Fonts/Default",
                Color = Color.White,
                GlobalAnchor = Anchor.TOP_CENTER,
                LocalAnchor = Anchor.TOP_CENTER,
                Position = new Vector2(0, 250)
            });

            Add(new Button(game) {
                ButtonSize = new Vector2(250, 76),
                Text = "Button",
                AssetReference = "Fonts/Default",
                Color = Color.Black,
                GlobalAnchor = Anchor.CENTER,
                LocalAnchor = Anchor.CENTER,
                Commands = new IButtonCommand[] {
                    new DebugCommand(game, "Main menu button")
                }
            });
        }
    }
}
