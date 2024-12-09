using GameDevelopmentProject.Components.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.UI.Commands {
    public class ScreenVisibleCommand : BaseCommand {
        private string identifier;
        private bool? status;

        public ScreenVisibleCommand(Game game, string identifier, bool? status) : base(game) {
            this.identifier = identifier;
            this.status = status;
        }

        public override void Invoke(GameTime gameTime) {
            BaseObject item = SceneManager.GetInstance(game).activeScene.GetAsObject(identifier);

            if (status == null) item.Visible = !item.Visible;
            else item.Visible = (bool)status;
        }
    }
}
