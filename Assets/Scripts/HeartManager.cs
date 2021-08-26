using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeartManager : MonoBehaviour
{
    public static HeartManager instance;
    public TextMeshProUGUI text;
    int score = 3;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        }
    }

    public void RemoveHeart(int heartValue){
        score -= heartValue;
        text.text = score.ToString();
        if(score==0) {
            FindObjectOfType<GameManager>().EndGame();
        }
        
    }
    public void AddHeart(int heartValue){
        score += heartValue;
        text.text = score.ToString();
    }

}
