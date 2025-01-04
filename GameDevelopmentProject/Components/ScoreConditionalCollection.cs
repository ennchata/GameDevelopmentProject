using GameDevelopmentProject.Components.Gameplay;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components {
    public class ScoreConditionalCollection<T> : ObjectCollection<T> where T : IBaseObject {
        public new bool Active {
            get {
                return playerCondition.Invoke(player);
            }
        }

        private Player player;
        private Predicate<Player> playerCondition;

        public ScoreConditionalCollection(Game game, Player player, Predicate<Player> playerCondition) : base(game) {
            this.player = player;
            this.playerCondition = playerCondition;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            if (playerCondition.Invoke(player)) base.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime) {
            if (playerCondition.Invoke(player)) base.Update(gameTime);
        }
    }
}
