using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDevelopmentProject.Components.Screens;

namespace GameDevelopmentProject.Components {
    public class ObjectCollection<T> where T : IBaseObject {
        public List<T> gameObjects = new List<T>();

        private Game game;

        public ObjectCollection(Game game) {
            this.game = game;
        }

        public virtual void Initialize() {
            foreach (T gameObject in gameObjects) gameObject.Initialize();
        }

        public virtual void LoadContent() {
            foreach (T gameObject in gameObjects) gameObject.LoadContent();
        }

        public virtual void UnloadContent() {
            foreach (T gameObject in gameObjects) gameObject.UnloadContent();
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            foreach (T gameObject in gameObjects) gameObject.Draw(gameTime, spriteBatch);
        }

        public virtual void Update(GameTime gameTime) {
            foreach (T gameObject in gameObjects) gameObject.Update(gameTime);
        }
    }
}
