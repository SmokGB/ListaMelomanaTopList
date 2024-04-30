namespace TopList
{
    public abstract class TrackBase : ITrack
    {
        public delegate void TheBestSongDelagate(object sender, EventArgs args);
        public event TheBestSongDelagate TheBestSong;
        public string Artist { get; private set; }
        public string NameSong { get; private set; }
        public string Year { get; private set; }
        public TrackBase(string artists, string song,string year)
        {
            this.Artist = artists;
            this.NameSong = song;
            this.Year = year;
        }
        public abstract void AddGrade(float grade);
        public abstract void AddGrade(string grade);
        public abstract void AddGrade(double grade);        
        public abstract void SongShowStatistics();
        public abstract Statistics GetStatistics();
    }
}
