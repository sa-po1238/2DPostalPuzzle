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
        SetSaraly();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetSaraly()
    {
        quotaText.text = Data.instance_Data.GetQuota().ToString() + "個";
        scoreText.text = Data.instance_Data.GetScore().ToString() + "個";
        saralyText.text = CaluculateSaraly() + "円";
    }

    private int CaluculateSaraly()
    {
        int saraly = Data.instance_Data.GetScore();
        int miss = Data.instance_Data.GetMiss();
        saraly = saraly * 100 - miss * 50;
        Data.instance_Data.SetMoney(saraly);
        return saraly;
    }
}