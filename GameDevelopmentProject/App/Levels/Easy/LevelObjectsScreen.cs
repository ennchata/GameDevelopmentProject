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
                Text = "Health: <3 <3 <3",
                AssetReference = "Fonts/Default"
            };
            scoreDisplay = new TextDrawable(game) {
                Position = new Vector2(5, 25),
                Text = "Score: 0/50",
                AssetReference = "Fonts/Default"
            };

            #region Eerste collectie (<10)
            ScoreConditionalCollection<BaseObject> collection1 = new ScoreConditionalCollection<BaseObject>(game, player, (_) => _.Score < 10);

            collection1.Add(new Collectible(game) {
                Position = new Vector2(0, -340),
                Source = new Rectangle(30, 0, 25, 25),
                Behavior = InflictedBehavior.SCORE,
                Value = 10
            });
            for (int i = -350; i < 350; i += 35) {
                collection1.Add(new Collectible(game) {
                    Position = new Vector2(-60, i),
                    Behavior = InflictedBehavior.DAMAGE,
                    Source = new Rectangle(0, 0, 25, 25),
                    Value = 100
                });
                collection1.Add(new Collectible(game) {
                    Position = new Vector2(60, i),
                    Source = new Rectangle(0, 0, 25, 25),
                    Behavior = InflictedBehavior.DAMAGE,
                    Value = 100
                });
            }
            collection1.Add(new TextDrawable(game) {
                Position = new Vector2(0, 50),
                Text = "Pick up yellow orbs for score",
                AssetReference = "Fonts/Default",
                LocalAnchor = Anchor.TOP_CENTER,
                GlobalAnchor = Anchor.TOP_CENTER
            });
            collection1.Add(new TextDrawable(game) {
                Position = new Vector2(0, 75),
                Text = "Don't touch red orbs, they kill!",
                AssetReference = "Fonts/Default",
                LocalAnchor = Anchor.TOP_CENTER,
                GlobalAnchor = Anchor.TOP_CENTER
            });
            #endregion

            #region Tweede collectie (10-20)
            ScoreConditionalCollection<BaseObject> collection2 = new ScoreConditionalCollection<BaseObject>(game, player, (_) => _.Score >= 10 && _.Score < 20);
            collection2.Add(new Collectible(game) {
                Position = new Vector2(600, 0),
                Source = new Rectangle(30, 0, 25, 25),
                Behavior = InflictedBehavior.SCORE,
                Value = 10
            });

            for (int i = -350; i < 350; i += 35) {
                collection2.Add(new Collectible(game) {
                    Position = new Vector2(-60, i),
                    Behavior = InflictedBehavior.DAMAGE,
                    Source = new Rectangle(0, 0, 25, 25),
                    Value = 100
                });

                if (Math.Abs(i) > 75) {
                    collection2.Add(new Collectible(game) {
                        Position = new Vector2(60, i),
                        Source = new Rectangle(0, 0, 25, 25),
                        Behavior = InflictedBehavior.DAMAGE,
                        Value = 100
                    });
                } else collection2.Add(new LinearMovementCollectible(game) {
                    BeginPosition = new Vector2(60, i),
                    EndPosition = new Vector2(600, i),
                    Source = new Rectangle(0, 30, 25, 25),
                    Period = 2500,
                    Behavior = InflictedBehavior.DAMAGE,
                    Value = 1
                });
            }

            collection2.Add(new TextDrawable(game) {
                Position = new Vector2(0, 50),
                Text = "The green orbs move! Try to dodge them, they hurt you.",
                AssetReference = "Fonts/Default",
                LocalAnchor = Anchor.TOP_CENTER,
                GlobalAnchor = Anchor.TOP_CENTER
            });
            #endregion

            #region Derde collectie (20-30)
            ScoreConditionalCollection<BaseObject> collection3 = new ScoreConditionalCollection<BaseObject>(game, player, (_) => _.Score >= 20 && _.Score < 30);
            collection3.Add(new Collectible(game) {
                Position = new Vector2(-600, 0),
                Source = new Rectangle(30, 0, 25, 25),
                Behavior = InflictedBehavior.SCORE,
                Value = 10
            });
            for (int i = -630; i < 630; i += 35) {
                collection3.Add(new Collectible(game) {
                    Position = new Vector2(i, -60),
                    Behavior = InflictedBehavior.DAMAGE,
                    Source = new Rectangle(0, 0, 25, 25),
                    Value = 100
                });
                collection3.Add(new Collectible(game) {
                    Position = new Vector2(i, 60),
                    Behavior = InflictedBehavior.DAMAGE,
                    Source = new Rectangle(0, 0, 25, 25),
                    Value = 100
                });
            }
            for (int i = 100; i < 275; i += 35) {
                collection3.Add(new CircularMovementCollectible(game) {
                    Behavior = InflictedBehavior.DAMAGE,
                    Source = new Rectangle(30, 30, 25, 25),
                    Period = 2500,
                    Radius = i,
                    Value = 1
                });
                collection3.Add(new CircularMovementCollectible(game) {
                    Behavior = InflictedBehavior.DAMAGE,
                    Source = new Rectangle(30, 30, 25, 25),
                    Period = 2500,
                    Offset = 1250,
                    Radius = i,
                    Value = 1
                });
            }


            collection3.Add(new TextDrawable(game) {
                Position = new Vector2(0, 50),
                Text = "The blue orbs move in a circular path! They may be tricker to dodge.",
                AssetReference = "Fonts/Default",
                LocalAnchor = Anchor.TOP_CENTER,
                GlobalAnchor = Anchor.TOP_CENTER
            });
            #endregion

            #region Vierde collectie (30-40)
            ScoreConditionalCollection<BaseObject> collection4 = new ScoreConditionalCollection<BaseObject>(game, player, (_) => _.Score >= 30 && _.Score < 40);
            collection4.Add(new Collectible(game) {
                Position = new Vector2(600, 0),
                Source = new Rectangle(30, 0, 25, 25),
                Behavior = InflictedBehavior.SCORE,
                Value = 10
            });

            collection4.Add(new TextDrawable(game) {
                Position = new Vector2(0, 50),
                Text = "Be careful, some red orbs slowly chase you!",
                AssetReference = "Fonts/Default",
                LocalAnchor = Anchor.TOP_CENTER,
                GlobalAnchor = Anchor.TOP_CENTER
            });
            #endregion

            #region Vijfde collectie (40-50)
            ScoreConditionalCollection<BaseObject> collection5 = new ScoreConditionalCollection<BaseObject>(game, player, (_) => _.Score >= 40 && _.Score < 50);
            collection5.Add(new Collectible(game) {
                Position = new Vector2(0, 0),
                Source = new Rectangle(30, 0, 25, 25),
                Behavior = InflictedBehavior.SCORE,
                Value = 10
            });

            collection5.Add(new TextDrawable(game) {
                Position = new Vector2(0, 50),
                Text = "Awesome! You understand the basics of the game now.",
                AssetReference = "Fonts/Default",
                LocalAnchor = Anchor.TOP_CENTER,
                GlobalAnchor = Anchor.TOP_CENTER
            });

            collection5.Add(new TextDrawable(game) {
                Position = new Vector2(0, 75),
                Text = "Ready to face a real challenge? Try to beat the Normal difficulty!",
                AssetReference = "Fonts/Default",
                LocalAnchor = Anchor.TOP_CENTER,
                GlobalAnchor = Anchor.TOP_CENTER
            });
            #endregion

            Add(collection1);
            Add(collection2);
            Add(collection3);
            Add(collection4);
            Add(collection5);
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
