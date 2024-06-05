using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DaySet : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dayCountText;

    // Start is called before the first frame update
    void Start()
    {
        dayCountText.text = "Day " + Data.instance_Data.GetDay().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}