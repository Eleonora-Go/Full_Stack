using System;
using System.Collections.Generic;

namespace net_application
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Notes> notesList = new List<Notes>();
            notesList.Add(new Notes("Купить подароки на новый год", "проектор", new DateTime(2020, 12, 20),new DateTime(2020, 12, 25), false));
            notesList.Add(new Notes("Купить продукты на холодец", "свинина, говядина, курица ", new DateTime(2020, 12, 24), new DateTime(2020, 12, 28), false));
            notesList.Add(new Notes("Украсить дом", "повесить гирлянды, купить елку", new DateTime(2020, 12, 20), new DateTime(2020, 12, 22), true));
            string name = "";
            while (name != "4")
            {
               
                Console.WriteLine("1 Список дел");
                Console.WriteLine("2 Добавить");
                Console.WriteLine("3 Удалить");
                Console.Write("Выбирите меню: ");
                name = Console.ReadLine();

                switch (name)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("ВЕСЬ СПИСОК");
                        foreach (Notes note in notesList)
                        {
                            Console.WriteLine( notesList.IndexOf(note)+": " + "Название: " + note.name + " | Описание: " + note.notes +" |c "+note.startTime.ToShortDateString() + " до " + note.endTime.ToShortDateString() + " | Завершено: " + note.complite);
                        }
                        Console.WriteLine("Для возврата к меню нажмите любую кнопку");
                        Console.ReadKey();
                        break;
                       
                    case "2":
                        Console.Clear();
                        Console.WriteLine("ДОБАВЛЕНИЕ");
                        notesList.Add(AddNote());
                        Console.WriteLine("Для возврата к меню нажмите любую кнопку");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Если хотите удалить запись, введите номер записи");
                        int num = int.Parse(Console.ReadLine());
                        if (num < notesList.Count)
                        {

                            notesList.RemoveAt(num);
                            Console.WriteLine("Запись удалена");
                        }
                        else {
                            Console.WriteLine("Такого номера не существует");
                            
                        }
                        Console.WriteLine("Для возврата к меню нажмите любую кнопку");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Такого меню нет");
                        break;
                }

               
            }
        }

        static Notes AddNote()
        {
            Console.WriteLine("Введите название новой заметки:");
            string Name = Console.ReadLine();
            Console.WriteLine("Введите описание:");
            string Note = Console.ReadLine();
            Console.WriteLine("Начальная дата (yyyy.mm.dd):");
            string startDateStr = Console.ReadLine();
            DateTime startDate = DateTime.ParseExact(startDateStr, "yyyy.MM.dd", null);
            return new Notes(Name, Note, startDate, startDate.AddDays(1), false);

        }
    }

    public class Notes
    {
        public string name;
        public string notes;
        public bool complite;
        public DateTime startTime;
        public DateTime endTime;


        public Notes(string name, string notes, DateTime startTime, DateTime endTime, bool complite)
        {
            this.name = name;
            this.notes = notes;
            this.startTime = startTime;
            this.endTime = endTime;
            this.complite = complite;
        }
    }
}
