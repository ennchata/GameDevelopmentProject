using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.UI.Commands {
    public abstract class BaseCommand : IButtonCommand {
        protected Game game;

        public BaseCommand(Game game) {
            this.game = game;
        }

        public abstract void Invoke(GameTime gameTime);
    }
}
