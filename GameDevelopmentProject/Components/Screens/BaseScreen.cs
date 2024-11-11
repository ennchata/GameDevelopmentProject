using GameDevelopmentProject.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Screens {
    public abstract class BaseScreen : IBaseDrawable {
        public List<IBaseDrawable> drawables;

        private Game game;

        public BaseScreen(Game game) {
            this.game = game;
        }

        public virtual void Initialize() {
            foreach (IBaseDrawable drawable in drawables) drawable.Initialize();
        }

        public virtual void LoadContent() {
            foreach (IBaseDrawable drawable in drawables) drawable.LoadContent();
        }

        public virtual void UnloadContent() {
            foreach (IBaseDrawable drawable in drawables) drawable.UnloadContent();
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            foreach (IBaseDrawable drawable in drawables) drawable.Draw(gameTime, spriteBatch);
        }
    }
}
