using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SortingBox : MonoBehaviour, IPointerClickHandler
{
    public string validAddress; // 受け入れる住所
    [SerializeField] TextMeshProUGUI sortingBoxNameText; // SortingBoxの名前を表示するText
    [SerializeField] Image boxOpenImage;    // SortingBoxが開いた状態の画像
    [SerializeField] Image boxCloseImage;   // SortingBoxが閉じた状態の画像

    public bool isOpen = false;    // SortingBoxが開いているかどうか

    void Awake()
    {
        boxOpenImage.enabled = false;   // SortingBoxが開いた状態の画像を非表示
        boxCloseImage.enabled = true;   // SortingBoxが閉じた状態の画像を表示

        sortingBoxNameText.text = validAddress; // SortingBoxの名前を表示
    }

    public string GetValidAddress() // 受け入れる住所を取得
    {
        return validAddress;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isOpen)
        {
            CloseBox();
        }
        else
        {
            OpenBox();
        }
    }

    private void OpenBox()
    {
        boxOpenImage.enabled = true;
        boxCloseImage.enabled = false;

        isOpen = true;
    }

    public void CloseBox()
    {
        boxOpenImage.enabled = false;
        boxCloseImage.enabled = true;

        isOpen = false;
    }

}