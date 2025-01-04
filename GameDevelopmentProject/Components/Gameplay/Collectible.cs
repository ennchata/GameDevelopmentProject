using GameDevelopmentProject.Components.Drawables;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Gameplay {
    public class Collectible : SpriteSheetDrawable, ICollidable {
        public InflictedBehavior Behavior;
        public int Value;

        public Collectible(Game game) : base(game) {
            AssetReference = "Images/basic-sheet";
            GlobalAnchor = Anchor.CENTER;
            LocalAnchor = Anchor.CENTER;
        }
        public virtual bool IsColliding(Player player) {
            if (!Active) return false;
            Vector2 distance = Area.Center.ToVector2() - player.Area.Center.ToVector2();
            return distance.Length() <= Source.Width;
        }

        public virtual void Invoke(Player player) {
            bool instaKill = Value >= player.MaxHealth;

            switch (Behavior) {
                case InflictedBehavior.SCORE:
                    player.Score += Value;
                    Visible = false;
                    Active = false;
                    break;
                case InflictedBehavior.DAMAGE:
                    if (instaKill) player.Health = 0;
                    else if (!player.Invincible) { 
                        player.Health -= Value;
                        Visible = false;
                        Active = false;
                    }
                    break;
            }
        }
    }
}
