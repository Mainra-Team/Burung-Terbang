using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject pipe;
    public float timer = 1.5f;
    public int Score;

    public GameObject gameoverPage;
    public GameObject gamePage;
    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Start()
    {
        StartCoroutine(SpawnPipe());
    }
    private void OnEnable()
    {
        Actions.OnGameOver += GameOver;
        Actions.OnScored += (value) => { Score += value; };
        Funcs.GetScore += GetScore;
    }


    private void OnDisable()
    {
        Actions.OnGameOver -= GameOver;
        Actions.OnScored -= (value) => { Score += value; };
        Funcs.GetScore -= GetScore;
    }
    private int GetScore()
    {
        return Score;
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        if (!PlayerPrefs.HasKey("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", Score);
        }
        else
        {
            if (PlayerPrefs.GetInt("Highscore") < Score)
            {
                PlayerPrefs.SetInt("Highscore",Score);
            }
        }
        gamePage.SetActive(false);
        gameoverPage.SetActive(true);
    }

    private IEnumerator SpawnPipe()
    {
        while (true)
        {
            GameObject go = Instantiate(pipe, new Vector3(5, Random.Range(-1.34f, 2.46f), 0), Quaternion.identity);
            Destroy(go,10);
            yield return new WaitForSeconds(timer);
        }
    }
}
