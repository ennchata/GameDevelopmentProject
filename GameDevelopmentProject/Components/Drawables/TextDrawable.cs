using GameDevelopmentProject.Components.Drawables;
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
        public Vector2 TextSize = Vector2.Zero;

        public TextDrawable(Game game) : base(game) { }

        public override void LoadContent() {
            base.LoadContent();
            TextSize = asset.MeasureString(Text);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.DrawString(asset, Text, Position, Color, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0f);
        }
    }
}
