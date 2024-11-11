using GameDevelopmentProject.Components.Drawables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.UI {
    public class ImageDrawable : BaseDrawable<Texture2D> {
        public ImageDrawable(Game game) : base(game) { }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(asset, Position, null, Color.White, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0f);
        }
    }
}
