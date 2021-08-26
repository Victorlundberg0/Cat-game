using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChestManager : MonoBehaviour
{
    public static ChestManager instance;
    public TextMeshProUGUI text;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        }
    }

    public void AddChest(int ChestValue){
        score += ChestValue;
        text.text = score.ToString();
        if (score == 3) {
            FindObjectOfType<GameManager>().GameDone();
        }
    }
}
