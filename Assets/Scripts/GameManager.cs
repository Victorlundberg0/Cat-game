using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;//to only end game once.
    public float restartDelay = 1f;//time to delay when restarting.
    public GameOverScreen GameOverScreen;//instance of the game over text.
    public FinishedScreen FinishedScreen;//inscance of the finished message.

    //variables to save
    public float[] allFishesCollected;
    public float fishesCollected;
    public int currentLevel;

    //gets called when player gets out of bounds or looses all lives.
    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            //shows the game over message.
            GameOverScreen.Setup();
            //Restart game after some delay;
            Invoke("Restart", restartDelay);
        }
    }
    //reloads the scene when player looses.
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //delays the level clear message so the chest is opened.
    public void GameDone()
    {
        Invoke("ShowScore", 0.5f);
    }
    //shows the level clear message and continue button.
    public void ShowScore()
    {
        //the first time it runs
        if (SaveSystem.LoadPlayer() == null)
        {
            allFishesCollected = new float[6];
            fishesCollected = GameObject.FindWithTag("manager").GetComponent<ScoreManager>().score;
            currentLevel = SceneManager.GetActiveScene().buildIndex - 2;
            allFishesCollected[currentLevel] = fishesCollected;
            SaveSystem.SavePlayer(this);
        }
        else
        {
            //save data here before message
            LevelData data = SaveSystem.LoadPlayer();
            allFishesCollected = data.allFishesCollected;
            //gets the number of fishes.
            fishesCollected = GameObject.FindWithTag("manager").GetComponent<ScoreManager>().score;
            //gets the current level.
            currentLevel = SceneManager.GetActiveScene().buildIndex - 2;
            //checks if the new value is higher than the previous
            if (allFishesCollected[currentLevel] < fishesCollected)
            {
                allFishesCollected[currentLevel] = fishesCollected;
                SaveSystem.SavePlayer(this);
            }

        }


        // freezes everything and shows message
        Time.timeScale = 0f;
        FinishedScreen.Setup();
    }

}
