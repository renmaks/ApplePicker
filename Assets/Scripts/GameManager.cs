using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _basketPrefab;
    public static string PLAYER_NAME { get; private set; }
    public static int HIGHSCORE;
    public static bool IS_RECORD;
    public static int SCORE { get; private set; }

    private readonly int _basketsCount = 3;
    private int _score = 0;
    private Vector3 _basketPosition = Vector3.up;
    private readonly float _basketYLevel = -12f;
    private List<GameObject> _baskets;
    private Results records;

    private void Awake()
    {
        records = new();
        records.LoadAllRecords();
        records.LoadRecord();
        UIManager.OnApplePick.AddListener(ScoreChange);
        _baskets = new List<GameObject>();
    }

    private void Start()
    {
        _score = 0;
        IS_RECORD = false;
        UIScore.ChangeScoreText(_score);
        UIHighScore.ChangeHighScoreText(HIGHSCORE);

        for (int i = 0; i < _basketsCount; i++)
        {
            GameObject basket = Instantiate(_basketPrefab);
            basket.transform.position = _basketPosition * _basketYLevel;
            _baskets.Add(basket);
            basket.SetActive(false);
        }

        _baskets[_baskets.Count-1].SetActive(true);
    }

    public void AppleDestroyed()
    {
        DestroyCurrentBasket();
    }

    private void DestroyCurrentBasket()
    {
        int basketIndex = _baskets.Count - 1;
        GameObject tBasketGO = _baskets[basketIndex];
        _baskets.RemoveAt(basketIndex);

        if (_baskets.Count == 0)
        {
            SCORE = _score;
            records.SaveRecord(PLAYER_NAME, HIGHSCORE);
            SceneManager.LoadScene("_Lose_Screen");
        }
        else
        {
            _baskets[_baskets.Count - 1].transform.position = tBasketGO.transform.position;
            _baskets[_baskets.Count - 1].SetActive(true);
        }

        Destroy(tBasketGO);

        UIManager.SendBasketDestroy(_baskets.Count);
    }

    private void OnDisable()
    {
        UIManager.OnApplePick.RemoveListener(ScoreChange);
    }

    private void ScoreChange()
    {
        _score += 100;
        UIScore.ChangeScoreText(_score);
        if (_score > HIGHSCORE)
        {
            IS_RECORD = true;
            HIGHSCORE = _score;
            UIHighScore.ChangeHighScoreText(HIGHSCORE);
        }
    }

    public static void ApplyPlayerName(string name)
    {
        PLAYER_NAME = name;
    }
}
