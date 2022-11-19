using Framework.Config;
using Framework.Resource;
using Framework.UI;

public class GlobalVars
{
    public static ModuleManager ModuleManager => _moduleManager;
    private static ModuleManager _moduleManager;

    public static ResourceManager ResourceManager => _resourceManager;
    private static ResourceManager _resourceManager;
    public static PhaseManager PhaseManager => _phaseManager;
    private static PhaseManager _phaseManager;

    public static UIManager UIManager => _moduleManager.UIManager;

    public static void Init()
    {
        // 此处仅初始化基建相关，moudle内部初始化其余module
        _resourceManager = new ResourceManager();
        _phaseManager = new PhaseManager();
        
        Configuration.Instance.Init();
        
        _moduleManager = new ModuleManager();
        _moduleManager.AddMoudle(_resourceManager);
    }
}