﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Drawables {
    public abstract class BaseDrawable<T> : BaseObject {
        public string AssetReference;
        public Vector2 Position {
            get { 
                return position 
                    + GetOffset(GlobalAnchor, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height) 
                    + GetOffset(LocalAnchor, -Size.X, -Size.Y); }
            set {
                position = value;
            }
        }
        public Vector2 Size {
            get { return size; }
            set { size = value; }
        }
        public Rectangle Area { get {
                return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        } }
        public Color Color = Color.White;
        public float Scale = 1f;
        public Anchor GlobalAnchor = Anchor.TOP_LEFT; // where 0,0 is in global coordinates
        public Anchor LocalAnchor = Anchor.TOP_LEFT; // where 0,0 is inside the element

        protected T asset;
        protected Vector2 position;
        protected Vector2 size = Vector2.Zero;

        public BaseDrawable(Game game) : base(game) { }

        public override void LoadContent() {
            asset = game.Content.Load<T>(AssetReference);
        }

        public override void UnloadContent() {
            game.Content.UnloadAsset(AssetReference);
        }

        public override void Update(GameTime gameTime) { }

        protected Vector2 GetOffset(Anchor anchor, float width, float height) {
            float x = 0;
            float y = 0;

            switch (anchor) {
                case Anchor.TOP_CENTER: case Anchor.CENTER: case Anchor.BOTTOM_CENTER:
                    x = width / 2f;
                    break;
                case Anchor.TOP_RIGHT: case Anchor.CENTER_RIGHT: case Anchor.BOTTOM_RIGHT:
                    x = width;
                    break;
            }
            switch (anchor) {
                case Anchor.CENTER_LEFT: case Anchor.CENTER: case Anchor.CENTER_RIGHT:
                    y = height / 2f;
                    break;
                case Anchor.BOTTOM_LEFT: case Anchor.BOTTOM_CENTER: case Anchor.BOTTOM_RIGHT:
                    y = height;
                    break;
            }

            return new Vector2(x, y);
        }
    }
}
