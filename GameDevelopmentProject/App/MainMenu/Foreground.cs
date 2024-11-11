using GameDevelopmentProject.Components.Screens;
using GameDevelopmentProject.Components.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.App.MainMenu {
    public class Foreground : BaseScreen {
        public Foreground(Game game) : base(game) {
            drawables.Add(new ImageDrawable(game) {
                AssetReference = "Images/templogo",
            });
        }
    }
}
