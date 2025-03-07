﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Drawables {
    public class TextDrawable : BaseDrawable<SpriteFont> {
        public string Text;

        public TextDrawable(Game game) : base(game) { }

        public override void LoadContent() {
            base.LoadContent();
            Size = asset.MeasureString(Text);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.DrawString(asset, Text, Position, Color, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0f);
        }
    }
}
