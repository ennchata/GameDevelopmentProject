using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Drawables {
    public class BlankDrawable : BaseDrawable<Texture2D> {
        public BlankDrawable(Game game) : base(game) { }

        public override void LoadContent() {
            asset = new Texture2D(game.GraphicsDevice, 1, 1);
            asset.SetData(new[] { Color.White });
        }

        public override void UnloadContent() {
            asset.Dispose();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(asset, Area, Color);
        }
    }
}
