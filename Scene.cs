using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory
{
    internal abstract class Scene
    {
        public Scene()
        {
            RunScene();
        }

        public abstract void RunScene();
    }
}
