using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SortingPoint : MonoBehaviour
{
    public int sortingScore;    // SortPartでのスコア
    public int sortingMiss; // SortPartでのミス回数
    public TextMeshProUGUI sortingScoreText;    // スコアを表示するText

    private PostalItemManager postalItemManager;

    // Start is called before the first frame update
    void Start()
    {
        sortingScore = 0;
        sortingMiss = 0;
        sortingScoreText.text = "Score: " + sortingScore;
        //postalItemManager = FindObjectOfType<PostalItemManager>();
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
        }   
    }

    public void AddMiss(int miss)
    {
        sortingMiss += miss;
        Debug.Log("Miss: " + sortingMiss);
    }
}
