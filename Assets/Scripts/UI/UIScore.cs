using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public static Text SCORE_TEXT { get; private set; }

    private void Awake()
    {
        SCORE_TEXT = gameObject.GetComponent<Text>();
    }

    public static void ChangeScoreText(int score)
    {
        SCORE_TEXT.text = score.ToString();
    }
}
