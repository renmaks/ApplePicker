using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuButtons : MonoBehaviour
{
    [SerializeField] private InputField field;
    [SerializeField] private new string name;

    public void StartGame()
    {
        if (field.text.Length == 3 && !field.text.Contains(" "))
        {
            name = field.text;
            GameManager.ApplyPlayerName(name);
            SceneManager.LoadScene("_Scene_0");
        }
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
