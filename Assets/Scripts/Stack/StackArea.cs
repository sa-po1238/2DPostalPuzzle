using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackArea : MonoBehaviour
{
    public RectTransform loadingArea; // 積載スペースを表すRectTransform
    private List<PostalItem> loadedItems = new List<PostalItem>(); // 積み込まれたアイテムのリスト

    public bool TryLoadItem(PostalItem item)    // アイテムを積み込む
    {
        RectTransform itemRectTransform = item.GetComponent<RectTransform>();   // アイテムのRectTransformを取得
        Rect itemRect = new Rect(itemRectTransform.anchoredPosition, itemRectTransform.sizeDelta);  // アイテムの矩形を取得
        Rect loadingRect = new Rect(loadingArea.anchoredPosition, loadingArea.sizeDelta);   // 積載スペースの矩形を取得

        // 積載スペース内にアイテムが収まるかチェック
        if (loadingRect.Overlaps(itemRect) && !IsOverlappingWithOtherItems(itemRect))   // アイテムが積載スペース内に収まり、他のアイテムと重なっていないか
        {
            loadedItems.Add(item);  // アイテムを積み込む
            item.transform.SetParent(loadingArea.transform); // トラックの積載スペースにアイテムを追加
            return true;
        }
        return false;
    }

    private bool IsOverlappingWithOtherItems(Rect itemRect)  // 他の荷物と重なっているかチェック
    {
        foreach (PostalItem loadedItem in loadedItems)  // 積み込まれたアイテムをチェック
        {
            RectTransform loadedItemRectTransform = loadedItem.GetComponent<RectTransform>();   // 積み込まれたアイテムのRectTransformを取得
            Rect loadedItemRect = new Rect(loadedItemRectTransform.anchoredPosition, loadedItemRectTransform.sizeDelta);    // 積み込まれたアイテムの矩形を取得

            if (loadedItemRect.Overlaps(itemRect))  // 他の荷物と重なっているかチェック
            {
                return true; // 他の荷物と重なっている
            }
        }
        return false;
    }
}
