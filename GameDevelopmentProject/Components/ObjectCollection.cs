using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDevelopmentProject.Components.Screens;

namespace GameDevelopmentProject.Components {
    public class ObjectCollection<T> : BaseObject where T : IBaseObject {
        public List<T> gameObjects;

        public ObjectCollection(Game game): base(game) {
            gameObjects = new List<T>();
        }

        public override void Initialize() {
            foreach (T gameObject in gameObjects) gameObject.Initialize();
        }

        public override void LoadContent() {
            foreach (T gameObject in gameObjects) gameObject.LoadContent();
        }

        public override void UnloadContent() {
            foreach (T gameObject in gameObjects) gameObject.UnloadContent();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            foreach (T gameObject in gameObjects) {
                if (gameObject._Visible()) gameObject.Draw(gameTime, spriteBatch);
            }
        }

        public override void Update(GameTime gameTime) {
            foreach (T gameObject in gameObjects) {
                if (gameObject._Active()) gameObject.Update(gameTime);
            }
        }

        public void Add(T gameObject) {
            gameObjects.Add(gameObject);
        }

        public void Remove(T gameObject) {
            gameObjects.Remove(gameObject);
        }
    }
}
