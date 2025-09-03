namespace MoodSync.Models
{
    public class MoodData
    {
        public string Mood { get; set; }
        public string Location { get; set; }
        public DateTime Timestamp { get; set; } 
        public List<string> Recommendations { get; set; }
    }
}

