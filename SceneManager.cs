using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanStory
{
    internal class SceneManager
    {
        public SceneManager() { }

        public void ChangeScene(string sceneName)
        {
            Type sceneType = Type.GetType("OceanStory." + sceneName);
            object obj = Activator.CreateInstance(sceneType);
        }
    }
}
