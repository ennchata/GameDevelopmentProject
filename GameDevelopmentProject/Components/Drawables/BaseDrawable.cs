using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Drawables {
    public abstract class BaseDrawable<T> : IBaseDrawable {
        public string AssetReference;
        public Vector2 Position = Vector2.Zero;
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
    }
}
