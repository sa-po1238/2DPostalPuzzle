using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    [SerializeField] private AudioSource SESource;
    [SerializeField] private AudioSource BGMSource;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnValueChangedSE(float value)
    {
        SESource.volume = value;
    }

    public void OnValueChangedBGM(float value)
    {
        BGMSource.volume = value;
    }

}
