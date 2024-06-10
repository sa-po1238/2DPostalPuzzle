using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouteSelect : MonoBehaviour
{
    public Button routeSelectButton;
    [Header("1:一般道 2:山道 3:高速道路")]
    [SerializeField] private int routeNumber;
    private int delayProbability;
    private float deliveryTime;

    private int day = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Debug.Log("Route Selected" + routeNumber);
        DelayCalculation();
    }

    private void DelayCalculation()
    {
        Debug.Log("Delay Calculation");
        if (routeNumber == 1)
        {
            delayProbability = 30;
            deliveryTime = 2.0f;
            Debug.Log("一般道");
        }
        else if (routeNumber == 2)
        {
            delayProbability = 10;
            deliveryTime = 3.0f;
            Debug.Log("山道");
        }
        else if (routeNumber == 3)
        {
            delayProbability = 10;
            deliveryTime = 0.50f;
            Debug.Log("高速道路");
        }
        else
        {
            Debug.Log("Error");
        }
        
        if (Probability(delayProbability))
        {
            Debug.Log("遅延発生");
        }
        else
        {
            Debug.Log("遅延なし");
        }
    }

    public static bool Probability(float fPercent)
    {
        float fProbabilityRate = UnityEngine.Random.value * 100.0f;

        if(fPercent == 100.0f && fProbabilityRate == fPercent)
        {
            return true;
        }
        else if (fProbabilityRate < fPercent)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
