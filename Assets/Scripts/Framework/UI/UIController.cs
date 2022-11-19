using UnityEngine;

namespace Framework.UI
{
    public class UIController
    {
        public UILayer Layer;
        private UIView _view;
        public UIController(UIView view, UILayer layer)
        {
            this.Layer = layer;
            this._view = view;
        }

        public virtual void SetupView()
        {
            
        }

        public virtual void Dispose()
        {
            
        }

        public virtual void Show()
        {
            if (!GlobalVars.UIManager.ShouldShow(this)) return;

            string prefabPath = _view.GetPrefabPath();
            if (string.IsNullOrEmpty(prefabPath))
            {
                //TODO:异常处理
                return;
            }

            GameObject uiPrefab = GlobalVars.ResourceManager.LoadAsset<GameObject>(prefabPath);
            if (null == uiPrefab)
            {
                // TODO: 异常处理，加载失败
            }
            GameObject uiGO = GlobalVars.UIManager.InstantiateUI(uiPrefab, this.Layer);
            GlobalVars.UIManager.HandleOpenContext(this);

            _view.Root = uiGO.transform;
            _view.Init();
            SetupView();
        }
        
        public virtual void Exit()
        {
            GlobalVars.UIManager.HandleExitContext(this);
            Dispose();
            _view.Destroy();
            
        }

        public virtual void AddTick()
        {
            GlobalVars.UIManager.AddTick(this);
        }
        public virtual void Tick(float elapseSeconds, float realElapseSeconds)
        {
            
        }

        public virtual void RemoveTick()
        {
            GlobalVars.UIManager.RemoveTick(this);
        }
    }
}