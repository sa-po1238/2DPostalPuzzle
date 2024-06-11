using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SortManager : MonoBehaviour
{
    private float countTime = 0;
    private float gameHour = 0;
    public TextMeshProUGUI countTimeText;
    [SerializeField] Button startButton;
    [SerializeField] Image Blur;
    [SerializeField] Button finishButton;

    void Awake()
    {
        Time.timeScale = 0f;    // 停止

        countTimeText.text = "0.00";
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        gameHour = (countTime / 60);
        countTimeText.text = gameHour.ToString("F2");
    }

    public void StartGame()
    {
        AudioManager.instance_AudioManager.PlaySE(3);

        Time.timeScale = 1f;    // 再生

        startButton.gameObject.SetActive(false);    // スタートボタン非表示
        Blur.gameObject.SetActive(false);    // ブラー非表示
    }

    public void StopGame()
    {
        AudioManager.instance_AudioManager.PlaySE(3);

        Time.timeScale = 0f;    // 停止

        finishButton.gameObject.SetActive(true);    // 終了ボタン表示
    }

    public void SceneToSaraly()
    {
        SceneManager.LoadScene("SalaryPart");
    }
}
