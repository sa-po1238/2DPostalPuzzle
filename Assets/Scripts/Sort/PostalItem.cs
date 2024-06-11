using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PostalItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public string toAddress; // 送り先住所
    public string fromAddress; // 送り元住所
    public string toPersonName; // 送り先名前
    public string fromPersonName; // 送り元名前
    public string itemName; // アイテム名
    public string itemWeight; // アイテム重量
    public string itemSize; // アイテムサイズ

    private Vector3 lastPosition; // PostalItemの最後の位置
    private SortingPoint sortingPoint;
    private PostalItemManager postalItemManager;

    private TextMeshProUGUI toAddressText;
    private TextMeshProUGUI fromAddressText;
    private TextMeshProUGUI toPersonNameText;
    private TextMeshProUGUI fromPersonNameText;
    private TextMeshProUGUI itemNameText;
    private TextMeshProUGUI itemWeightText;

    public bool isScored = false; // PostalItemが多重にスコアを加算しないようにするフラグ
    private bool isShown = false;    //labelが表示されているかどうか

    private void Awake()
    {
        lastPosition = transform.position; // PostalItemの初期位置を記憶
        sortingPoint = FindObjectOfType<SortingPoint>();
        postalItemManager = FindObjectOfType<PostalItemManager>();
        InitializeTextFields();
    }

    private void InitializeTextFields()
    {
        // テキストフィールドの参照を取得
        toAddressText = GameObject.Find("ToAddressText").GetComponent<TextMeshProUGUI>();
        fromAddressText = GameObject.Find("FromAddressText").GetComponent<TextMeshProUGUI>();
        toPersonNameText = GameObject.Find("ToPersonNameText").GetComponent<TextMeshProUGUI>();
        fromPersonNameText = GameObject.Find("FromPersonNameText").GetComponent<TextMeshProUGUI>();
        itemNameText = GameObject.Find("ItemNameText").GetComponent<TextMeshProUGUI>();
        itemWeightText = GameObject.Find("ItemWeightText").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        // PostalItemの情報を表示
        SetTextFields();
        ToggleTextFields(false); // 初期状態では非表示
    }

    private void SetTextFields()
    {
        toAddressText.text = toAddress;
        fromAddressText.text = fromAddress;
        toPersonNameText.text = toPersonName;
        fromPersonNameText.text = fromPersonName;
        itemNameText.text = itemName;
        itemWeightText.text = itemWeight;
    }

    private void ToggleTextFields(bool isEnabled)
    {
        toAddressText.enabled = isEnabled;
        fromAddressText.enabled = isEnabled;
        toPersonNameText.enabled = isEnabled;
        fromPersonNameText.enabled = isEnabled;
        itemNameText.enabled = isEnabled;
        itemWeightText.enabled = isEnabled;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // マウスカーソルの位置を取得し、PostalItemをマウスカーソルに追従
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, lastPosition.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsDroppedEnlargementSpace())
        {
            ToggleTextFields(true);
        }

        if (IsDroppedInValidBox())
        {
            Destroy(gameObject);
            postalItemManager.SpawnPostalItem();
        }
        else
        {
            transform.position = lastPosition; // PostalItemを最後の位置に戻す
        }
    }

    private bool IsDroppedEnlargementSpace()
    {
        postalItemManager.SetActiveLabel();

        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("EnlargementSpace"))
            {
                lastPosition = transform.position; // PostalItemの最後の位置を記憶
                return true;
            }
        }
        return false;
    }

    private bool IsDroppedInValidBox()
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);

        foreach (Collider2D collider in colliders)
        {
            SortingBox sortingBox = collider.GetComponent<SortingBox>();
            if (sortingBox != null && sortingBox.isOpen)
            {
                if (toAddress.Contains(sortingBox.GetValidAddress()))
                {
                    sortingPoint.AddScore(this, 1); // スコアを加算
                }
                else
                {
                    sortingPoint.AddMiss(this, 1); // ミス回数を加算
                }
                sortingBox.CloseBox(); // SortingBoxを閉じる
                Debug.Log("PostalItem Dropped in SortingBox");
                return true;
            }
        }
        return false;
    }
}
