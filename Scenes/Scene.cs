namespace OceanStory.Scenes
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
