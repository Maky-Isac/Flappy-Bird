using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    private static int playerScore = 0;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        playerScore = 0;
    }

    private void Update()
    {
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public static void AddScore()
    {
        playerScore++;
    }
}
