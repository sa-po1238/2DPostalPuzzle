using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PostalItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public string address; // 住所
    private Vector3 initialPosition;    // PostalItemの初期位置
    private SpriteRenderer spriteRenderer;    // PostalItemのSpriteRenderer

    private SortingPoint sortingPoint;

    public TextMeshProUGUI addressText;

    private void Awake()
    {
        initialPosition = transform.position;   // PostalItemの初期位置を記憶
        sortingPoint = FindObjectOfType<SortingPoint>();    // SortingPointを取得
        spriteRenderer = GetComponent<SpriteRenderer>();   // PostalItemのSpriteRendererを取得
    }

    void Start()
    {
        // PostalItemの住所を表示
        addressText.text = address;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);    // マウスカーソルの位置を取得
        transform.position = new Vector3(mousePosition.x, mousePosition.y, initialPosition.z);   // PostalItemをマウスカーソルに追従
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsDroppedInValidBox() == false) // ドロップ先の箱が正しくない場合
        {
            transform.position = initialPosition;   // PostalItemを初期位置に戻す
        }
    }

    /* PostalItemがドロップされた位置にSortingBoxがあるかチェック */  
    private bool IsDroppedInValidBox()
    {
        // PostalItemがドロップされた位置にあるオブジェクトを取得
        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);

        // PostalItemがドロップされた位置にあるオブジェクトがSortingBoxであるかチェック
        foreach (Collider2D collider in colliders)
        {
            SortingBox sortingBox = collider.GetComponent<SortingBox>();
            if (sortingBox != null) // SortingBoxの場合
            {
                if (address.Contains(sortingBox.GetValidAddress())) // SortingBoxの住所とPostalItemの住所が部分一致する場合
                {
                    sortingPoint.AddScore(1); // スコアを加算
                }
                else
                {
                    sortingPoint.AddMiss(1); // ミス回数を加算
                }
                Destroy(this.gameObject);
                return true; // PostalItemがドロップされた位置にSortingBoxがある場合
            }
        }
        return false; // PostalItemがドロップされた位置にSortingBoxがない場合
    }
    
}