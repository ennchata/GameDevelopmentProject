using GameDevelopmentProject.Components.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentProject.Components.Screens {
    public interface IBaseScreen : IBaseObject {
        public List<ICollidable> GetCollidables();
        public void CreateObjects();
        public void DestroyObjects();
    }
}
