using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DbConsoleApp
{
    class Program
    {
        static string fileName = "data.csv";
        static void Main(string[] args)
        {
            string strInput = "";
            Console.WriteLine("Справочник\"Сотрудник\"");
            while (strInput != "0")
            {
                Console.WriteLine("\nДля вывода справочника нажмите < 1 >");
                Console.WriteLine("Для ввода информации о новом сотруднике нажмите < 2 >");
                Console.WriteLine("Для завершения нажмите < 0 >");
                strInput = Console.ReadLine();
                switch(strInput)
                {
                    case "0": 
                        break;
                    case "1":
                        PrintList();
                        break;
                    case "2":
                        InputInfo();
                        break;
                    default:
                        Console.WriteLine("Ошибка при вводе команды выбора действия => " + strInput);
                        break;
                }
            }
        }

        static void PrintList()
        {
            string[] records = GetAllRecords(fileName);
            if (records != null)
            {
                string outPatern = "| {0, -3} | {1, -16} | {2, -30} | {3, -4} | {4, -4} | {5, 10} | {6, -20} |";
                if (records.Length > 0)
                {
                    Console.WriteLine("\nСписок сотрудников\n");
                    Console.WriteLine(outPatern, "ID", "Запись создана", "Ф. И. О.", "Возр", "Рост", "День рожд.", "Город рождения");
                    foreach(string rec in records)
                    {
                        WorkPerson wp = new WorkPerson(rec, '#');
                        Console.WriteLine(wp.OutFormatString(outPatern));
                    }
                }
            }
        }

        static void InputInfo()
        {
            string[] records = GetAllRecords(fileName);
            WorkPerson wp = new WorkPerson();
            wp.ID = (records == null) ? 1 : records.Length + 1;

            Console.WriteLine("\nВвод данных нового сотрудника : \n");
            Console.WriteLine("Введите фамилию, имя, отчество сотрудника (пример : Иванов Иван Иванович)");
            wp.FullName = Console.ReadLine();
            Console.WriteLine("Введите возраст сотрудника :");
            string strAge = Console.ReadLine();
            if (int.TryParse(strAge, out int age))
            {
                wp.Age = age;
            }
            Console.WriteLine("Введите рост сотрудника :");
            string strHeight = Console.ReadLine();
            if (int.TryParse(strHeight, out int h))
            {
                wp.Height = h;
            }
            Console.WriteLine("Введите дату рождения сотрудника (пример : 01.01.1970)");
            wp.BirthDay = Console.ReadLine();
            Console.WriteLine("Введите место рождения сотрудника (пример : город Тула)");
            wp.BirthCity = Console.ReadLine();
            Console.WriteLine("Введите должность сотрудника (пример : стажёр)");
            wp.Position = Console.ReadLine();

            if (records == null)
            {
                records = new string[1];
                records[0] = wp.CsvRecord("#");
            }
            else
            {
                string[] tmp = new string[records.Length + 1];
                for (int i = 0; i < records.Length; i++)
                {
                    tmp[i] = records[i];
                }
                tmp[records.Length] = wp.CsvRecord("#");
                records = tmp; 
            }
            SaveAllRecords(fileName, records);
        }

        static string[] GetAllRecords(string fileName)
        {
            if (File.Exists(fileName))
            {
                return File.ReadAllLines(fileName);
            }
            return null;
        }

        static void SaveAllRecords(string fileName, string[] records)
        {
            File.WriteAllLines(fileName, records);
        }
    }
}
