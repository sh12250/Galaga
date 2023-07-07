using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUi = default;
    public GameObject scoreText = default;
    public GameObject recordText = default;
    public float score = default;

    private bool isGameOver = default;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        score = 0f;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == false)
        {
            scoreText.SetText(string.Format("Score : {0}", (int)score));
            // == timeText.text = string.Format("Time : {0}", (int)surviveTime);
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GFunc.LoadScene("PlayScene");
            }
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);

        float bestScore = PlayerPrefs.GetFloat("BestScore");

        if (bestScore < score)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }

        recordText.SetText(string.Format("Best Score : {0}", (int)bestScore));

        Time.timeScale = 0f;
    }
}
