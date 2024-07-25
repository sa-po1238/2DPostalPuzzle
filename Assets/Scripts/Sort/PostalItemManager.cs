using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostalItemManager : MonoBehaviour
{
    public int postalItemCount;
    public GameObject postalItemPrefab;
    public GameObject[] labelPrefabs;
    public Transform spawnPoint;

    private SortingPoint sortingPoint;
    private SortManager sortManager;

    private string[] cityNames = new string[]
    {
        "Persimmon Ctr",
        "Plum St",
        "Watermelon St",
        "Papaya Bl"
    };

    private void Start()
    {
        Debug.Log("PostalItemManager Start");
        sortingPoint = FindObjectOfType<SortingPoint>();
        sortManager = FindObjectOfType<SortManager>();
        sortingPoint.AddRemaining(postalItemCount);
        SpawnPostalItem();
    }

    public void SpawnPostalItem()
    {
        postalItemCount--;
        if (postalItemCount < 0)
        {
            sortManager.StopGame(); // ゲーム終了
            return;
        }

        sortingPoint.AddRemaining(postalItemCount);

        GameObject newPostalItem = Instantiate(postalItemPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("PostalItem Spawned");
        PostalItem postalItem = newPostalItem.GetComponent<PostalItem>();

        postalItem.toAddress = GetRandomAddress();
        postalItem.fromAddress = GetRandomAddress();
        postalItem.toPersonName = GetRandomPersonName();
        postalItem.fromPersonName = GetRandomPersonName();
        postalItem.itemName = GetRandomItemName();
        postalItem.itemWeight = GetRandomItemWeight();

    /*
        // labelPrefabsをすべて非表示にする
        foreach (GameObject labelPrefab in labelPrefabs)
        {
            labelPrefab.SetActive(false);
        }
    */
    }

    private string GetRandomAddress()
    {
        int addressNum = Random.Range(0, 1000);
        string cityName = cityNames[Random.Range(0, cityNames.Length)];
        return addressNum + " " + cityName;
    }

    private string GetRandomPersonName()
    {
        string[] firstNames = new string[]
        {
            "Alice", "Bob", "Charlie", "David", "Eve", "Frank",
            "Grace", "Heidi", "Ivan", "Judy", "Kevin", "Linda",
            "Mallory", "Nancy", "Oscar", "Peggy", "Quentin", "Randy",
            "Steve", "Trent", "Ursula", "Victor", "Wendy", "Xander",
            "Yvonne", "Zelda"
        };

        string[] lastNames = new string[]
        {
            "Smith", "Johnson", "Williams", "Jones", "Brown",
            "Davis", "Miller", "Wilson", "Moore", "Taylor",
            "Anderson", "Thomas", "Jackson", "White", "Harris",
            "Martin", "Thompson", "Garcia", "Martinez", "Robinson",
            "Clark", "Rodriguez", "Lewis", "Lee", "Walker"
        };

        string firstName = firstNames[Random.Range(0, firstNames.Length)];
        string lastName = lastNames[Random.Range(0, lastNames.Length)];
        return firstName + " " + lastName;
    }

    private string GetRandomItemName()
    {
        string[] itemNames = new string[]
        {
            "Laptop", "Books", "Clothes", "Shoes", "Toys",
            "Fruits", "Vegetables", "Sporting Goods", "Home Decor",
            "Electronics", "Groceries"
        };

        return itemNames[Random.Range(0, itemNames.Length)];
    }

    private string GetRandomItemWeight()
    {
        float randomWeight = Random.Range(0.1f, 10.0f);
        return randomWeight.ToString("F1") + "kg";
    }

    /*
    public void SetActiveLabel()
    {
        AudioManager.instance_AudioManager.PlaySE(4);

        int index = Random.Range(0, labelPrefabs.Length-1);
        Debug.Log("SetActiveLabel: " + index);
        labelPrefabs[index].SetActive(true);
    }
    */
}