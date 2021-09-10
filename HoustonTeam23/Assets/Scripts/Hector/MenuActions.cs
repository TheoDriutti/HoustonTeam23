using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public GameObject panelTuto;

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Tuto()
    {
        Time.timeScale = 1;
        panelTuto.SetActive(true);
    }

    public void QuitTuto()
    {
        Time.timeScale = 0;
        panelTuto.SetActive(false);
    }

}
