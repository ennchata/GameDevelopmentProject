﻿using GameDevelopmentProject.Components.Drawables;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Gameplay {
    public class Collectible : SpriteSheetDrawable, ICollidable {
        public Collectible(Game game) : base(game) {
            AssetReference = "Images/basic-sheet";
            Source = new Rectangle(30, 30, 25, 25);
            GlobalAnchor = Anchor.CENTER;
            LocalAnchor = Anchor.CENTER;
        }
        public bool IsColliding(Player player) {
            Vector2 distance = Area.Center.ToVector2() - player.Area.Center.ToVector2();
            return distance.Length() <= Source.Width;
        }

        public void Invoke() {
            Visible = false;
            Active = false;
        }

    }
}
