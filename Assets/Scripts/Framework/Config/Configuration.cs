using UnityEngine;

namespace Framework.Config
{
    public class Configuration:Singleton<Configuration>
    {
        private PlantCollection _plantCollection;
        public PlantCollection PlantCollection => _plantCollection;

        public void Init()
        {
            _plantCollection = LoadScriptableObject<PlantCollection>();
        }

        public T LoadScriptableObject<T>() where T:ScriptableObject
        {
            T ret = default(T);
            string path = string.Format("Configuration/{0}", typeof(T).Name);
            ret = GlobalVars.ResourceManager.LoadAsset<T>(path);
            return ret;
        }
    }
}