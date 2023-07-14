using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject cookie;
    public GameObject[] spawnPoints;
    public HighScores highScore;
    private ScoreController currentScore;
    private PauseController pauseController;

    private float spawnTimer;
    private float timeToSpawn;
    public float bpm;
    public float songDuration;
    private float maxSongDuration;
    private float timerAfterSong;
    private int cookiesGenerated;
    private int cookiesHit;

    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = 1 / (bpm / 60);
        spawnTimer = timeToSpawn;
        timerAfterSong = 3;

        maxSongDuration = songDuration;
        cookiesGenerated = 0;

        currentScore = FindObjectOfType<ScoreController>();
        pauseController = FindObjectOfType<PauseController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(songDuration > 0)
        {
            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
            }
            else
            {
                if (Random.Range(0, 2) == 0)
                {
                    spawnTimer = timeToSpawn;
                }
                else
                {
                    spawnTimer = timeToSpawn / 2;
                }
                Instantiate(cookie, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, new Quaternion());
                cookiesGenerated++;
            }

            songDuration -= Time.deltaTime;
        }
        else
        {
            if(timerAfterSong > 0)
            {
                timerAfterSong -= Time.deltaTime;
            }
            else
            {
                if(currentScore.score > highScore.maxScore)
                {
                    highScore.maxScore = currentScore.score;
                }
                if(currentScore.maxCombo > highScore.maxCombo)
                {
                    highScore.maxCombo = currentScore.maxCombo > currentScore.combo ? currentScore.maxCombo : currentScore.combo;
                }

                GenerateScores();
                
                pauseController.EndGame();
            }
        }
    }

    public void GenerateScores()
    {
        int comboRating;
        int accuracyRating;
        int clearingRating;

        float aux = (float)currentScore.maxCombo / cookiesGenerated;

        if (aux >= 0.95)
        {
            comboRating = 0;
        }
        else if (aux < 0.95 && aux >= 0.90)
        {
            comboRating = 1;
        }
        else if (aux < 0.90 && aux >= 0.80)
        {
            comboRating = 2;
        }
        else if (aux < 0.80 && aux >= 0.70)
        {
            comboRating = 3;
        }
        else if (aux < 0.70 && aux >= 0.60)
        {
            comboRating = 4;
        }
        else if (aux < 0.60 && aux >= 0.50)
        {
            comboRating = 5;
        }
        else 
        {
            comboRating = 6;
        }

        aux = (float)cookiesHit / cookiesGenerated;
        
        if (aux >= 0.95)
        {
            accuracyRating = 0;
        }
        else if (aux < 0.95 && aux >= 0.90)
        {
            accuracyRating = 1;
        }
        else if (aux < 0.90 && aux >= 0.80)
        {
            accuracyRating = 2;
        }
        else if (aux < 0.80 && aux >= 0.70)
        {
            accuracyRating = 3;
        }
        else if (aux < 0.70 && aux >= 0.60)
        {
            accuracyRating = 4;
        }
        else if (aux < 0.60 && aux >= 0.50)
        {
            accuracyRating = 5;
        }
        else 
        {
            accuracyRating = 6;
        }

        aux = 1 - (songDuration / maxSongDuration);
        
        if (aux >= 0.95)
        {
            clearingRating = 0;
        }
        else if (aux < 0.95 && aux >= 0.80)
        {
            clearingRating = 1;
        }
        else if (aux < 0.80 && aux >= 0.50)
        {
            clearingRating = 2;
        }
        else if (aux < 0.80 && aux >= 0.70)
        {
            clearingRating = 3;
        }
        else if (aux < 0.70 && aux >= 0.60)
        {
            clearingRating = 4;
        }
        else if (aux < 0.60 && aux >= 0.50)
        {
            clearingRating = 5;
        }
        else 
        {
            clearingRating = 6;
        }

        if (highScore.maxComboRating > comboRating)
        {
            highScore.maxComboRating = comboRating;
        }

        if (highScore.maxClearingRating > clearingRating)
        {
            highScore.maxClearingRating = clearingRating;
        }

        if (highScore.maxAccuracyRating > accuracyRating)
        {
            highScore.maxAccuracyRating = accuracyRating;
        }
    }

    public void HitCookie()
    {
        cookiesHit++;
    }
}
