namespace TopList
{
    public class SongRating : TrackBase
    {
        private List<float> grades = new List<float>();
        public delegate void SongRatingDelegate(object Event, EventArgs args);
        public event SongRatingDelegate TheBestSong;
        public SongRating(string artists, string song, string year) : base(artists, song, year)
        {
        }
        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 10)
            {
                this.grades.Add(grade);
                if (grade > 9)
                {
                    if (TheBestSong != null)
                    {
                        TheBestSong(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new Exception("Dozwolone wartości [0-10]");
            }
        }
        public override Statistics GetStatistics()
        {
            Statistics statistics = new Statistics();
            foreach (var grade in this.grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }
    }
}
