using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SortingBox : MonoBehaviour //, IDropHandler
{
    public string validAddress; // 受け入れる住所

    /*
    public void OnDrop(PointerEventData eventData)
    {
        var postalItem = eventData.pointerDrag.GetComponent<PostalItem>();  // PostalItemを取得
        if (postalItem != null && postalItem.GetAddress() == validAddress)  // PostalItemの住所が受け入れる住所と一致する場合
        {
            // PostalItemがドロップされた箱が正しい場合
            postalItem.transform.position = transform.position; // PostalItemを箱の中心に移動
        }
    }
    */

    public string GetValidAddress() // 受け入れる住所を取得
    {
        return validAddress;
    }
}