using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public TMP_Text highScore;
    public TMP_Text highCombo;

    public Image accuracyRating;
    public Image comboRating;
    public Image clearingRating;

    public HighScores scores;

    public Sprite[] ratingSprites;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "Highest score: " + scores.maxScore;
        highCombo.text = "Max Combo: " + scores.maxCombo;

        accuracyRating.sprite = ratingSprites[scores.maxAccuracyRating];
        comboRating.sprite = ratingSprites[scores.maxComboRating];
        clearingRating.sprite = ratingSprites[scores.maxClearingRating];
    }

    public void SceneLoad(string sceneToLoad) {
        SceneManager.LoadScene(sceneToLoad);
    }
}
