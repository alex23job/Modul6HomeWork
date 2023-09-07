using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConsoleApp
{
    class WorkPerson
    {
        public int ID { get; set; }
        public string DateCreate { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public string BirthDay { get; set; }
        public string BirthCity { get; set; }
        public string Position { get; set; }

        public WorkPerson() 
        {
            ID = 0;
            DateTime dt = DateTime.Now;
            DateCreate = string.Format("{0:D02}.{1:D02}.{2:D04} {3:D02}:{4:D02}", dt.Day, dt.Month, dt.Year, dt.Hour, dt.Minute);
            FullName = "";
            Age = 0;
            Height = 0;
            BirthDay = "";
            BirthCity = "";
            Position = "";
        }

        public WorkPerson(string csvStr, char sep = ';')
        {
            string[] zn = csvStr.Split(sep);
            if (zn.Length >= 8)
            {
                if (int.TryParse(zn[0], out int id))
                {
                    ID = id;
                }
                DateCreate = zn[1];
                FullName = zn[2];
                if (int.TryParse(zn[3], out int age))
                {
                    Age = age;
                }
                if (int.TryParse(zn[4], out int height))
                {
                    Height = height;
                }
                BirthDay = zn[5];
                BirthCity = zn[6];
                Position = zn[7];
            }
        }

        public WorkPerson(int id, string fn, int age, int height, string bd, string bc, string pos)
        {
            ID = id;
            DateTime dt = DateTime.Now;
            DateCreate = string.Format("{0:D02}.{1:D02}.{2:D04} {3:D02}:{4:D02}", dt.Day, dt.Month, dt.Year, dt.Hour, dt.Minute);
            FullName = fn;
            Age = age;
            Height = height;
            BirthDay = bd;
            BirthCity = bc;
            Position = pos;
        }

        public string CsvRecord(string sep = ";")
        {
            StringBuilder res = new StringBuilder(ID.ToString());
            res.Append(sep + DateCreate);
            res.Append(sep + FullName);
            res.Append(sep + Age.ToString());
            res.Append(sep + Height.ToString());
            res.Append(sep + BirthDay);
            res.Append(sep + BirthCity);
            res.Append(sep + Position);
            return res.ToString();
        }


        public string OutFormatString(string pattern)
        {
            return string.Format(pattern, ID, DateCreate, FullName, Age, Height, BirthDay, BirthCity, Position);
        }
        public override string ToString()
        {
            StringBuilder res = new StringBuilder("Сотрудник № " + ID.ToString());
            res.Append(" " + FullName);
            res.Append(" возраст: " + Age.ToString());
            res.Append(" должность: " + Position);
            return res.ToString();
        }
    }
}
