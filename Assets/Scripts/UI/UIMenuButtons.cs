using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuButtons : MonoBehaviour
{
    [SerializeField] private InputField field;

    public void StartGame()
    {
        if (field.text.Length != 0)
        {
            GameManager.ApplyPlayerName(field.text);
            SceneManager.LoadScene("_Scene_0");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
