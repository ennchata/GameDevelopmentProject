using GameDevelopmentProject.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Screens {
    public abstract class BaseScreen : ObjectCollection<IBaseObject> {
        public BaseScreen(Game game) : base(game) { }
    }
}
