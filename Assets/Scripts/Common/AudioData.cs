using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AudioData")]
public class AudioData : ScriptableObject
{
    public List<Datum> SE_Data = new List<Datum>();
    public List<Datum> BGM_Data = new List<Datum>();
}

[System.Serializable]
public class Datum
{
    public int id;
    public AudioClip clip;
    [Range(0, 1)] public float volume = 0.5f;
    public string memo = string.Empty;
}