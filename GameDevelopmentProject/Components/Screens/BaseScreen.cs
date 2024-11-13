using GameDevelopmentProject.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Screens {
    public abstract class BaseScreen : IBaseObject {
        public List<IBaseObject> gameObjects = new List<IBaseObject>();

        private Game game;

        public BaseScreen(Game game) {
            this.game = game;
        }

        public virtual void Initialize() {
            foreach (IBaseObject gameObject in gameObjects) gameObject.Initialize();
        }

        public virtual void LoadContent() {
            foreach (IBaseObject gameObject in gameObjects) gameObject.LoadContent();
        }

        public virtual void UnloadContent() {
            foreach (IBaseObject gameObject in gameObjects) gameObject.UnloadContent();
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            foreach (IBaseObject gameObject in gameObjects) gameObject.Draw(gameTime, spriteBatch);
        }

        public virtual void Update(GameTime gameTime) {
            foreach (IBaseObject gameObject in gameObjects) gameObject.Update(gameTime);
        }
    }
}
