using System.Collections.Generic;
using System;

namespace Ejednevnik 
{
    class Program
    {
        static public int CountNote(ConsoleKeyInfo key, int date)
        {
            if (key.Key == ConsoleKey.LeftArrow)
            {
                if (date == 1 || date == 0) date = 30;
                date--;
            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                if (date == 29) date = -1;
                date++;
            }
            return date;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Для просмотра заметок нажмите любую клавишу");

            List<Note> notes = new List<Note>();
            for (int i = 1; i < 31; i++)
            {
                Note nt = new Note(i);
                notes.Add(nt);
            }

            notes[2].text = "  Купить хлеб\n  Оплатить подписку\n  Вынести мусор";
            notes[0].text = "  Отправить практическую\n  почитать";
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            int date = 0;
            int posArrow = 1;
            while (true)
            {
                keyInfo = Console.ReadKey();
                date = CountNote(keyInfo, date);
                int lines = notes[date].GetNumOfLines();

                if (keyInfo.Key == ConsoleKey.DownArrow && posArrow != lines)
                {
                    posArrow++;
                }

                if (keyInfo.Key == ConsoleKey.UpArrow && posArrow != 1)
                {
                    posArrow--;
                }


                Console.Clear();

                Console.WriteLine(notes[date]);
                Console.SetCursorPosition(0, posArrow);
                Console.WriteLine("->");


            }
        }
    }
    public class DopNote
    {
        public string text { get; set; }

        public string dopText;
    }
    class Note
    {
        public string text
        {
            get { return dp.text; }
            set { dp.text = value; }
        }
        public DopNote dp = new DopNote();
        public int date { get; set; }
        public Note(int date, string text)
        {
            this.date = date;
            dp.text = text;
        }
        public Note(int date)
        {
            this.date = date;
        }
        public Note(int date, string text, string dopText)
        {
            this.date = date;
            dp.text = text;
            dp.dopText = dopText;
        }

        public int GetNumOfLines()
        {
            int NumOfLines = 1;
            if (text != null)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '\n')
                    {
                        NumOfLines++;
                    }
                }
            }


            return NumOfLines;
        }
        public override string ToString()
        {
            return $"Дата {date}.10.22\n{text}";
        }
    }
}