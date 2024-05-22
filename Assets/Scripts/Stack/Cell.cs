using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int x;
    public int y;
    public bool isOccupied;

    public void Initialize(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}