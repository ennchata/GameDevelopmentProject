using GameDevelopmentProject.Components;
using GameDevelopmentProject.Components.Gameplay;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Screens {
    public abstract class BaseScreen : ObjectCollection<IBaseObject>, IBaseScreen {
        public BaseScreen(Game game) : base(game) { }

        public List<ICollidable> GetCollidables() {
            return gameObjects.Where(_ => _ is ICollidable).Select(_ => _ as ICollidable).ToList();
        }

        public abstract void CreateObjects();

        public void DestroyObjects() {
            gameObjects.Clear();
        }
    }
}
