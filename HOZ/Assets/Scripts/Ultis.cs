using Config;
using HOR.Entry;
using SubSystem;

public static class Ultis
{
    public static ConfigManager ConfigManager()
    {
        return Service.Get<DefaultSystem>().GetSubSytem<ConfigSubSystem>().GetConfigManager();
    }
}