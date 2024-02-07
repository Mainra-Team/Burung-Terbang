using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePage : MonoBehaviour
{
    public TMP_Text scoreTeks;
    public TMP_Text highScoreTeks;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highScoreTeks.text = $"Highscore: {PlayerPrefs.GetInt("Highscore")}";
        }
        else
        {
            highScoreTeks.text = $"Highscore: 0";
        }
    }
    private void Update()
    {
        int score = FindObjectOfType<GameManager>().GetScore();
        scoreTeks.text = $"Score: {score}";
    }
}
