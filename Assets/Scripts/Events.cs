using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public static Action OnGameOver;

    public static void GameOver()
    {
        OnGameOver?.Invoke();
    }
}
