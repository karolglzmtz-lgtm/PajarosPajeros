using UnityEngine;
using TMPro; // 👈 IMPORTANTE

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TMP_Text scoreText; // 👈 cambiado

    void Awake()
    {
        instance = this;
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Puntos: " + score;
    }
}
