using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaralyUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI quotaText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI saralyText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetSaraly()
    {
        quotaText.text = "今日のノルマ " + Data.instance_Data.GetQuota().ToString() + "個";
        scoreText.text = "配送した荷物の数 " + Data.instance_Data.GetScore().ToString() + "個";
        saralyText.text = "給料 " + Data.instance_Data.GetSaraly().ToString() + "円";
    }

    public void 
}
