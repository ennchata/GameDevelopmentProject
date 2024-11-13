using GameDevelopmentProject.Components.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.App.MainMenu {
    public class Scene : BaseScene {
        public Scene(Game game) : base(game) {
            Add(new Foreground(game));
        }
    }
}
