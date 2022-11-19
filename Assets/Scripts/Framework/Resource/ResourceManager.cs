using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Framework.Resource
{
    public class ResourceManager : BaseModule
    {
        private Dictionary<string, Object> _cache; 
        public ResourceManager()
        {
            _cache = new Dictionary<string, Object>();
        }
        
        internal override void Tick(float elapseSeconds, float realElapseSeconds)
        {
            
        }

        internal override void ShutDown()
        {
            
        }

        public T LoadAsset<T>(string path) where T : Object
        {
            T ret = default(T);
            try
            {
                if (_cache.ContainsKey(path))
                {
                    ret = _cache[path] as T;
                }
                else
                {
                    ret = Resources.Load<T>(path);
                    if (ret != null)
                    {
                        _cache.Add(path, ret);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }

            return ret;
        }
    }
}