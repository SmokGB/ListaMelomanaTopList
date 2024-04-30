namespace TopList
{

    public static class Menu
    {
        static string[] optionsMenu = { "Wprowadź i oceń utwor", "Wprowadź i oceń utwor [opcja z zapisem ocen do pliku]", "Wyswietl Toplistę", "Wyczyść TopListę", "Wyjście z programu" };
        static int activePositionMenu = 0;
        private const string TopList = "TopList.txt";
        static private string artist, track, publicationYear;
        public static void StartMenu()
        {
            Console.CursorVisible = false;
            while (true)
            {
                ShowMenu();
                ChooseMenu();
                RunOption();
            }
        }
        private static void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.WriteLine(" ------- Notatnik Melomana ------- ");
            Console.SetCursorPosition(0, 2);
            for (int i = 0; i < optionsMenu.Length; i++)
            {
                if (i == activePositionMenu)
                {

                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("{0,-55}", optionsMenu[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(optionsMenu[i]);
                }
            }
        }
        private static void RunOption()
        {
            switch (activePositionMenu)
            {
                case 0:
                    InstertData();
                    WriteToMemory();
                    break;

                case 1:
                    InstertData();
                    WriteToFile();
                    break;

                case 2:
                    DisplayTop.SongShow();
                    Console.ReadKey();
                    ShowMenu();
                    break;

                case 3:
                    CleanTopList();
                    ShowMenu();
                    break;

                case 4:
                    Console.WriteLine("\n==========KONIEC PRACY===========");
                    System.Environment.Exit(0);
                    break;
            }
        }
        private static void ChooseMenu()
        {
            do
            {
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        activePositionMenu = (activePositionMenu > 0) ? activePositionMenu - 1 : optionsMenu.Length - 1;
                        ShowMenu();
                        break;

                    case ConsoleKey.DownArrow:
                        activePositionMenu = (activePositionMenu + 1) % optionsMenu.Length;
                        ShowMenu();
                        break;

                    case ConsoleKey.Escape:
                        activePositionMenu = optionsMenu.Length - 1;
                        RunOption();
                        break;

                    case ConsoleKey.Enter:
                        RunOption();
                        break;

                    default:
                        ShowMenu();
                        break;
                }
            } while (true);
        }
        private static bool CheckYear(string year)
        {
            if (int.TryParse(year, out int result))
            {
                if (year.Length != 4 || result < 0 || result > DateTime.Now.Year)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        private static void InstertData()
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(0, 8);
            GradeDescription();
            Console.WriteLine("Wprowadz nazwe artysty");
            artist = Console.ReadLine();
            Console.WriteLine("Wprowadz tutuł utworu");
            track = Console.ReadLine();
            Console.WriteLine("Wprowadz rok wydania utworu");
            publicationYear = Console.ReadLine();
            var yearIsOK = CheckYear(publicationYear);
            if (string.IsNullOrEmpty(artist) || string.IsNullOrEmpty(track) || string.IsNullOrEmpty(publicationYear) || yearIsOK == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (!yearIsOK && !string.IsNullOrEmpty(artist) && !string.IsNullOrEmpty(track))
                {
                    Console.WriteLine("Błedny format roku [yyyy] lub jego wartość\nWciśnij dowolny klawisz");
                }
                else
                 if (yearIsOK && (string.IsNullOrEmpty(artist) || string.IsNullOrEmpty(track)))
                {
                    Console.WriteLine("Dane artysta/utwór nie mogą być puste\nWciśnij dowolny klawisz");
                }
                else
                {
                    Console.WriteLine("Dane nie mogą być puste\nWciśnij dowolny klawisz");
                }
                Console.ReadKey();
                StartMenu();
            }
        }
        private static void GradeDescription()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"Skala ocen utworu : [1-10] ,[Aa] - [Ee], dla danych cyfrowych program uwzględnia znaki +\-");
            Console.WriteLine("Ocena powyżej 9 - utwór dodawany jest to TopListy\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void WriteToMemory()
        {
            var insertedTrack = new SongRating(artist, track, publicationYear);
            insertedTrack.TheBestSong += ILikeIt;
            insertedTrack.TheBestSong += CreateTopList;
            RateTheSong(insertedTrack);
            ShowMenu();
        }

        private static void RateTheSong(SongRating track)
        {
            while (true)
            {
                Console.WriteLine($"Oceń utwór --> {track.NameSong}                                      [q  wyjscie]");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                else
                {
                    try
                    {
                        track.AddGrade(input);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Exception : {e.Message}");
                    }
                }
            }
            track.SongShowStatistics();
            Console.Clear();
        }
        private static void WriteToFile()
        {
            var insertedTrack = new SongRatingFile(artist, track, publicationYear);
            insertedTrack.TheBestSongFile += ILikeIt;
            insertedTrack.TheBestSongFile += CreateTopList;
            RateTheSong(insertedTrack);
            ShowMenu();
        }
        private static void ILikeIt(object sender, EventArgs args)
        {
            Console.WriteLine("\nOj, bradzo Lubisz ten utwór !!!");
        }
        private static void CreateTopList(object sender, EventArgs args)
        {
            using (var writer = File.AppendText(TopList))
            {
                Console.WriteLine($"Odnotowano w pliku {TopList} informacje o kwalifikacji utworu do Twojej TopListy\n");
                writer.WriteLine($"{DateTime.Now}\t{artist}-{track},{publicationYear}");
            }
        }
        private static void CleanTopList()
        {
            File.WriteAllText(TopList, string.Empty);
        }
    }
}

