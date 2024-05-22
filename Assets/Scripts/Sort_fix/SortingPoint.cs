using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingPoint : MonoBehaviour
{
    public int sortingScore;    // SortPartでのスコア
    public int sortingMiss; // SortPartでのミス回数

    private PostalItemManager postalItemManager;

    // Start is called before the first frame update
    void Start()
    {
        sortingScore = 0;
        sortingMiss = 0;
        postalItemManager = FindObjectOfType<PostalItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int score)
    {
        sortingScore += score;
        Debug.Log("Score: " + sortingScore);
        postalItemManager.SpawnPostalItem();
    }

    public void AddMiss(int miss)
    {
        sortingMiss += miss;
        Debug.Log("Miss: " + sortingMiss);
        postalItemManager.SpawnPostalItem();
    }
}
