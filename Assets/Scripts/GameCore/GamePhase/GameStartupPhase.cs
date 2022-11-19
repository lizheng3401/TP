using Framework;
using Framework.Entity;
using GameCore.GridModule;
using GameCore.UI;
using GameCore.UI.HUD;
using UnityEngine;

namespace GameCore.GamePhase
{
    public class GameStartupPhase:BasePhase
    {
        public override void OnEnter()
        {
            PlantManager entityManager = new PlantManager();
            entityManager.Init();
            GlobalVars.ModuleManager.AddMoudle(entityManager);
            
            GridManager gridManager = new GridManager();
            GlobalVars.ModuleManager.AddMoudle(gridManager);
            gridManager.Init();
            gridManager.CreateGrid(new Vector2Int(6,10), new Vector2(1,1), new Vector2(0.1f, 0.1f));

            // 保证battle位于屏幕中心
            Vector3 center = GetBound(gridManager.GridRoot);
            CameraManager.Instance.cameraFocusOn = center;
            CameraManager.Instance.SwitchTo(CameraState.FocusOn);

            HUDPage hudPage = new HUDPage(new HUDView());
            hudPage.Show();
        }

        public override void OnExit()
        {
            
        }

        public Vector3 GetBound(Transform parentTrans)
        {
            Vector3 center = Vector3.zero;
            Renderer[] renderers = parentTrans.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
                center += renderer.bounds.center;
            }

            center = center / renderers.Length;
            return center;

        }
    }
}