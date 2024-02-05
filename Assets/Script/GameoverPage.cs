using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverPage : MonoBehaviour
{
    public TMP_Text scoreTeks;
    public Button playBTN;
    private void Start()
    {
        int score = Funcs.GetScore.Invoke();
        scoreTeks.text = $"Score : {score}";

        playBTN.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
