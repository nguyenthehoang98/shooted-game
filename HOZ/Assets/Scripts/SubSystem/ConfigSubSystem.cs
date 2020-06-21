using Config;
using HOR.Entry;

namespace SubSystem
{
    public class ConfigSubSystem : ISubSystem
    {
        private ConfigManager configManager;
        
        public void StartUp()
        {
            configManager = new ConfigManager();
            configManager.Init();

            GameConfigConstant gcc = configManager.GetConfig<GameConfigConstant>();
        }

        public void ShutDown()
        {
            //
        }

        public ConfigManager GetConfigManager()
        {
            return configManager;
        }
    }
}