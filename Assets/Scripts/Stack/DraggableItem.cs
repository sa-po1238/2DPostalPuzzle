using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 initialPosition;    // PostalItemの初期位置
    private RectTransform rectTransform;    // PostalItemのRectTransform
    private GridManager gridManager;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.position;
        gridManager = FindObjectOfType<GridManager>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2Int[] itemCells = GetItemCells();    // PostalItemのセル座標を取得
        if (gridManager.CanPlaceItem(itemCells))
        {
            gridManager.PlaceItem(itemCells);   // PostalItemを置く
            initialPosition = rectTransform.position;  // 正しい位置にドロップした場合、新しい位置を初期位置にする
        }
        else
        {
            rectTransform.position = initialPosition;  // 元の位置に戻す
        }
    }

    /* PostalItemのセル座標を取得 */
    private Vector2Int[] GetItemCells()
    {
        List<Vector2Int> cells = new List<Vector2Int>();    // PostalItemのセル座標を格納するリスト
        foreach (RectTransform child in rectTransform)  // PostalItemの子要素を取得
        {
            // PostalItemの子要素のRectTransformからセル座標を取得
            Vector2Int cell = new Vector2Int(
                Mathf.RoundToInt(child.localPosition.x / gridManager.GetCellSize()),
                Mathf.RoundToInt(child.localPosition.y / gridManager.GetCellSize())
            );
            cells.Add(cell);
        }
        return cells.ToArray();
    }
}
