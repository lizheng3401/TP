using System.Collections.Generic;
using Framework.Resource;
using Framework.UI;

public class ModuleManager
{
    private LinkedList<BaseModule> _modules = new LinkedList<BaseModule>();

    public UIManager UIManager => _uiManager;
    private UIManager _uiManager;
    public void Init()
    {
        _uiManager = new UIManager();
        _modules.AddLast(_uiManager);
    }

    public void Tick(float elapsedSeconds, float realElapsedSeconds)
    {
        foreach (BaseModule module in _modules)
        {
            module.Tick(elapsedSeconds, realElapsedSeconds);
        }
    }
    
    public void ShutDown()
    {
        for (LinkedListNode<BaseModule> current = _modules.Last; current != null; current = current.Previous)
        {
            current.Value.ShutDown();
        }
    }

    public void AddMoudle(BaseModule moudule)
    {
        _modules.AddLast(moudule);
    }

    public T GetModule<T>() where T:BaseModule
    {
        foreach (var module in _modules)
        {
            if (module is T)
            {
                return module as T;
            }
        }

        return null;
    }
}