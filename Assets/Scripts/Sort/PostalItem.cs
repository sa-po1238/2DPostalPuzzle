using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PostalItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public string toAddress; // 送り先住所
    public string fromAddress;  // 送り元住所
    private Vector3 lastPosition;   // PostalItemの最後の位置

    private SortingPoint sortingPoint;
    private PostalItemManager postalItemManager;
    private SortingBox sortingBox;

    private TextMeshProUGUI toAddressText;
    private TextMeshProUGUI fromAddressText;
    private TextMeshProUGUI itemNameText;

    public bool isScored = false;   // PostalItemが多重にスコアを加算しないようにするフラグ

    private void Awake()
    {
        lastPosition = transform.position;   // PostalItemの初期位置を記憶
        sortingPoint = FindObjectOfType<SortingPoint>();
        postalItemManager = FindObjectOfType<PostalItemManager>();
        sortingBox = FindObjectOfType<SortingBox>();

        toAddressText = GameObject.Find("ToAddressText").GetComponent<TextMeshProUGUI>();
        fromAddressText = GameObject.Find("FromAddressText").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        // PostalItemの住所を表示
        toAddressText.text = toAddress;
        fromAddressText.text = fromAddress;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);    // マウスカーソルの位置を取得
        transform.position = new Vector3(mousePosition.x, mousePosition.y, lastPosition.z);   // PostalItemをマウスカーソルに追従
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // PostalItemがドロップされた位置にEnlargementSpaceがある場合
        if (IsDroppedEnlargementSpace() == true)
        {
            toAddressText.enabled = true;
        }
        else
        {
            toAddressText.enabled = false;
        }

        // PostalItemが正しい箱にドロップされた場合
        if (IsDroppedInValidBox() == true)
        {
            Destroy(this.gameObject);    // PostalItemを削除
            sortingBox.CloseBox();  // SortingBoxを閉じる
            postalItemManager.SpawnPostalItem(); // PostalItemを生成
        }

        if (IsDroppedEnlargementSpace() == false && IsDroppedInValidBox() == false)
        {
            transform.position = lastPosition;    // PostalItemを最後の位置に戻す
        }

    }

    /* PostalItemがドロップされた位置にEnlargementSpaceがあるかチェック */
    private bool IsDroppedEnlargementSpace()
    {
        // ドロップされた位置にあるオブジェクトを取得
        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);

        // ドロップされた位置にあるオブジェクトがEnlargementSpaceであるかチェック
        foreach (Collider2D collider in colliders)
        {
            // EnlargementSpaceがある場合
            if (collider.tag == "EnlargementSpace")
            {
                lastPosition = transform.position;   // PostalItemの最後の位置を記憶
                return true;
            }
        }
        // EnlargementSpaceがない場合
        return false;
    }

    /* PostalItemがドロップされた位置にSortingBoxがあるかチェック */  
    private bool IsDroppedInValidBox()
    {
        if (sortingBox.isOpen == false) // SortingBoxが閉じている場合
        {
            return false;
        }
        // PostalItemがドロップされた位置にあるオブジェクトを取得
        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);

        // PostalItemがドロップされた位置にあるオブジェクトがSortingBoxであるかチェック
        foreach (Collider2D collider in colliders)
        {
            SortingBox sortingBox = collider.GetComponent<SortingBox>();
            if (sortingBox != null) // SortingBoxの場合
            {
                if (toAddress.Contains(sortingBox.GetValidAddress())) // SortingBoxの住所とPostalItemの住所が部分一致する場合
                {
                    sortingPoint.AddScore(this,1); // スコアを加算
                }
                else
                {
                    sortingPoint.AddMiss(this,1); // ミス回数を加算
                }
                Debug.Log("PostalItem Dropped in SortingBox");
                return true; // SortingBoxがある場合
            }
        }
        return false; // SortingBoxがない場合
    }
    
}