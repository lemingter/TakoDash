using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public GameObject panelPause;
    public GameObject panelEnd;
    public AudioSource song;

    public Image accuracySprite;
    public Image comboSprite;
    public Image clearingSprite;

    public Sprite[] scoreSprites;

    public HighScores highScores;

    public void PauseGame() {
        Time.timeScale = 0;
        panelPause.SetActive(true);
        song.Pause();
    }
    
    public void UnPauseGame() {
        Time.timeScale = 1;
        panelPause.SetActive(false);
        song.Play();
    }

    public void EndGame()
    {
        FindObjectOfType<GameController>().GenerateScores();

        accuracySprite.sprite = scoreSprites[highScores.maxAccuracyRating];
        comboSprite.sprite = scoreSprites[highScores.maxComboRating];
        clearingSprite.sprite = scoreSprites[highScores.maxClearingRating];
        
        panelEnd.SetActive(true);
        panelPause.SetActive(false);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
