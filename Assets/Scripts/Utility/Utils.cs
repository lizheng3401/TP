using UnityEngine;

namespace Utility
{
    public class Utils
    {
        public static T FindComponentInChildren<T>(Transform root, string childPath) where T:Behaviour
        {
            T ret = default(T);
            if (null != root)
            {
                Transform child = root.Find(childPath);
                if (null != child)
                {
                    ret = child.GetComponent<T>();
                }
            }

            return ret;
        }
    }
}