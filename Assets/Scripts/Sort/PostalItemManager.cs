using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostalItemManager : MonoBehaviour
{
    public int postalItemCount = 3;
    public GameObject postalItemPrefab;
    public Transform spawnPoint;

    public void SpawnPostalItem()
    {
        postalItemCount--;  // PostalItemの残り数を減らす
        if (postalItemCount < 0)    // PostalItemがすべて生成された場合
        {
            return;
        }
        GameObject newPostalItem = Instantiate(postalItemPrefab, spawnPoint.position, Quaternion.identity); // PostalItemを生成
        Debug.Log("PostalItem Spawned");
        PostalItem postalItem = newPostalItem.GetComponent<PostalItem>();   // PostalItemコンポーネントを取得

        string address = GetRandomAddress();
        postalItem.address = address;   // 住所を設定
    }


    // アドレス作成
    private string GetRandomAddress()
    {
        string[] addresses = new string[]
        {
            "123 Main St.",
            "456 Elm St.",
            "789 Oak St."
        };
        return addresses[Random.Range(0, addresses.Length)];
    }
}