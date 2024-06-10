using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SortingPoint : MonoBehaviour
{
    public int sortingScore = 0;    // SortPartでのスコア
    public int sortingMiss = 0; // SortPartでのミス回数
    [SerializeField] TextMeshProUGUI sortingScoreText;    // スコアを表示するText
    [SerializeField] TextMeshProUGUI sortingMissText;
    [SerializeField] TextMeshProUGUI remainingText;

    // Start is called before the first frame update
    void Start()
    {
        sortingScoreText.text = "Score: " + sortingScore;
        sortingMissText.text = "Miss: " + sortingMiss;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(PostalItem item, int score)
    {
        if (!item.isScored)
        {
            sortingScore += score;
            Debug.Log("Score: " + sortingScore);
            sortingScoreText.text = "Score: " + sortingScore;
            item.isScored = true;

            Data.instance_Data.SetScore(sortingScore);   // スコアをDataに保存
        }
    }

    public void AddMiss(PostalItem item, int miss)
    {
        if (!item.isScored)
        {
            sortingMiss += miss;
            Debug.Log("Miss: " + sortingMiss);
            sortingMissText.text = "Miss: " + sortingMiss;
            item.isScored = true;

            Data.instance_Data.SetMiss(sortingMiss); // ミス回数をDataに保存
        }
    }

    public void AddRemaining(int count)
    {
        remainingText.text = "Remaining: " + count;
    }
}
