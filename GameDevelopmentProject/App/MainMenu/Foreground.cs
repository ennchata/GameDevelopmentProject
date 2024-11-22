using GameDevelopmentProject.Components.Screens;
using GameDevelopmentProject.Components.UI;
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
            });

            Button button = new Button(game) {
                Position = new Vector2(100),
                Size = new Vector2(250, 76),
                Text = "Button",
                AssetReference = "Fonts/Default",
                Color = Color.Aquamarine
            };

            button.Click += (object sender, EventArgs eventArgs) => {
                Debug.WriteLine("click");
            };

            Add(button);

        }
    }
}
