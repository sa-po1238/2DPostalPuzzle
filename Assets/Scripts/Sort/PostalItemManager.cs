using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostalItemManager : MonoBehaviour
{
    public int postalItemCount;
    public GameObject postalItemPrefab;
    public Transform spawnPoint;

    private SortingPoint sortingPoint;

    private string[] cityNames = new string[]
    {
        "Persimmon Ctr",
        "Plum St",
        "Watermelon St",
        "Papaya Bl"
    };

    public void Start()
    {
        Debug.Log("PostalItemManager Start");
        sortingPoint = FindObjectOfType<SortingPoint>();
        sortingPoint.AddRemaining(postalItemCount);
        SpawnPostalItem();
    }

    public void SpawnPostalItem()
    {
        postalItemCount--;  // PostalItemの残り数を減らす
        sortingPoint.AddRemaining(postalItemCount);    // 残りPostalItem数を表示
        if (postalItemCount < 0)    // PostalItemがすべて生成された場合
        {
            return;
        }
        GameObject newPostalItem = Instantiate(postalItemPrefab, spawnPoint.position, Quaternion.identity); // PostalItemを生成
        Debug.Log("PostalItem Spawned");
        PostalItem postalItem = newPostalItem.GetComponent<PostalItem>();   // PostalItemコンポーネントを取得

        string address = GetRandomAddress();
        Debug.Log("Address: " + address);
        postalItem.address = address;   // 住所を設定
    }


    /* アドレス作成 */
    private string GetRandomAddress()
    {
        int addressNum = Random.Range(0, 1000);
        int randomNum = Random.Range(0, cityNames.Length);
        string cityName = cityNames[randomNum];
        
        string address = addressNum + " " + cityName;
        return address;
    }
}