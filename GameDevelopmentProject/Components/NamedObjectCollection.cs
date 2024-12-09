using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components {
    public class NamedObjectCollection<T> : BaseObject where T : IBaseObject {
        public Dictionary<string, T> gameObjects;

        public NamedObjectCollection(Game game) : base(game) {
            gameObjects = new Dictionary<string, T>();
        }

        public override void Initialize() {
            foreach (var gameObject in gameObjects) gameObject.Value.Initialize();
        }

        public override void LoadContent() {
            foreach (var gameObject in gameObjects) gameObject.Value.LoadContent();
        }

        public override void UnloadContent() {
            foreach (var gameObject in gameObjects) gameObject.Value.UnloadContent();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            foreach (var gameObject in gameObjects) {
                if (gameObject.Value._Visible()) gameObject.Value.Draw(gameTime, spriteBatch);
            }
        }

        public override void Update(GameTime gameTime) {
            foreach (var gameObject in gameObjects) {
                if (gameObject.Value._Active()) gameObject.Value.Update(gameTime);
            }
        }

        public void Add(string identifier, T gameObject) {
            gameObjects.Add(identifier, gameObject);
        }

        public void Remove(string identifier, T gameObject) {
            gameObjects.Remove(identifier, out gameObject);
        }

        public T Get(string identifier) {
            gameObjects.TryGetValue(identifier, out T gameObject);
            return gameObject;
        }

        public BaseObject GetAsObject(string identifier) {
            gameObjects.TryGetValue(identifier, out T gameObject);
            return gameObject as BaseObject;
        }
    }
}
