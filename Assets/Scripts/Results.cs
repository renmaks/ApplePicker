using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public struct SaveData
{
    public int Record { get; }
    public string PlayerName { get; }

    public SaveData(int score, string name)
    {
        PlayerName = name;
        Record = score;
    }
}



public class Results
{
    private List<SaveData> _playersResults;

    public Results()
    {
        _playersResults = new List<SaveData>();
    }

    public void SaveRecord(string name, int score)
    {
        var newRecord = new SaveData(score, name);

        foreach (var player in _playersResults)
        {
            if (newRecord.PlayerName == player.PlayerName && newRecord.Record > player.Record)
            {
                _playersResults.Remove(player);
                _playersResults.Add(newRecord);
            }
            else
            {
                _playersResults.Add(newRecord);
            }
        }
    }

    public void SaveAllRecords()
    {
        string json = JsonUtility.ToJson(_playersResults);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadRecord()
    {
        foreach (var player in _playersResults)
        {
            if (player.PlayerName == GameManager.PLAYER_NAME)
            {
                GameManager.HIGHSCORE = player.Record;
            }
        }
    }

    public void LoadAllRecords()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
           string json = File.ReadAllText(path);
           Results allRecords = JsonUtility.FromJson<Results>(json);
           _playersResults = allRecords._playersResults;
        }
    }
}
