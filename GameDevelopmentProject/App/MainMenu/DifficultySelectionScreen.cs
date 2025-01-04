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

namespace GameDevelopmentProject.App.MainMenu {
    public class DifficultySelectionScreen : BaseScreen {
        public DifficultySelectionScreen(Game game) : base(game) {
            CreateObjects();
        }

        public override void CreateObjects() {
            Add(new TextDrawable(game) {
                Text = "Select Difficulty Level",
                AssetReference = "Fonts/Default",
                Color = Color.White,
                GlobalAnchor = Anchor.TOP_CENTER,
                LocalAnchor = Anchor.TOP_CENTER,
                Position = new Vector2(0, 10)
            });

            Add(new Button(game) {
                ButtonSize = new Vector2(300, 60),
                Position = new Vector2(0, 100),
                Text = "Easy",
                AssetReference = "Fonts/Default",
                Color = Color.Black,
                GlobalAnchor = Anchor.TOP_CENTER,
                LocalAnchor = Anchor.TOP_CENTER,
                Commands = new IButtonCommand[] {
                    new RegenerateSceneCommand(game, "LevelEasy", "MainMenu"),
                    new SceneTransitionCommand(game, "LevelEasy")
                }
            });
        }
    }
}
