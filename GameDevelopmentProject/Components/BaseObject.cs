using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components {
    public abstract class BaseObject : IBaseObject {
        public bool Active = true;
        public bool Visible = true;

        protected Game game;

        public BaseObject(Game game) {
            this.game = game;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
        public virtual void Initialize() { }
        public virtual void LoadContent() { }
        public virtual void UnloadContent() { }
        public virtual void Update(GameTime gameTime) { }
        public bool _Active() {
            return Active;
        }
        public bool _Visible() {
            return Visible;
        }
    }
}
