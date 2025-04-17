using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneLoadData
{
    public static bool hasSeenTutorial = false;
    public static bool clockStarted = false;
    public static float timeLeft = 0.0f;
    public static bool reduceTime = false;
    public static bool dead = false;
    public static bool success = false;
    public static bool delayNunSpawn = false;
    public static bool isPlayerInCimetery = false;

    public static float FX_Volume = 0.0f;
    public static float Music_Volume = 0.0f;


    

    public static List<string> deadKids= new List<string>();
}
