using GameCore.Plant;
using UnityEngine;

namespace Framework.Config
{
    [CreateAssetMenu(fileName = "PlantCollection", menuName = "AssetData/PlantCollections")]
    public class PlantCollection:ScriptableObject
    {
        public PlantInfo[] Plants;

        public PlantInfo GetPlantInfoByType(PlantType plantType)
        {
            foreach (var plant in Plants)
            {
                if (plant.type == plantType)
                {
                    return plant;
                }
            }

            return null;
        }
    }
}