using GameDevelopmentProject.Components.Drawables;
using GameDevelopmentProject.Components.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Gameplay {
    public class Player : SpriteSheetDrawable {
        public int Score = 0;
        public int Health = 3;
        public int MaxScore = 50;
        public int MaxHealth = 3;
        public bool Invincible = false;

        private readonly float maxVelocity = 0.5f;
        private readonly float minVelocity = 0.02f;
        private readonly float velocityDecay = 1.15f;
        private readonly float acceleration = 0.05f;
        private float xTranslate = 0;
        private float yTranslate = 0;
        private int previousHealth = 3;
        private double hitTimestamp;

        public Player(Game game) : base(game) {
            AssetReference = "Images/basic-sheet";
            Source = new Rectangle(0, 0, 25, 25);
            GlobalAnchor = Anchor.CENTER;
            LocalAnchor = Anchor.CENTER;
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            if (Health <= 0) {
                SceneManager.GetInstance(game).SetActive("GameOver");
                return;
            }
            
            if (previousHealth != Health) {
                Invincible = true;
                hitTimestamp = gameTime.TotalGameTime.TotalMilliseconds;
                previousHealth = Health;
            }

            if (Invincible && gameTime.TotalGameTime.TotalMilliseconds - hitTimestamp <= 3000) {
                Visible = gameTime.TotalGameTime.Milliseconds % 200 <= 100;
            } else {
                Invincible = false;
                Visible = true;
            }

            if (Score >= MaxScore) {
                SceneManager.GetInstance(game).SetActive("GameWon");
                return;
            }

            KeyboardState state = Keyboard.GetState();
            AffectVelocity(ref xTranslate, state, Keys.Left, Keys.Right);
            AffectVelocity(ref yTranslate, state, Keys.Up, Keys.Down);

            float xBound = game.GraphicsDevice.Viewport.Width / 2f - Size.X;
            float yBound = game.GraphicsDevice.Viewport.Height / 2f - Size.Y;
            position = new Vector2(
                Math.Clamp(position.X + xTranslate * gameTime.ElapsedGameTime.Milliseconds,
                           -xBound - Size.X,
                           xBound),
                Math.Clamp(position.Y + yTranslate * gameTime.ElapsedGameTime.Milliseconds,
                           -yBound - Size.Y,
                           yBound)
            );

            List<ICollidable> collidables = SceneManager.GetInstance(game).activeScene.Get("Objects").GetCollidables();
            foreach (ICollidable collidable in collidables) {
                if (collidable.IsColliding(this)) collidable.Invoke(this);
            }
        }

        private void AffectVelocity(ref float translate, KeyboardState state, Keys negativeKey, Keys positiveKey) {
            if (state.IsKeyDown(negativeKey) && state.IsKeyUp(positiveKey)) {
                translate = Math.Clamp(translate - acceleration, -maxVelocity, maxVelocity);
            } else if (state.IsKeyDown(positiveKey) && state.IsKeyUp(negativeKey)) {
                translate = Math.Clamp(translate + acceleration, -maxVelocity, maxVelocity);
            } else if (Math.Abs(translate) <= minVelocity) {
                translate = 0f;
            } else {
                translate /= velocityDecay;
            }
        }
    }
}
