using System.Collections.Generic;
using Framework.Config;
using Framework.Entity;
using Framework.UI;
using GameCore.GridModule;
using GameCore.Plant;
using UnityEngine;
using UnityEngine.Events;

namespace GameCore.UI.HUD
{
    public class HUDPage:UIController
    {
        private HUDView _view;
        private RaycastHit _hitInfo;
        private GridManager _gridManager;
        public HUDPage(UIView view, UILayer layer=UILayer.BelowPage) : base(view, layer)
        {
            this._view = view as HUDView;
            _gridManager = GlobalVars.ModuleManager.GetModule<GridManager>() as GridManager;
        }

        public override void SetupView()
        {
            base.SetupView();
            AddTick();
            List<PlantInfo> plantInfos = new List<PlantInfo>(Configuration.Instance.PlantCollection.Plants);
            InitPlantList(plantInfos, OnPlantItemClick);

        }

        public override void Dispose()
        {
            RemoveTick();
            base.Dispose();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Tick(float elapseSeconds, float realElapseSeconds)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out _hitInfo))
                {
                    MouseHandler(_hitInfo);
                }
            }
            
        }

        private void MouseHandler(RaycastHit hitInfo)
        {
            // 获取相对于GridRoot的localPosition
            Vector3 localPosition = hitInfo.point - _gridManager.GridRoot.transform.position;
            int row = 0, col = 0;
            _gridManager.GetCoordiates(localPosition, out row, out col);
            Cell cell = _gridManager.Cells[row][col];
            // 判断格子中是否已经存在植物
            if (!cell.CanPlant(PlantType.Elysia))
            {
                return;
            }
            
            GameObject ret = GlobalVars.ModuleManager.GetModule<PlantManager>().GetPlant(PlantType.Elysia);
            Vector3 position = _gridManager.Cells[row][col].CellTrans.transform.position;
            Quaternion quaternion = Quaternion.Euler(0f, 90f, 0f); // 朝向屏幕右方
            ret.transform.position = position;
            ret.transform.rotation = quaternion;
            
            cell.DoPlant(ret);
        }

        public void InitPlantList(List<PlantInfo> plantInfos, UnityAction<PlantType> callback)
        {
            foreach (var plantInfo in plantInfos)
            {
                this._view.AddPlant(plantInfo, () => { callback(plantInfo.type);});
            }
        }
        
        #region Event

        public void OnPlantItemClick(PlantType type)
        {
            // 修改mouse上下文
        }
        #endregion
    }
}