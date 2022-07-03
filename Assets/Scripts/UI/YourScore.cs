using UnityEngine;
using UnityEngine.UI;

public class YourScore : MonoBehaviour
{
    public static Text UrScore { get; private set; }

     private void Awake()
    {
        UrScore = GetComponent<Text>();
    }

    public static void Start(int score)
    {
        UrScore.text = $"Your Score: {score}";
    }

}
