using UnityEngine;
using UnityEngine.UI;

public class UIHighScore : MonoBehaviour
{
    public static int HIGH_SCORE { get; private set; }

    private Text _highScore;

    private void Awake()
    {
        UIManager.OnApplePick.AddListener(ChangeHighScoreText);
        _highScore = GetComponent<Text>();
    }

    private void Start()
    {
        _highScore.text = HIGH_SCORE.ToString();
    }

    private void ChangeHighScoreText()
    {
        if (UIScore.SCORE > HIGH_SCORE)
        {
            HIGH_SCORE = UIScore.SCORE;
            _highScore.text = HIGH_SCORE.ToString();
        }
    }

    private void OnDisable()
    {
        UIManager.OnApplePick.RemoveListener(ChangeHighScoreText);
    }

}


