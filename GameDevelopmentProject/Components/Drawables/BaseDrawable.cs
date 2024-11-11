using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Drawables {
    public abstract class BaseDrawable<T> : DrawableGameComponent {
        public string AssetReference;
        public Vector2 Position;
        public Color Color = Color.White;
        public float Scale = 1f;

        protected T asset;
        protected Game game;

        public BaseDrawable(Game game) : base(game) {
            this.game = game;
        }

        public new void LoadContent() {
            asset = game.Content.Load<T>(AssetReference);
        }

        public new void UnloadContent() {
            game.Content.UnloadAsset(AssetReference);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
    }
}
