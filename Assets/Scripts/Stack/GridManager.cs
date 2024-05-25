using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int rows = 10;
    public int columns = 10;
    public float cellSize = 1.0f;
    public GameObject cellPrefab;

    private Cell[,] grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Cell[rows, columns];
        CreateGrid();
    }

    /* グリッドの作成 */
    void CreateGrid()
    {
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                Vector3 cellPosition = new Vector3(x * cellSize, y * cellSize, 0);
                GameObject cellObject = Instantiate(cellPrefab, cellPosition, Quaternion.identity);
                cellObject.transform.SetParent(transform);  // GridManagerの子要素にする
                cellObject.transform.localPosition = cellPosition;  // 親のローカル座標系における位置を設定
                cellObject.transform.localScale = Vector3.one;  // スケールをリセット
                grid[x, y] = cellObject.GetComponent<Cell>();  // Cellコンポーネントを取得
                grid[x, y].Initialize(x, y);  // セルの初期化
            }
        }
    }

    /* PostalItemが置けるかどうか */
    public bool CanPlaceItem(Vector2Int[] itemCells)
    {
        foreach (Vector2Int cell in itemCells)
        {
            if (cell.x < 0 || cell.x >= columns || cell.y < 0 || cell.y >= rows || grid[cell.x, cell.y].isOccupied)
            {
                return false;   // PostalItemが範囲外にあるか、すでに別のPostalItemが置かれている場合は置けない
            }
        }
        return true;
    }

    /* PostalItemを置く */
    public void PlaceItem(Vector2Int[] itemCells)
    {
        foreach (Vector2Int cell in itemCells)
        {
            grid[cell.x, cell.y].isOccupied = true;   // PostalItemが置かれたセルを占有状態にする
        }
    }
}
