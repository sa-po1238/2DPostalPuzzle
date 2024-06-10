using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] int rows = 10;
    [SerializeField] int columns = 10;
    [SerializeField] float cellSize = 1.0f;
    [SerializeField] GameObject cellPrefab;

    private Cell[,] grid;

    void Awake()
    {
        grid = new Cell[rows, columns];
    }

    void Start()
    {
        CreateGrid();
    }

    /* グリッドの作成 */
    void CreateGrid()
    {
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                CreateCell(x, y);
            }
        }
    }

    private void CreateCell(int x, int y)
    {
        Vector3 cellPosition = new Vector3(x * cellSize, y * cellSize, 0);
        GameObject cellObject = Instantiate(cellPrefab, cellPosition, Quaternion.identity);
        cellObject.transform.SetParent(transform);  // GridManagerの子要素にする
        cellObject.transform.localPosition = cellPosition;  // 親のローカル座標系における位置を設定
        cellObject.transform.localScale = Vector3.one;  // スケールをリセット
        Cell cellComponent = cellObject.GetComponent<Cell>();  // Cellコンポーネントを取得
        if (cellComponent == null)
        {
            Debug.LogError("Cellコンポーネントがアタッチされていません");
            return;
        }
        grid[x, y] = cellComponent;  // グリッドにセルを格納
        grid[x, y].Initialize(x, y);  // セルの初期化
    }

    /* PostalItemが置けるかどうか */
    public bool CanPlaceItem(Vector2Int[] itemCells)
    {
        foreach (Vector2Int cell in itemCells)
        {
            if (!IsCellValid(cell) || grid[cell.x, cell.y].isOccupied)
            {
                return false;   // PostalItemが範囲外にあるか、すでに別のPostalItemが置かれている場合は置けない
            }
        }
        return true;
    }

    private bool IsCellValid(Vector2Int cell)
    {
        return cell.x >= 0 && cell.x < columns && cell.y >= 0 && cell.y < rows;
    }

    /* PostalItemを置く */
    public void PlaceItem(Vector2Int[] itemCells)
    {
        foreach (Vector2Int cell in itemCells)
        {
            if (IsCellValid(cell))
            {
                grid[cell.x, cell.y].isOccupied = true;  // PostalItemが置かれたセルを占有状態にする
            }
            else
            {
                Debug.LogError("PostalItemが範囲外に置かれました");
            }
        }
    }

    /* cellSizeのゲッターメソッド */
    public float GetCellSize()
    {
        return cellSize;
    }
}
