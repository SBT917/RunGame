using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    int score;

    void Awake()
    {
        TryGetComponent(out scoreText);
        Notes.onNotesBreak += AddScore;
    }

    void AddScore(int score)
    {
        this.score += score;
        scoreText.text = this.score.ToString("000000");
    }
}
