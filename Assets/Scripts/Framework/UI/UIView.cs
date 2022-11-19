using UnityEngine;
using Utility;

namespace Framework.UI
{
    public class UIView
    {
        public Transform Root;

        public virtual void Init()
        {
            
        }

        public virtual string GetPrefabPath()
        {
            return "";
        }

        public virtual void Destroy()
        {
            if (Root != null)
            {
                GameObject.Destroy(Root.gameObject);
            }
        }

        public T FindComponentInChildren<T>(Transform root, string childPath) where T:Behaviour
        {
            return Utils.FindComponentInChildren<T>(root, childPath);
        }
    }
}