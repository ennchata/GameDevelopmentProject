﻿using GameDevelopmentProject.Components.Drawables.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.UI {
    public class TextDrawable : BaseDrawable<SpriteFont> {
        public string Text;
        public Vector2 Size;

        public TextDrawable(Game game) : base(game) { }

        public override void Initialize() {
            base.Initialize();
            Size = Asset.MeasureString(Text);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.DrawString(Asset, Text, Position, Color, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0f);
        }
    }
}
