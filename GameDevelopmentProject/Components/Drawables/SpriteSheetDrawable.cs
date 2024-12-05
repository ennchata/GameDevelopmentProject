using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Drawables {
    public class SpriteSheetDrawable : BaseDrawable<Texture2D> {
        public Rectangle Source;
        public new Vector2 Size {
            get {
                return Source.Size.ToVector2();
            }
        }

        public SpriteSheetDrawable(Game game) : base(game) { }

        public override void LoadContent() {
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(asset, Position, Source, Color, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0f);
        }
    }
}
