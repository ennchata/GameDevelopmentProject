using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.UI.Commands {
    public class GameExitCommand : ButtonCommand {
        public GameExitCommand(Game game) : base(game) { }

        public override void Invoke(GameTime gameTime) {
            game.Exit();
        }
    }
}
