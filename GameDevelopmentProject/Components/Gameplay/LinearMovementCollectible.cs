using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Gameplay {
    public class LinearMovementCollectible : Collectible {
        public int Period;
        public int Offset = 0;
        public Vector2 BeginPosition;
        public Vector2 EndPosition;

        public LinearMovementCollectible(Game game) : base(game) { }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            float percentage = (float)((gameTime.TotalGameTime.TotalMilliseconds + Offset) % Period / Period);
            Position = Vector2.Lerp(BeginPosition, EndPosition, percentage);
        }
    }
}
