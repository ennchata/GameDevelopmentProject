using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.UI.Commands {
    public abstract class ButtonCommand : IButtonCommand {
        protected Game game;

        public ButtonCommand(Game game) {
            this.game = game;
        }

        public abstract void Invoke(GameTime gameTime);
    }
}
