using GameDevelopmentProject.Components;
using GameDevelopmentProject.Components.Drawables;
using GameDevelopmentProject.Components.Gameplay;
using GameDevelopmentProject.Components.Screens;
using GameDevelopmentProject.Components.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.App.Levels.Easy {
    public class LevelObjectsScreen : BaseScreen {
        private TextDrawable healthDisplay;
        private TextDrawable scoreDisplay;
        private Player player;

        public LevelObjectsScreen(Game game) : base(game) {
            CreateObjects();
        }
        public override void CreateObjects() {
            player = new Player(game);
            healthDisplay = new TextDrawable(game) {
                Position = new Vector2(5),
                Text = "Health: 100/100",
                AssetReference = "Fonts/Default"
            };
            scoreDisplay = new TextDrawable(game) {
                Position = new Vector2(5, 25),
                Text = "Score: 0/5",
                AssetReference = "Fonts/Default"
            };

            // easiest level collection
            ScoreConditionalCollection<BaseObject> collection1 = new ScoreConditionalCollection<BaseObject>(game, player, (_) => _.Score < 10);
            collection1.Add(new Collectible(game) {
                Position = new Vector2(0, 50),
                Behavior = InflictedBehavior.SCORE,
                Value = 10
            });
            collection1.Add(new TextDrawable(game) {
                Position = new Vector2(0, 50),
                Text = "Pick up yellow orbs for score",
                AssetReference = "Fonts/Default",
                LocalAnchor = Anchor.TOP_CENTER,
                GlobalAnchor = Anchor.TOP_CENTER
            });

            Add(collection1);

            Add(healthDisplay);
            Add(scoreDisplay);
            Add(player);
            Add(new PauseHandler(game, "LevelEasy"));
        }

        public override void Update(GameTime gameTime) {
            healthDisplay.Text = $"Health: {player.Health}/100";
            scoreDisplay.Text = $"Score: {player.Score}/5";

            base.Update(gameTime);
        }
    }
}
