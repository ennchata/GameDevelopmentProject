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
        public Vector2 Position {
            get { return position + GetGlobalOffset() + GetLocalOffset(); }
            set {
                position = value;
            }
        }
        public Vector2 Size = Vector2.Zero;
        public Rectangle Area { get {
                return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        } }
        public Color Color = Color.White;
        public float Scale = 1f;
        public Anchor GlobalAnchor = Anchor.TOP_LEFT; // where 0,0 is in global coordinates
        public Anchor LocalAnchor = Anchor.TOP_LEFT; // where 0,0 is inside the element

        protected T asset;
        protected Game game;
        protected Vector2 position;

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

        private Vector2 GetGlobalOffset() {
            float x = 0;
            float y = 0;

            switch (GlobalAnchor) {
                case Anchor.TOP_CENTER: case Anchor.CENTER: case Anchor.BOTTOM_CENTER:
                    x = game.GraphicsDevice.Viewport.Width / 2f;
                    break;
                case Anchor.TOP_RIGHT: case Anchor.CENTER_RIGHT: case Anchor.BOTTOM_RIGHT:
                    x = game.GraphicsDevice.Viewport.Width;
                    break;
            }
            switch (GlobalAnchor) {
                case Anchor.CENTER_LEFT: case Anchor.CENTER: case Anchor.CENTER_RIGHT:
                    y = game.GraphicsDevice.Viewport.Height / 2f;
                    break;
                case Anchor.BOTTOM_LEFT: case Anchor.BOTTOM_CENTER: case Anchor.BOTTOM_RIGHT:
                    y = game.GraphicsDevice.Viewport.Height;
                    break;
            }

            return new Vector2(x, y);
        }

        private Vector2 GetLocalOffset() {
            float x = 0;
            float y = 0;

            switch (LocalAnchor) {
                case Anchor.TOP_CENTER: case Anchor.CENTER: case Anchor.BOTTOM_CENTER:
                    x = Size.X / 2f;
                    break;
                case Anchor.TOP_RIGHT: case Anchor.CENTER_RIGHT: case Anchor.BOTTOM_RIGHT:
                    x = Size.X;
                    break;
            }
            switch (LocalAnchor) {
                case Anchor.CENTER_LEFT: case Anchor.CENTER: case Anchor.CENTER_RIGHT:
                    y = Size.Y / 2f;
                    break;
                case Anchor.BOTTOM_LEFT: case Anchor.BOTTOM_CENTER: case Anchor.BOTTOM_RIGHT:
                    y = Size.Y;
                    break;
            }

            return new Vector2(-x, -y);
        }
    }
}
