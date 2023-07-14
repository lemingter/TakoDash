using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CardController : MonoBehaviour
{
    public TMP_Text highScore;
    public TMP_Text highCombo;

    public HighScores scores;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "Highest score: " + scores.maxScore;
        highCombo.text = "Max Combo: " + scores.maxCombo;
    }

    public void SceneLoad(string sceneToLoad) {
        SceneManager.LoadScene(sceneToLoad);
    }
}
