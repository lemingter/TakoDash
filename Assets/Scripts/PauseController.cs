using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject panelPause;
    public AudioSource song;

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

    public void GoToMenu()
    {
        Time.timeScale = 1;
        FindObjectOfType<GameController>().GenerateScores();
        SceneManager.LoadScene("Main Menu");
    }
}
