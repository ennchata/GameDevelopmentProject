using GameDevelopmentProject.Components.Drawables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.UI {
    public class Button : TextDrawable {
        private Texture2D background;
        private MouseState currentState, previousState;

        public bool Hovering = false;
        public IButtonCommand Command;

        public Button(Game game) : base(game) { }


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
            spriteBatch.Draw(background, Area, Hovering ? Color.Gray : Color.White);
            spriteBatch.DrawString(asset, Text, Area.Center.ToVector2() - TextSize / 2, Color);
        }

        public override void Update(GameTime gameTime) {
            previousState = currentState;
            currentState = Mouse.GetState();
            Rectangle mouseRectangle = new Rectangle(currentState.X, currentState.Y, 1, 1);

            Hovering = Area.Intersects(mouseRectangle);
            if (Hovering && currentState.LeftButton == ButtonState.Released && previousState.LeftButton == ButtonState.Pressed) Command.Invoke(gameTime);
        }
    }
}
