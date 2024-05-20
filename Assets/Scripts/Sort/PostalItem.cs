using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PostalItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public string address; // 住所
    private Vector3 initialPosition;    // PostalItemの初期位置
    private CanvasGroup canvasGroup;    // PostalItemのCanvasGroup

    private SortingPoint sortingPoint;

    private void Awake()
    {
        initialPosition = transform.position;   // PostalItemの初期位置を記憶
        canvasGroup = GetComponent<CanvasGroup>();  // PostalItemのCanvasGroupを取得
        sortingPoint = FindObjectOfType<SortingPoint>();    // SortingPointを取得
    }

    void Start()
    {
        // PostalItemを生成したときにCanvasの子要素にする
        transform.SetParent(GameObject.Find("Canvas").transform, false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;   // PostalItemをマウスカーソルに追従
        canvasGroup.blocksRaycasts = false; // ドラッグ中はレイキャストを無効化
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;  // ドラッグ終了時にレイキャストを有効化
        if (IsDroppedInValidBox() == false) // ドロップ先の箱が正しくない場合
        {
            transform.position = initialPosition;   // PostalItemを初期位置に戻す
        }
    }

    public string GetAddress()
    {
        return address;
    }

    
    private bool IsDroppedInValidBox()
    {
        /* PostalItemがドロップされた位置にあるオブジェクトを取得 */
        List<RaycastResult> results = new List<RaycastResult>();    // ドロップ位置のオブジェクトを格納するリスト
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current)   // ドロップ位置のイベントデータ
        {
            position = Input.mousePosition  // ドロップ位置をマウスカーソルの位置に設定
        };
        EventSystem.current.RaycastAll(pointerEventData, results);  // ドロップ位置のオブジェクトをすべて取得

        /* PostalItemがドロップされた位置にあるオブジェクトがSortingBoxであるかチェック */
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.GetComponent<SortingBox>() != null)   // SortingBoxの場合
            {
                SortingBox sortingBox = result.gameObject.GetComponent<SortingBox>();
                if (sortingBox.GetValidAddress() == address) // SortingBoxの住所とPostalItemの住所が一致する場合
                {
                    sortingPoint.AddScore(1);   // スコアを加算
                }
                else
                {
                    sortingPoint.AddMiss(1);    // ミス回数を加算
                }
                Destroy(this.gameObject);
                return true;    // PostalItemがドロップされた位置にSortingBoxがある場合
            }
            else    // SortingBoxでない場合
            {
                return false;   // PostalItemがドロップされた位置にSortingBoxがない場合
            }
        }
        return false;   // PostalItemがドロップされた位置にオブジェクトがない場合
    }
}