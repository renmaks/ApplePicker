using UnityEngine;
using UnityEngine.UI;

public class YourScore : MonoBehaviour
{
    private Text _urScore;

     private void Awake()
    {
        _urScore = GetComponent<Text>();
    }

    private void Start()
    {
        _urScore.text = $"Your Score: {GameManager.SCORE}";
    }
}
