namespace Config
{
    public class GameConfigConstant : IConfig
    {
        public GameConfig config;
        public void Setup(string context)
        {
        }
        
    }

    public class GameConfig
    {
        public string nameOfGame { get; set; }
        public string urlPage { get; set; }
        public string urlFirebase { get; set; }
        public string urlConfigFolder { get; set; }

        public GameConfig()
        {
            // url =...
            // 
        }
    }
}