using System;
using Framework.Config;
using Framework.Input;
using Framework.UI;
using GameCore.Plant;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameCore.UI.HUD
{
    public class HUDView:UIView
    {
        private Transform _plantListTrans;
        
        public override void Init()
        {
            _plantListTrans = Root.Find("PlantList");
        }
        
        public override string GetPrefabPath()
        {
            return "UI/HUD/HUD";
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        public void AddPlant(PlantInfo plantInfo, UnityAction callback)
        {
            GameObject plantItemPrefab = GlobalVars.ResourceManager.LoadAsset<GameObject>("UI/HUD/PlantItem");
            GameObject plantItem = GameObject.Instantiate(plantItemPrefab, Root);
            PlantItem item = new PlantItem(plantItem.transform);
            item.Init(plantInfo);
        }
    }
}