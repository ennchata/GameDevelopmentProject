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
using GameDevelopmentProject.Components.Scenes;

namespace GameDevelopmentProject.App.MainMenu
{
    public class SplashScreen : BaseScreen {
        public SplashScreen(Game game) : base(game) {
            Add(new ImageDrawable(game) {
                AssetReference = "Images/templogo",
                GlobalAnchor = Anchor.TOP_CENTER,
                LocalAnchor = Anchor.TOP_CENTER,
                Position = new Vector2(0, 50)
            });

            Add(new TextDrawable(game) {
                Text = "made by Thibo Maes",
                AssetReference = "Fonts/Default",
                Color = Color.White,
                GlobalAnchor = Anchor.TOP_CENTER,
                LocalAnchor = Anchor.TOP_CENTER,
                Position = new Vector2(0, 250)
            });

            Add(new Button(game) {
                ButtonSize = new Vector2(300, 60),
                Position = new Vector2(0, -250),
                Text = "Start Game",
                AssetReference = "Fonts/Default",
                Color = Color.Black,
                GlobalAnchor = Anchor.BOTTOM_CENTER,
                LocalAnchor = Anchor.CENTER,
                Commands = new IButtonCommand[] {
                    new SceneTransitionCommand(game, "LevelEasy")
                }
            });

            Add(new Button(game) {
                ButtonSize = new Vector2(300, 60),
                Position = new Vector2(0, -160),
                Text = "Exit to Desktop",
                AssetReference = "Fonts/Default",
                Color = Color.White,
                BackgroundColor = Color.Red,
                HoverColor = Color.Lerp(Color.Red, Color.Black, 0.15f),
                GlobalAnchor = Anchor.BOTTOM_CENTER,
                LocalAnchor = Anchor.CENTER,
                Commands = new IButtonCommand[] {
                    new GameExitCommand(game)
                }
            });
        }
    }
}
