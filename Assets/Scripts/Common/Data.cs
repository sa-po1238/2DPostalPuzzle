using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data instance_Data;

    void Awake()
    {
        CheckInstancce();
    }

    private void CheckInstancce()
    {
        if (instance_Data == null)
        {
            instance_Data = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance_AudioManager.PlayBGM(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // データの初期化
    public void SetData()
    {
        PlayerPrefs.SetInt("Day", 0);
        PlayerPrefs.SetInt("Quota", 0);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Miss", 0);
        PlayerPrefs.SetInt("Money", 0);
        Debug.Log("データを初期化しました");
    }

    // 日にちのセット
    public void SetDay(int day)
    {
        PlayerPrefs.SetInt("Day", day);
    }

    // 日にちの取得
    public int GetDay()
    {
        return PlayerPrefs.GetInt("Day");
    }

    // ノルマのセット
    public void GetQuota(int quota)
    {
        PlayerPrefs.SetIn("Quota", quota);
    }

    // ノルマの取得
    public int GetQuota()
    {
        return PlayerPrefs.GetInt("Quota");
    }

    // スコアのセット
    public void SetScore(int score)
    {
        PlayerPrefs.SetInt("Score", score);
    }

    // スコアの取得
    public int GetScore()
    {
        return PlayerPrefs.GetInt("Score");
    }

    // ミスのセット
    public void SetMiss(int miss)
    {
        PlayerPrefs.SetInt("Miss", miss);
    }

    // ミスの取得
    public int GetMiss()
    {
        return PlayerPrefs.GetInt("Miss");
    }

    // 残金のセット
    public void SetMoney(int money)
    {
        int currentMoney = PlayerPrefs.GetInt("Money");
        currentMoney += money;
        PlayerPrefs.SetInt("Money", currentMoney);
    }

    // 残金の取得
    public int GetMoney()
    {
        return PlayerPrefs.GetInt("Money");
    }
}
