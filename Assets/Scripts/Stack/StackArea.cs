using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackArea : MonoBehaviour
{
    public RectTransform loadingArea; // 積載スペースを表すRectTransform
    private List<PostalItem> loadedItems = new List<PostalItem>(); // 積み込まれたアイテムのリスト

    public bool TryLoadItem(PostalItem item)
    {
        RectTransform itemRectTransform = item.GetComponent<RectTransform>();
        Rect itemRect = new Rect(itemRectTransform.anchoredPosition, itemRectTransform.sizeDelta);
        Rect loadingRect = new Rect(loadingArea.anchoredPosition, loadingArea.sizeDelta);

        // 積載スペース内にアイテムが収まるかチェック
        if (loadingRect.Overlaps(itemRect) && !IsOverlappingWithOtherItems(itemRect))
        {
            loadedItems.Add(item);
            item.transform.SetParent(loadingArea.transform); // トラックの積載スペースにアイテムを追加
            return true;
        }
        return false;
    }

    private bool IsOverlappingWithOtherItems(Rect itemRect)
    {
        foreach (PostalItem loadedItem in loadedItems)
        {
            RectTransform loadedItemRectTransform = loadedItem.GetComponent<RectTransform>();
            Rect loadedItemRect = new Rect(loadedItemRectTransform.anchoredPosition, loadedItemRectTransform.sizeDelta);

            if (loadedItemRect.Overlaps(itemRect))
            {
                return true; // 他の荷物と重なっている
            }
        }
        return false;
    }
}
