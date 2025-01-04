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
            List<ICollidable> list = new List<ICollidable>();

            // THIS IS HORRIBLE BUT IT WORKS
            foreach(var collection in gameObjects
                .Where(_ => _ is ScoreConditionalCollection<BaseObject>)
                .Select(_ => _ as ScoreConditionalCollection<BaseObject>)
                .Where(_ => _.Active)) {
                list.AddRange(collection.gameObjects.Where(_ => _ is ICollidable).Select(_ => _ as ICollidable));
            }

            list.AddRange(gameObjects.Where(_ => _ is ICollidable).Select(_ => _ as ICollidable));

            return list;
        }

        public abstract void CreateObjects();

        public void DestroyObjects() {
            gameObjects.Clear();
        }
    }
}
