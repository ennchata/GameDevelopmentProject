using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.UI.Commands {
    public class VisibleCommand : BaseCommand {
        private BaseObject item;
        private bool? status;

        public VisibleCommand(Game game, BaseObject item, bool? status) : base(game) {
            this.item = item;
            this.status = status;
        }

        public override void Invoke(GameTime gameTime) {
            if (status == null) item.Visible = !item.Visible;
            else item.Visible = (bool)status;
        }
    }
}
