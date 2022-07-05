using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuButtons : MonoBehaviour
{
    public void StartGame()
    {
            SceneManager.LoadScene("_Scene_0");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("_Main_Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
