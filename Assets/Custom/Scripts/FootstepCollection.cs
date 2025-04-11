using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[CreateAssetMenu(fileName = "New Footstep Collection", menuName = "Create New Footstep Collection")]
public class FootstepCollection : ScriptableObject
{
    public AudioClip walkSound; 
    public AudioClip runSound; 
    public AudioClip jumpSound;
}

