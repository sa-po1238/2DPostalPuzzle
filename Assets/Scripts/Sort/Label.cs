using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Label : MonoBehaviour
{
    public TextMeshProUGUI toAddressText;
    public TextMeshProUGUI fromAddressText;
    public TextMeshProUGUI toPersonNameText;
    public TextMeshProUGUI fromPersonNameText;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemWeightText;

    // テキストフィールドの初期化メソッド
    public void InitializeTextFields(string toAddress, string fromAddress, string toPersonName, string fromPersonName, string itemName, string itemWeight)
    {
        Debug.Log("Label InitializeTextFields");
        toAddressText.text = toAddress;
        fromAddressText.text = fromAddress;
        toPersonNameText.text = toPersonName;
        fromPersonNameText.text = fromPersonName;
        itemNameText.text = itemName;
        itemWeightText.text = itemWeight;
    }

    // テキストフィールドの表示/非表示を切り替えるメソッド
    public void ToggleTextFields(bool isEnabled)
    {
        Debug.Log("Label ToggleTextFields");
        toAddressText.enabled = isEnabled;
        fromAddressText.enabled = isEnabled;
        toPersonNameText.enabled = isEnabled;
        fromPersonNameText.enabled = isEnabled;
        itemNameText.enabled = isEnabled;
        itemWeightText.enabled = isEnabled;
    }
}