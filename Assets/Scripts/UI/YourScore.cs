using UnityEngine;
using UnityEngine.UI;

public class YourScore : MonoBehaviour
{
    public Text UrScore { get; private set; }

     private void Awake()
    {
        UrScore = GetComponent<Text>();
    }

    public void Start()
    {
        UrScore.text = $"Your Score: {GameManager.SCORE}";
    }

}
