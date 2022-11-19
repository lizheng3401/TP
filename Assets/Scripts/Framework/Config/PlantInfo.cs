using GameCore.Plant;
using UnityEngine;

namespace Framework.Config
{
    [System.Serializable]
    public class PlantInfo
    {
        public string Name;
        public PlantType type;
        public string PrefabPath;
        public string SpritePath;
        public int Cost;
        public float CDTime;
    }
}