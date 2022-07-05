using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

[System.Serializable]
public struct SaveData
{
    [JsonProperty("HighScore")]
    public int Record { get; }

    [JsonProperty("PlayerName")]
    public string PlayerName { get; }

    [JsonConstructor]
    public SaveData([JsonProperty("HighScore")] int score, [JsonProperty("PlayerName")] string name)
    {
        PlayerName = name;
        Record = score;
    }
}



public class Results
{
    public List<SaveData> _playersResults;
    const string filepath = @"C:\Games\ApplePicker\save.json";

    private bool _isRewrite = false;

    public Results()
    {
        _playersResults = new();
    }

    public void SaveRecord(string name, int score)
    {
        var newRecord = new SaveData(score, name);

        if (_playersResults.Count != 0)
        {
            foreach (var player in _playersResults)
            {
                if (newRecord.PlayerName == player.PlayerName && newRecord.Record > player.Record)
                {
                    _playersResults.Remove(player);
                    _playersResults.Add(newRecord);
                    _isRewrite = true;
                }
            }
            if (_isRewrite == false)
            {
                _playersResults.Add(newRecord);
            }
        }
        else
        {
            _playersResults.Add(newRecord);
        }

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
            _playersResults.AddRange(data);
        }
    }
}
