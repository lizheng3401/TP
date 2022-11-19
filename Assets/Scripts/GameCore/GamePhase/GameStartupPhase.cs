using Framework.Entity;
using GameCore.GridModule;
using GameCore.UI;
using GameCore.UI.HUD;
using GameCore.UI.Temp;
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
            
            HUDPage hudPage = new HUDPage(new HUDView());
            hudPage.Show();
        }

        public override void OnExit()
        {
            
        }
    }
}