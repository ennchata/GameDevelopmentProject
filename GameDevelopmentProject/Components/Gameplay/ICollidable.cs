using GameDevelopmentProject.Components.Drawables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Gameplay {
    public interface ICollidable {
        public bool IsColliding(Player player);
        public void Invoke();
    }
}
