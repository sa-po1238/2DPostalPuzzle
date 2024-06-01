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
    private PostalItemManager postalItemManager;

    public TextMeshProUGUI addressText;

    public bool isScored = false;

    private void Awake()
    {
        initialPosition = transform.position;   // PostalItemの初期位置を記憶
        sortingPoint = FindObjectOfType<SortingPoint>();    // SortingPointを取得
        postalItemManager = FindObjectOfType<PostalItemManager>();    // PostalItemManagerを取得
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
        if (IsDroppedEnlargementSpace() == true)
        {
            addressText.enabled = true;
        }
        else
        {
            addressText.enabled = false;
        }

        if (IsDroppedInValidBox() == true)
        {
            Destroy(this.gameObject);    // PostalItemを削除
            postalItemManager.SpawnPostalItem(); // PostalItemを生成
        }

        if (IsDroppedEnlargementSpace() == false && IsDroppedInValidBox() == false)
        {
            transform.position = initialPosition;    // PostalItemを初期位置に戻す
        }

    }

    /* PostalItemがドロップされた位置にEnlargementSpaceがあるかチェック */
    private bool IsDroppedEnlargementSpace()
    {
        // PostalItemがドロップされた位置にあるオブジェクトを取得
        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);

        // PostalItemがドロップされた位置にあるオブジェクトがEnlargementSpaceであるかチェック
        foreach (Collider2D collider in colliders)
        {
            // タグがEnlargementSpaceのオブジェクトがある場合
            if (collider.tag == "EnlargementSpace")
            {
                return true; // PostalItemがドロップされた位置にEnlargementSpaceがある場合
            }
        }
        return false; // PostalItemがドロップされた位置にEnlargementSpaceがない場合
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
                    sortingPoint.AddScore(this,1); // スコアを加算
                }
                else
                {
                    sortingPoint.AddMiss(1); // ミス回数を加算
                }
                return true; // PostalItemがドロップされた位置にSortingBoxがある場合
            }
        }
        return false; // PostalItemがドロップされた位置にSortingBoxがない場合
    }
    
}