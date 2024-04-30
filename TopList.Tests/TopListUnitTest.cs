namespace TopList.Tests
{
    public class TopListUnitTest
    {
        [Test]
        public void CheckLetterValueGetStatisticMethod()
        {
            //arrange
            var track = new SongRating ("Abba", "Waterloo", "1974");
            
            track.AddGrade('A');
            track.AddGrade('C');
            track.AddGrade("10");

            //act
            Statistics usersummary = track.GetStatistics();

            //assert
            Assert.AreEqual('B', usersummary.AverageLetter);

        }
 
        [Test]
        public void CheckSongRatingConstructorMethod()
        {
            //arrange
            var singer = "Abba";
            var song = "Waterloo";
            var year = "1974";

            //act       
            var track = new SongRating("Abba", "Waterloo", "1974");

            //assert
            Assert.AreEqual(singer,track.Artist);
            Assert.AreEqual(song, track.NameSong);
            Assert.AreEqual(year, track.Year);
        }
    }
}