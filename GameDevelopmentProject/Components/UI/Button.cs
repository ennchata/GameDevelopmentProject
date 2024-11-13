using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.UI {
    public class Button : TextDrawable {
        private Texture2D background;

        public Button(Game game) : base(game) { }

        public event EventHandler Click;

        public override void LoadContent() {
            base.LoadContent();
            background = new Texture2D(game.GraphicsDevice, 1, 1);
            background.SetData(new[] { Color.White });
        }

        public override void UnloadContent() {
            base.UnloadContent();
            background.Dispose();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(background, Area, Color.White);
            spriteBatch.DrawString(asset, Text, Area.Center.ToVector2() - TextSize / 2, Color);
        }

        public override void Update(GameTime gameTime) {
            
        }
    }
}
