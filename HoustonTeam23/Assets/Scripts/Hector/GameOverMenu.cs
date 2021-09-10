using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverPanel;
    public ShipHealth shipHealth;

    public bool isPlayerDead = false;

    public Text scoreText;

    void Update()
    {
        if (shipHealth.currentHealth == 0 && isPlayerDead == false)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        isPlayerDead = true;
        scoreText.text = "" + (int)ScoreCounter.instance.score;
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
