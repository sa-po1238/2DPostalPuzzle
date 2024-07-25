using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Button startButton;

    public void StartGameButton()
    {
        if (IsFirstPlay())
        {
            Data.instance_Data.SetData();
        }

        SceneManager.LoadScene("SortPart");
    }

    private bool IsFirstPlay()
    {
        if (PlayerPrefs.GetInt("Day") == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
