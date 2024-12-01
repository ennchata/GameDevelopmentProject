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

namespace GameDevelopmentProject.App.MainMenu {
    public class Foreground : BaseScreen {
        public Foreground(Game game) : base(game) {
            Add(new ImageDrawable(game) {
                AssetReference = "Images/templogo",
                GlobalAnchor = Anchor.TOP_CENTER,
                LocalAnchor = Anchor.TOP_CENTER,
                Position = new Vector2(0, 10)
            });

            Button button = new Button(game) {
                Size = new Vector2(250, 76),
                Text = "Button",
                AssetReference = "Fonts/Default",
                Color = Color.Aquamarine,
                GlobalAnchor = Anchor.CENTER,
                LocalAnchor = Anchor.CENTER
            };

            button.Click += (object sender, EventArgs eventArgs) => {
                Debug.WriteLine("click");
            };

            Add(button);

        }
    }
}
