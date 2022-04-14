using UnityEngine;
using UnityEngine.UI;

public class UIHighScore : MonoBehaviour
{
    public static Text HIGH_SCORE_TEXT { get; private set; }

    private void Awake()
    {
        HIGH_SCORE_TEXT = gameObject.GetComponent<Text>();
    }

    public static void ChangeHighScoreText(int highScore)
    {
        HIGH_SCORE_TEXT.text = $"HighScore: {highScore}";
    }
}


