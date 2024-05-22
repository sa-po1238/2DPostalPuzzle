using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SortingBox : MonoBehaviour
{
    public string validAddress; // 受け入れる住所
    public TextMeshProUGUI sortingBoxNameText; // SortingBoxの名前を表示するText

    void Start()
    {
        sortingBoxNameText.text = validAddress; // SortingBoxの名前を表示
    
    }

    public string GetValidAddress() // 受け入れる住所を取得
    {
        return validAddress;
    }

}