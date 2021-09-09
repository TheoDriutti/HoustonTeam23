using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverPanel;
    public ShipHealth shipHealth;

    public bool isPlayerDead = false;

    void Update()
    {
        if (shipHealth.currentHealth == 0 && isPlayerDead == false)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
            isPlayerDead = true;
        }
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LD_Gameplay");
    }
}
