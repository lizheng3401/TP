using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace Framework.UI
{
    public enum UILayer
    {
        BelowPage,
        Page,
        Dialog
    }
    public class UIManager:BaseModule
    {
        private Transform _uiRoot;
        private Transform _belowPageRoot;
        private Transform _pageRoot;
        private Transform _dialogRoot;

        private Stack<UIController> _pageStack;
        private LinkedList<UIController> _pageLinkedList;
        private LinkedList<UIController> _addedPageList;
        private LinkedList<UIController> _removedPageList;
        public UIManager()
        {
            GameObject uiRootGo = GameObject.Find(GameConstants.UIROOTName);
            if (null == uiRootGo)
            {
                GameObject uiRootPrefab = GlobalVars.ResourceManager.LoadAsset<GameObject>("UI/UIRoot");
                uiRootGo = GameObject.Instantiate(uiRootPrefab, Vector3.zero, Quaternion.identity);
                uiRootGo.name = GameConstants.UIROOTName;
            }

            _uiRoot = uiRootGo.transform;
            _belowPageRoot = _uiRoot.Find("BelowPage");
            _pageRoot = _uiRoot.Find("Page");
            _dialogRoot = _uiRoot.Find("Dialog");
            
            GameObject.DontDestroyOnLoad(_uiRoot.gameObject);

            _pageStack = new Stack<UIController>();
            _pageLinkedList = new LinkedList<UIController>();
            _addedPageList = new LinkedList<UIController>();
            _removedPageList = new LinkedList<UIController>();
        }
        
        internal override void Tick(float elapseSeconds, float realElapseSeconds)
        {
            // 添加上一帧的add
            for (LinkedListNode<UIController> current = _addedPageList.First;
                 current != null;
                 current = current.Next)
            {
                _pageLinkedList.AddLast(current.Value);
                
            }

            if (_addedPageList.Count > 0)
            {
                _addedPageList.Clear();
            }
            // 移除上一帧的removed
            for (LinkedListNode<UIController> current = _removedPageList.First;
                 current != null;
                 current = current.Next)
            {
                _pageLinkedList.Remove(current.Value);
            }
            if (_removedPageList.Count > 0)
            {
                _removedPageList.Clear();
            }
            
            // Tick
            for (LinkedListNode<UIController> current = _pageLinkedList.First;
                 current != null;
                 current = current.Next)
            {
                UIController uiController = current.Value;
				uiController.Tick(elapseSeconds, realElapseSeconds);
            }
        }

		internal override void ShutDown()
        {
            
        }

		public bool ShouldShow(UIController uiController)
        {
            if (uiController.Layer == UILayer.Page)
            {
                return !_pageStack.Contains(uiController);
            }else if (uiController.Layer == UILayer.BelowPage)
            {
                return true;
            }else if (uiController.Layer == UILayer.Dialog)
            {
                // 暂时让dialog全局唯一，确保退出游戏UI每次只有一个
                return true;
            }
            else
            {
                return true;
            }
        }

        public GameObject InstantiateUI(GameObject uiPrefab, UILayer layer)
        {
            GameObject uiGo = default(GameObject);
            if (layer == UILayer.BelowPage)
            {
                uiGo = GameObject.Instantiate(uiPrefab, _belowPageRoot, false);
            }else if (layer == UILayer.Page)
            {
                uiGo = GameObject.Instantiate(uiPrefab, _pageRoot, false);
            }else if (layer == UILayer.Dialog)
            {
                uiGo = GameObject.Instantiate(uiPrefab, _dialogRoot, false);
            }
            else
            {
                
            }

            return uiGo;
        }
        
        public void HandleOpenContext(UIController uiController)
        {
            if (uiController.Layer == UILayer.Page)
            {
                _pageStack.Push(uiController);
            }
            else
            {
                
            }
        }

        public void HandleExitContext(UIController uiController)
        {
            if (uiController.Layer == UILayer.Page)
            {
                if (_pageStack.Count > 0)
                {
                    _pageStack.Pop();
                }
                else
                {
                    // TODO: 空栈异常
                }
            }
        }

        public void AddTick(UIController controller)
        {
            _addedPageList.AddLast(controller);
        }

        public void RemoveTick(UIController controller)
        {
            _removedPageList.AddLast(controller);
        }
    }
}