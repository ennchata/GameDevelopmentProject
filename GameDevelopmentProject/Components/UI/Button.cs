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

namespace GameDevelopmentProject.Components.UI {
    public class Button : TextDrawable {
        private BlankDrawable background;
        private MouseState currentState, previousState;

        public bool Hovering = false;
        public IButtonCommand[] Commands;
        public Vector2 ButtonSize;
        public Color BackgroundColor = Color.White;
        public Color HoverColor = Color.Lerp(Color.White, Color.Black, 0.15f);

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

        public Button(Game game) : base(game) {
            background = new BlankDrawable(game) {
                GlobalAnchor = GlobalAnchor,
                LocalAnchor = LocalAnchor,
            };
        }


        public override void LoadContent() {
            base.LoadContent();
            background.LoadContent();
        }

        public override void UnloadContent() {
            base.UnloadContent();
            background.UnloadContent();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            background.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(asset, Text, Area.Center.ToVector2() - Size / 2, Color);
        }

        public override void Update(GameTime gameTime) {
            previousState = currentState;
            currentState = Mouse.GetState();
            Rectangle mouseRectangle = new Rectangle(currentState.X, currentState.Y, 1, 1);
            Hovering = Area.Intersects(mouseRectangle);

            background.Color = Hovering ? HoverColor : BackgroundColor;
            background.Position = Position;
            background.Size = ButtonSize;

            if (Hovering && currentState.LeftButton == ButtonState.Released && previousState.LeftButton == ButtonState.Pressed) {
                foreach (IButtonCommand command in Commands) command.Invoke(gameTime);
            }
        }
    }
}
