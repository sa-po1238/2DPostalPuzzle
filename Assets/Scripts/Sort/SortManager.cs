using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SortManager : MonoBehaviour
{
    float countTime = 0;
    public TextMeshProUGUI countTimeText;
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;    // 停止

        countTimeText.text = "0.00";
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        countTimeText.text = countTime.ToString("F2");
    }

    public void StartGame()
    {
        Time.timeScale = 1f;    // 再生

        startButton.gameObject.SetActive(false);    // スタートボタン非表示
    }
}
