using System.Collections.Generic;

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
    private readonly List<SaveData> playersResults;

    public Results()
    {
        playersResults = new List<SaveData>();
    }

    public void SaveRecord(string name, int score)
    {
        var newRecord = new SaveData(score, name);

        foreach (var player in playersResults)
        {
            if (newRecord.PlayerName == player.PlayerName && newRecord.Record > player.Record)
            {
                playersResults.Remove(player);
                playersResults.Add(newRecord);
            }
            else
            {
                playersResults.Add(newRecord);
            }
        }
    }
}
