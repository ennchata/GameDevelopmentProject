using GameDevelopmentProject.Components.Screens;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Scenes {
    public class BaseScene : ObjectCollection<IBaseScreen> {
        public BaseScene(Game game) : base(game) { }
    }
}
