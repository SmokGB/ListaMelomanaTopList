namespace TopList
{
    public class SongRatingFile : TrackBase
    {
        private string? fileName = null;
        private List<float> songGrades = new List<float>();
        public delegate void SongRatingDelegate(object Event, EventArgs args);
        public event SongRatingDelegate TheBestSong;
        public SongRatingFile(string artists, string song, string year) : base(artists, song, year)
        {
            fileName = artists + "_" + song + "_" + year + ".txt";
        }
        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 10)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(grade);
                }

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
                throw new Exception("Zakres punktów [0-10]");
            }
        }
        public override Statistics GetStatistics()
        {
            Statistics songStatistics = new Statistics();
            var gradesFromFile = this.ReadSongGradesFromFile();

            foreach (var grade in this.songGrades)
            {
                songStatistics.AddGrade(grade);
            }
            return songStatistics;
        }
        private List<float> ReadSongGradesFromFile()
        {
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        songGrades.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return songGrades;
        }
    }
}