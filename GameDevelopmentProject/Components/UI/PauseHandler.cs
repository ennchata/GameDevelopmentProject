﻿using GameDevelopmentProject.Components.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.UI {
    public class PauseHandler : BaseObject {
        private string origin;
        private bool debounce = true;

        public PauseHandler(Game game, string origin) : base(game) {
            this.origin = origin;
        }

        public override void Update(GameTime gameTime) {
            KeyboardState state = Keyboard.GetState();
            if(!debounce && state.IsKeyDown(Keys.Escape)) SceneManager.GetInstance(game).SetActive("Pause" + origin);

            debounce = state.IsKeyDown(Keys.Escape);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
    }
}
