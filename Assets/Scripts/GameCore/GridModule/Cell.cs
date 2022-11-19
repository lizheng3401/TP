using System;
using GameCore.Plant;
using UnityEngine;

namespace GameCore.GridModule
{
    public class Cell:IDisposable
    {
        public Vector2 Pos;
        public Transform CellTrans;
        public GameObject UnitOnCell;
        public Cell()
        {
            
        }

        public void Init()
        {
            
        }
        
        public void Dispose()
        {
            
        }

        public bool CanPlant(PlantType plantType)
        {
            if (UnitOnCell != null)
            {
                return false;
            }

            return true;
        }

        public void DoPlant(GameObject plant)
        {
            this.UnitOnCell = plant;
        }
    }
}