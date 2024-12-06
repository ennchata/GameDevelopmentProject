using GameDevelopmentProject.Components.Drawables;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Player {
    public class Player : SpriteSheetDrawable {
        private readonly float maxVelocity = 0.5f;
        private readonly float minVelocity = 0.02f;
        private readonly float velocityDecay = 1.15f;
        private readonly float acceleration = 0.05f;
        private float xTranslate = 0;
        private float yTranslate = 0;

        public Player(Game game) : base(game) {
            AssetReference = "Images/basic-sheet";
            Source = new Rectangle(0, 0, 25, 25);
            GlobalAnchor = Anchor.CENTER;
            LocalAnchor = Anchor.CENTER;
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            KeyboardState state = Keyboard.GetState();
            AffectVelocity(ref xTranslate, state, Keys.Left, Keys.Right);
            AffectVelocity(ref yTranslate, state, Keys.Up, Keys.Down);
            
            position += new Vector2(xTranslate * gameTime.ElapsedGameTime.Milliseconds, yTranslate * gameTime.ElapsedGameTime.Milliseconds);
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
