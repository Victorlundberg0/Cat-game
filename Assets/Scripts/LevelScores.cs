using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelScores : MonoBehaviour
{
    public TextMeshProUGUI level1;
    public TextMeshProUGUI level2;
    public TextMeshProUGUI level3;
    public TextMeshProUGUI level4;
    public TextMeshProUGUI level5;
    public TextMeshProUGUI level6;

     private void Start() {
          if (SaveSystem.LoadPlayer() != null)
        {
          LevelData data = SaveSystem.LoadPlayer();
          float[] fishes = data.allFishesCollected;
          level1.text = fishes[0].ToString();
          level2.text = fishes[1].ToString();
          level3.text = fishes[2].ToString();
          level4.text = fishes[3].ToString();
          level5.text = fishes[4].ToString();
          level6.text = fishes[5].ToString();
          
        }
    }
}
