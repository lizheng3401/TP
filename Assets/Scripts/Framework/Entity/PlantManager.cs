using System.Collections.Generic;
using UnityEngine;

using Framework.Config;
using GameCore.Plant;

namespace Framework.Entity
{
    public class PlantManager:BaseModule
    {
        private Dictionary<PlantType, Queue<GameObject>> _pool;
        public void Init()
        {
            _pool = new Dictionary<PlantType, Queue<GameObject>>();
        }
        
        internal override void Tick(float elapseSeconds, float realElapseSeconds)
        {
            
        }

        internal override void ShutDown()
        {
            
        }

        private GameObject CreatePlant(PlantType plantType)
        {
            // 创建Plant
            GameObject actorPrefab = GlobalVars.ResourceManager.LoadAsset<GameObject>("Actor/Actor");
            GameObject actor = GameObject.Instantiate(actorPrefab);
            Transform model = actor.transform.Find("Model");
            PlantInfo plantInfo = Configuration.Instance.PlantCollection.GetPlantInfoByType(plantType);
            GameObject plantPreafb = GlobalVars.ResourceManager.LoadAsset<GameObject>(plantInfo.PrefabPath);
            GameObject plant = GameObject.Instantiate(plantPreafb,model);
            return actor;
        }

        public GameObject GetPlant(PlantType plantType)
        {
            GameObject plant = default(GameObject);
            Queue<GameObject> queue = default(Queue<GameObject>);
            if (!_pool.TryGetValue(plantType, out queue))
            {
                queue = new Queue<GameObject>();
                _pool.Add(plantType, queue);
            }

            if (queue.Count > 0)
            {
                plant = queue.Dequeue();
                plant.SetActive(true);
            }
            else
            {
                plant = CreatePlant(plantType);
            }

            return plant;
        }

        public void ReleasePlant(PlantType plantType, GameObject plant)
        {
            if (plant == null)
            {
                TPLog.LogFormat("can't release null plant:{0}", plantType);
                return;
            }

            Queue<GameObject> queue = default(Queue<GameObject>);
            if (_pool.TryGetValue(plantType, out queue))
            {
                queue.Enqueue(plant);
            }
            else
            {
                TPLog.LogFormat("Can't release Plant {0} which is not belongs to pool", plantType);
            }
        }
    }
}