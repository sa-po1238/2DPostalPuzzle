using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    [SerializeField] private GameObject optionPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenOption()
    {
        AudioManager.instance_AudioManager.PlaySE(3);
        optionPanel.SetActive(true);
    }

    public void CloseOption()
    {
        AudioManager.instance_AudioManager.PlaySE(3);
        optionPanel.SetActive(false);
    }
}
