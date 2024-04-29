namespace OceanStory
{
    internal class Program
    {
        public static SceneManager SceneManager;
        static void Main(string[] args)
        {
            SceneManager = new SceneManager();
            SceneManager.ChangeScene("StartScene");
        }
    }
}
