using static TopList.TrackBase;

namespace TopList
{
    public interface ITrack
    {
        string Artist { get; }
        string NameSong { get; } 
        void AddGrade(float grade);   
        void AddGrade(string grade);
        void AddGrade(double grade);
        Statistics GetStatistics();
        public event  TheBestSongDelagate TheBestSong;   
    }
}