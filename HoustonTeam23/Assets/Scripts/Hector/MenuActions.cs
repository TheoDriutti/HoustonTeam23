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
        SceneManager.LoadScene("Gameplay");
    }

    public void Tuto()
    {
        panelTuto.SetActive(true);
    }

    public void QuitTuto()
    {
        panelTuto.SetActive(false);
    }

}
