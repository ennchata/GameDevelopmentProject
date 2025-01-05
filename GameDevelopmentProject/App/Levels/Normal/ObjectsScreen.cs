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

namespace GameDevelopmentProject.App.Levels.Normal {
    public class ObjectsScreen : BaseScreen {
        private TextDrawable healthDisplay;
        private TextDrawable scoreDisplay;
        private Player player;

        public ObjectsScreen(Game game) : base(game) {
            CreateObjects();
        }

        public override void CreateObjects() {
            player = new Player(game);
            healthDisplay = new TextDrawable(game) {
                Position = new Vector2(5),
                Text = "Health: <3 <3 <3",
                AssetReference = "Fonts/Default"
            };
            scoreDisplay = new TextDrawable(game) {
                Position = new Vector2(5, 25),
                Text = "Score: 0/50",
                AssetReference = "Fonts/Default"
            };

            #region 1 (10)
            ScoreConditionalCollection<BaseObject> collection1 = new ScoreConditionalCollection<BaseObject>(game, player, (_) => _.Score < 10);
            for (int i = 0; i < 360; i += 9) {
                var (sin, cos) = Math.SinCos(Math.PI * i / 180d);
                collection1.Add(new Collectible(game) {
                    Position = new Vector2((float)(300 * cos), (float)(300 * sin)),
                    Source = new Rectangle(0, 0, 25, 25),
                    Behavior = InflictedBehavior.DAMAGE,
                    Value = 100
                });

                if (i % 90 == 0) {
                    collection1.Add(new Collectible(game) {
                        Position = new Vector2((float)(180 * cos), (float)(180 * sin)),
                        Source = new Rectangle(30, 0, 25, 25),
                        Behavior = InflictedBehavior.SCORE,
                        Value = 2
                    });
                }
            }
            for (int i = 100; i < 275; i += 35) {
                for (int j = 0; j < 5000; j += 1250) {
                    collection1.Add(new CircularMovementCollectible(game) {
                        Behavior = InflictedBehavior.DAMAGE,
                        Source = new Rectangle(30, 30, 25, 25),
                        Period = 5000,
                        Offset = j,
                        Radius = i,
                        Value = 1
                    });
                }
            }

            ScoreConditionalCollection<BaseObject> collection1b = new ScoreConditionalCollection<BaseObject>(game, player, (_) => _.Score == 8);
            collection1b.Add(new Collectible(game) {
                Position = Vector2.Zero,
                Source = new Rectangle(30, 0, 25, 25),
                Behavior = InflictedBehavior.SCORE,
                Value = 2
            });

            #endregion

            #region TBD
            ScoreConditionalCollection<BaseObject> collection2 = new ScoreConditionalCollection<BaseObject>(game, player, (_) => _.Score > 10);
            collection2.Add(new TextDrawable(game) {
                Position = new Vector2(0, 50),
                Text = "More content to be added soon. Thanks for playing!",
                AssetReference = "Fonts/Default",
                LocalAnchor = Anchor.TOP_CENTER,
                GlobalAnchor = Anchor.TOP_CENTER
            });

            collection2.Add(new Collectible(game) {
                Position = new Vector2(0, 0),
                Source = new Rectangle(30, 0, 25, 25),
                Behavior = InflictedBehavior.SCORE,
                Value = 50
            });
            #endregion

            Add(collection1);
            Add(collection1b);
            Add(collection2);
            Add(healthDisplay);
            Add(scoreDisplay);
            Add(player);
            Add(new PauseHandler(game, "LevelEasy"));
        }

        public override void Update(GameTime gameTime) {
            healthDisplay.Text = "Lives: ";
            for (int i = 1; i < player.Health + 1; i++) {
                healthDisplay.Text += "<3 ";
            }
            scoreDisplay.Text = $"Score: {player.Score}/{player.MaxScore}";

            base.Update(gameTime);
        }
    }
}
