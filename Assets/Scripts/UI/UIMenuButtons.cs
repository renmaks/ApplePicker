using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("_Scene_0");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
