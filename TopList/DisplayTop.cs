namespace TopList
{
    public static class DisplayTop
    {
        private static List<string> songList = new List<string>();
        public static void SongShow()
        {
            Console.Clear();
            ReadData();
            if (songList.Count == 0)
            {
                Console.WriteLine("Nie masz zapisanego żadnego utworu\n");
            }
            else
            {
                ShowData();
            }
        }

        private static void ShowData()
        {
            Console.WriteLine("============TwojaTopLista==========\n");
            int counter = 1;
            foreach (var song in songList)
            {
                Console.WriteLine(counter + ". " + song);
                counter++;
            }
        }

        private static void ReadData()
        {
            List<string> tempList = new List<string>();
            try
            {
                using (var topReader = File.OpenText("TopList.txt"))
                {
                    var line = topReader.ReadLine();
                    while (line != null)
                    {
                        tempList.Add(line.Substring(20));
                        line = topReader.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Brak pliku \"TopList.txt --> " + e.Message);
            }
            finally
            {
                songList = tempList.Distinct().ToList();
                songList.Sort();
            }
        }
    }
}


