using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/HighScores", order = 1)]
public class HighScores : ScriptableObject
{
    public int maxScore;
    public int maxCombo;

    public int maxComboRating = 3;
    public int maxAccuracyRating = 3;
    public int maxClearingRating = 3;
}
