using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Gameplay {
    public class CircularMovementCollectible : Collectible {
        public int Period;
        public int Offset = 0;
        public Vector2 Origin = Vector2.Zero;
        public int Radius;
        public bool CCW = false;

        public CircularMovementCollectible(Game game) : base(game) { }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            double angle = ((gameTime.TotalGameTime.TotalMilliseconds + Offset) % Period / Period) * 2 * Math.PI;
            if (CCW) angle = -angle;

            Position = Origin + new Vector2((float)Math.Cos(angle) * Radius, (float)Math.Sin(angle) * Radius);
        }
    }
}
