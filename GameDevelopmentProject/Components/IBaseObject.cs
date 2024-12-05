using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components {
    public interface IBaseObject {
        public void Initialize();
        public void LoadContent();
        public void UnloadContent();
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public void Update(GameTime gameTime);
        public bool _Visible();
        public bool _Active();
    }
}
