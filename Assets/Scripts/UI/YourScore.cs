using UnityEngine;
using UnityEngine.UI;

public class YourScore : MonoBehaviour
{
    private Text _yourScore;

     private void Awake()
    {
        _yourScore = GetComponent<Text>();
    }

    private void Start()
    {
        _yourScore.text = "Your Score: " + UIScore.SCORE;
    }

}
