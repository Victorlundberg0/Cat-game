using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public float[] allFishesCollected;//array with all levels fishes.


    public LevelData(GameManager Level)
    {
        allFishesCollected = Level.allFishesCollected;

    }
}
