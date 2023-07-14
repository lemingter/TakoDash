using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int score;
    public int combo;
    private int pointsToGive = 10;
    public int maxCombo;

    public Text scoreText;
    public Text comboText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        combo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        comboText.text = "Combo: " + combo;
    }

    public void increaseScore()
    {
        score += pointsToGive * (combo++ / 10 + 1);
    }

    public void breakCombo()
    {
        if (combo > maxCombo)
            maxCombo = combo;

        combo = 0;
    }
}
