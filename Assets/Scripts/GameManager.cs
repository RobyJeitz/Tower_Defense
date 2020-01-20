﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GameManager
{
    private static Menu menu;

    public static int WheelersDestroyedCount { get; private set; }

    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        menu = Object.FindObjectOfType<Menu>();
    }

    public static void IncrementDestroyedCounter()
    {
        WheelersDestroyedCount++;
    }

    public static void Reset()
    {
        SpawnerManager[] spawnerManagers = Object.FindObjectsOfType<SpawnerManager>();

        foreach (SpawnerManager spawnerManager in spawnerManagers)
        {
            spawnerManager.Reset();
        }

        WheelersDestroyedCount = 0;
        menu.ShowMenuStart();
    }

    public static void GameOver()
    {
        menu.ShowMenuGameOver(WheelersDestroyedCount);
    }
}
