using UnityEngine;
using UnityEngine.UI;

public class YourScore : MonoBehaviour
{
    public static Text _yourScore { get; private set; }

     private void Awake()
    {
        _yourScore = GetComponent<Text>();
    }

    public static void Start(int score)
    {
        _yourScore.text = $"Your Score: {score}";
    }

}
