using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _basketPrefab;

    public static readonly int BASKETS_COUNT = 3;
    public static string PLAYER_NAME { get; private set; }
    public static int HIGHSCORE;
    public static bool isRecord;
    public static int SCORE { get; private set; }

    private int _score = 0;
    private Vector3 _basketPosition = Vector3.up;
    private readonly float _basketYLevel = -12f;
    private List<GameObject> _baskets;
    readonly Results records = new();

    private void Awake()
    {
        records.LoadAllRecords();
        records.LoadRecord();
        UIManager.OnApplePick.AddListener(ScoreChange);
        _baskets = new List<GameObject>();
    }

    private void Start()
    {
        _score = 0;
        isRecord = false;
        UIScore.ChangeScoreText(_score);
        UIHighScore.ChangeHighScoreText(HIGHSCORE);

        for (int i = 0; i < BASKETS_COUNT; i++)
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

    public void EnemyAppleDestroyed()
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
            isRecord = true;
            HIGHSCORE = _score;
            UIHighScore.ChangeHighScoreText(HIGHSCORE);
        }
    }

    public static void ApplyPlayerName(string name)
    {
        PLAYER_NAME = name;
    }

    //[System.Serializable]
    //public struct SaveData
    //{
    //    public int Record;
    //    public string PlayerName;

    //    public SaveData(int score, string name)
    //    {
    //        PlayerName = name;
    //        Record = score;
    //    }
    //}

    //public void SaveRecord()
    //{
    //    SaveData data = new()
    //    {
    //        Record = _highScore,
    //        PlayerName = PLAYER_NAME
    //    };

    //    string json = JsonUtility.ToJson(data);

    //    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    //}

    //public void LoadRecord()
    //{
    //    string path = Application.persistentDataPath + "/savefile.json";
    //    if (File.Exists(path))
    //    {
    //        string json = File.ReadAllText(path);
    //        SaveData data = JsonUtility.FromJson<SaveData>(json);

    //        _highScore = data.Record;
    //        PLAYER_NAME = data.PlayerName;
    //    }
    //}

}
