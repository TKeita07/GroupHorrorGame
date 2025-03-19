using UnityEngine;

[System.Serializable]
public class Music
{
    public string musicID;
    public AudioClip musicClip;
    [HideInInspector] public AudioSource musicSource;
}
