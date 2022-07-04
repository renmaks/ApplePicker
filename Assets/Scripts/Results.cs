using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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
    public List<SaveData> _playersResults = new List<SaveData>();
    const string filepath = @"C:\Games\ApplePicker\save.json";

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
        string json = JsonConvert.SerializeObject(_playersResults);

        File.WriteAllText(filepath, json);
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
        if (File.Exists(filepath))
        {
            var json = File.ReadAllText(filepath);
            var data = JsonConvert.DeserializeObject<List<SaveData>>(json);
            _playersResults = data;
        }
    }
}
