using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public static int SCORE { get; private set; } = 0;

    private Text _score;

    private void Awake()
    {
        UIManager.OnApplePick.AddListener(ChangeScoreText);
        _score = gameObject.GetComponent<Text>();
    }

    private void Start()
    {
        SCORE = 0;
        _score.text = "0";
    }

    private void ChangeScoreText()
    {
        SCORE += 100;
        _score.text = SCORE.ToString();
    }

    private void OnDisable()
    {
        UIManager.OnApplePick.RemoveListener(ChangeScoreText);
    }
}
