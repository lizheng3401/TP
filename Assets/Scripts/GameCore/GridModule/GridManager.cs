using System.Collections.Generic;
using Framework.Resource;
using UnityEngine;
using UnityEngine.Internal;


namespace GameCore.GridModule
{
    public class GridManager:BaseModule
    {
        public Vector2Int GridSize = default(Vector2Int);
        public Vector2 CellSize;
        public Vector2 OffsetSize;

        public Cell[][]  Cells = default(Cell[][]);
        private Transform _gridRoot = default(Transform);
        public Transform GridRoot => _gridRoot;

        public GameObject CellPrefab;
        
        public void Init()
        {
            _gridRoot = new GameObject("GridRoot").transform;
            CellPrefab = GlobalVars.ResourceManager.LoadAsset<GameObject>("Grid/Cell");
        }
        
        /// <summary>
        /// 创建Grid
        /// </summary>
        public void CreateGrid(Vector2Int gridSize, Vector2 cellSize, Vector2 offsetSize)
        {
            this.GridSize = gridSize;
            this.CellSize = cellSize;
            this.OffsetSize = offsetSize;

            Cells = new Cell[gridSize.x][];
            Vector3 origin = new Vector3(CellSize.x / 2, 0f, CellSize.y / 2);
            for (int row = 0; row < gridSize.x; ++row)
            {
                Cells[row] = new Cell[gridSize.y];
                for (int col = 0; col < gridSize.y; ++col)
                {
                    float x = (cellSize.x + offsetSize.y) * col + origin.x;
                    float z = (cellSize.y + offsetSize.x) * row + origin.z;

                    GameObject cellGo = GameObject.Instantiate(CellPrefab, _gridRoot);
                    cellGo.transform.localPosition = new Vector3(x, 0, z);
                    cellGo.name = string.Format("{0}_{1}_Cube", row, col);
                    Cells[row][col] = new Cell();
                    Cells[row][col].CellTrans = cellGo.transform;
                    Cells[row][col].Pos = new Vector2(row, col);
                }
            }
        }

        internal override void Tick(float elapseSeconds, float realElapseSeconds)
        {
            
        }

        internal override void ShutDown()
        {
            GridSize = Vector2Int.zero;
        }

        public void GetCoordiates(Vector3 position, out int row, out int col)
        {
            col = Mathf.FloorToInt(position.x / (CellSize.x + OffsetSize.x ));
            float modCol = position.x - (col * (CellSize.x + OffsetSize.x));

            row = Mathf.FloorToInt(position.z / (CellSize.y + OffsetSize.y));
            float modRow = position.z - (row * (CellSize.y + OffsetSize.y));
            
            if (modCol <= CellSize.x && modRow <= CellSize.y)
            {
                Debug.LogFormat("在格子里({0},{1})", row, col);
            }
            else
            {
                Debug.LogFormat("在间隔里{0}", col);
            }
        }
    }
}