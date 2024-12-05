using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.UI.Commands
{
    public interface IButtonCommand
    {
        public void Invoke(GameTime gameTime);
    }
}
