using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Drawables {
    public abstract class BaseDrawable<T> : IBaseObject {
        public string AssetReference;
        public Vector2 Position = Vector2.Zero;
        public Vector2 Size = Vector2.Zero;
        public Rectangle Area { get {
                return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        } }
        public Color Color = Color.White;
        public float Scale = 1f;

        protected T asset;
        protected Game game;

        public BaseDrawable(Game game) {
            this.game = game;
        }

        public virtual void Initialize() { }

        public virtual void LoadContent() {
            asset = game.Content.Load<T>(AssetReference);
        }

        public virtual void UnloadContent() {
            game.Content.UnloadAsset(AssetReference);
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public virtual void Update(GameTime gameTime) { }
    }
}
