using UnityEngine;
using UnityEngine.UI;

public class YourScore : MonoBehaviour
{
    public static Text yourScore;

     void Start()
    {
        GameObject go = this.gameObject;
        yourScore = go.GetComponent<Text>();
        yourScore.text = "Your Score: " + Basket.scoreGT.text;
    }

}
