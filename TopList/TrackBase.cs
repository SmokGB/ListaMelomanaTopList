namespace TopList
{
    public abstract class TrackBase : ITrack
    {
        

        public delegate void TheBestSongDelagate (object sender, EventArgs args);
        public event TheBestSongDelagate TheBestSong;

        public  string Artist { get ; private set ; }

        public string NameSong { get; private set; }
        //public float Points { get; private set; }
     
        public TrackBase(string artists, string song)
        {
            this.Artist = artists;
            this.NameSong = song;
        }


        public abstract void AddGrade(float grade);
        public abstract void AddGrade(string grade);
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
        public abstract void SongShowStatistics();
      
    }
}
