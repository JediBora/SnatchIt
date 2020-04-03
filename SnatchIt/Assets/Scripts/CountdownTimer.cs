using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float currentTime;

    public float startingTime;

    public Text countdownText;

    public static bool GameIsOver = false;

    public GameObject gameOverMenuUI;


    private void Awake()
    {
        currentTime = startingTime;

        Time.timeScale = 1f;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        countdownText.text = currentTime.ToString ("0");

        if (currentTime <= 0)
        {
            currentTime = 0;

            gameOverMenuUI.SetActive(true);

            Time.timeScale = 0f;

            GameIsOver = true;
        }

        if (currentTime >= 10f) { countdownText.color = Color.green; }

        if (currentTime < 10f) { countdownText.color = Color.red; }
    }
}

