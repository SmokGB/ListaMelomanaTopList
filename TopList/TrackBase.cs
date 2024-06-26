﻿namespace TopList
{
    public abstract class TrackBase : ITrack
    {
        public delegate void TheBestSongDelagate(object sender, EventArgs args);
        public event TheBestSongDelagate TheBestSong;

        public abstract Statistics GetStatistics();
        public abstract void AddGrade(float grade);

        public string Artist { get; private set; }
        public string NameSong { get; private set; }
        public string Year { get; private set; }
        public TrackBase(string artists, string song, string year)
        {
            this.Artist = artists;
            this.NameSong = song;
            this.Year = year;
        }

        public void SongShowStatistics()
        {
            var statistisc = GetStatistics();
            Console.Clear();
            Console.WriteLine($"Zestawienie ocen :  Wykonawca : {Artist} Utwór : {NameSong} Rok wydania:{Year}");
            Console.WriteLine($"min: {statistisc.Min}");
            Console.WriteLine($"max: {statistisc.Max}");
            Console.WriteLine($"Suma ocen : {statistisc.Sum}");
            Console.WriteLine($"Ilosc ocen : {statistisc.Count}");
            Console.WriteLine($"AVG: {statistisc.Average:n2}");
            Console.WriteLine($"Ocena : {statistisc.AverageLetter}");
            Console.ReadKey();
        }

        public void AddGrade(string grade)
        {
            switch (grade)
            {
                case "10":
                    this.AddGrade(10);
                    break;

                case "-10" or "10-":
                    this.AddGrade(9.75);
                    break;

                case "+9" or "+9":
                    this.AddGrade(9.5);
                    break;

                case "9":
                    this.AddGrade(9);
                    break;

                case "-9" or "9-":
                    this.AddGrade(8.75);
                    break;

                case "+8" or "8+":
                    this.AddGrade(8.5);
                    break;

                case "8":
                    this.AddGrade(8);
                    break;

                case "-8" or "8-":
                    this.AddGrade(7.75);
                    break;

                case "+7" or "7+":
                    this.AddGrade(7.5);
                    break;

                case "7":
                    this.AddGrade(7);
                    break;

                case "-7" or "7-":
                    this.AddGrade(6.75);
                    break;

                case "+6" or "6+":
                    this.AddGrade(6.5);
                    break;

                case "6":
                    this.AddGrade(6);
                    break;

                case "6-" or "-6":
                    this.AddGrade(5.75);
                    break;

                case "5+" or "+5":
                    this.AddGrade(5.5);
                    break;

                case "5":
                    this.AddGrade(5);
                    break;

                case "5-" or "-5":
                    this.AddGrade(4.75);
                    break;

                case "4+" or "+4":
                    this.AddGrade(4.5);
                    break;

                case "4":
                    this.AddGrade(4);
                    break;

                case "4-" or "-4":
                    this.AddGrade(3.75);
                    break;

                case "3+" or "+3":
                    this.AddGrade(3.5);
                    break;

                case "3":
                    this.AddGrade(3);
                    break;

                case "3-" or "-3":
                    this.AddGrade(2.75);
                    break;

                case "2+" or "+2":
                    this.AddGrade(2.5);
                    break;

                case "2":
                    this.AddGrade(2);
                    break;

                case "2-" or "-2":
                    this.AddGrade(1.75);
                    break;

                case "1":
                    this.AddGrade(1);
                    break;

                case "-1" or "1-":
                    this.AddGrade(0.75);
                    break;

                default:
                    if (float.TryParse(grade, out float result))
                    {
                        this.AddGrade(result);
                    }
                    else if (char.TryParse(grade, out char charResult))
                    {
                        this.AddGrade(charResult);
                    }
                    else
                    {
                        throw new Exception("Błąd konwersji na typ zmiennoprzecinkowy");
                    }
                    break;
            }
        }
        public void AddGrade(char grade)
        {
            switch (grade)
            {
                case 'A':
                case 'a':
                    this.AddGrade(10);
                    break;
                case 'B':
                case 'b':
                    this.AddGrade(8);
                    break;
                case 'C':
                case 'c':
                    this.AddGrade(6);
                    break;
                case 'D':
                case 'd':
                    this.AddGrade(4);
                    break;
                case 'E':
                case 'e':
                    this.AddGrade(2);
                    break;
                default:
                    throw new Exception("Oceny znakowe zakres [Aa] - [Ee]");
                    break;
            }
        }
        public void AddGrade(double grade)
        {
            float floatValue = (float)grade;
            this.AddGrade(floatValue);
        }
    }
}