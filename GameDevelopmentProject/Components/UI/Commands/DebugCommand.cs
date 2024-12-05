using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.UI.Commands {
    public class DebugCommand : ButtonCommand {
        private string message;

        public DebugCommand(Game game, string message) : base(game) {
            this.message = message;
        }

        public override void Invoke(GameTime gameTime) {
            Debug.WriteLine(message);
        }
    }
}
