using System;
using System.Collections.Generic;
using System.IO;
using MoodSync.Enums;
using MoodSync.Models;
using Newtonsoft.Json;

public class MoodService
{
    private readonly string _filePath = "moodData.json";

    public List<MoodData> ReadMoodData()
    {
        if (!File.Exists(_filePath))
        {
            return new List<MoodData>();
        }

        var jsonData = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<List<MoodData>>(jsonData) ?? new List<MoodData>();
    }

    public void SaveMoodData(MoodData newMood)
    {
        var moodDataList = ReadMoodData();
        moodDataList.Add(newMood); 
        var updatedData = JsonConvert.SerializeObject(moodDataList, Formatting.Indented);
        File.WriteAllText(_filePath, updatedData);
    }

    public void SaveMoodAndRecommendations(Mood selectedMood, string location, List<string> recommendations)
    {
        var newMood = new MoodData
        {
            Mood = selectedMood.ToString(),
            Location = location,
           // Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
            Recommendations = recommendations
        };

        SaveMoodData(newMood);
    }
}
