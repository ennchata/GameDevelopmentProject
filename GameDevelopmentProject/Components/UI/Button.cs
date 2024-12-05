using GameDevelopmentProject.Components.Drawables;
using GameDevelopmentProject.Components.UI.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.UI
{
    public class Button : TextDrawable {
        private Texture2D background;
        private MouseState currentState, previousState;

        public bool Hovering = false;
        public IButtonCommand[] Commands;
        public Vector2 ButtonSize;
        public new Vector2 Position {
            get {
                return position
                    + GetOffset(GlobalAnchor, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height)
                    + GetOffset(LocalAnchor, -ButtonSize.X, -ButtonSize.Y);
            }
            set {
                position = value;
            }
        }
        public new Rectangle Area {
            get {
                return new Rectangle((int)Position.X, (int)Position.Y, (int)ButtonSize.X, (int)ButtonSize.Y);
            }
        }

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
            spriteBatch.DrawString(asset, Text, Area.Center.ToVector2() - Size / 2, Color);
        }

        public override void Update(GameTime gameTime) {
            previousState = currentState;
            currentState = Mouse.GetState();
            Rectangle mouseRectangle = new Rectangle(currentState.X, currentState.Y, 1, 1);

            Hovering = Area.Intersects(mouseRectangle);
            if (Hovering && currentState.LeftButton == ButtonState.Released && previousState.LeftButton == ButtonState.Pressed) {
                foreach (IButtonCommand command in Commands) command.Invoke(gameTime);
            }
        }
    }
}
