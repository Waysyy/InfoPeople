using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace InfoPeople
{
    [Serializable]
    public class Info
    {
        public List<People> PeopleList { get; set; } = new List<People>();

    }

    public class People
    {
        public string surname { get; set;}

        public uint age { get; set; }

        public string city { get; set; }
        public People()
        {

        }
        public People(string Surname, uint Age, string City)
        {
            this.surname = Surname;
            this.age = Age;
            this.city = City;
        }

    }

    public static class RecordsXML
    {
        public static Info Get()
        {
            var xml = new XmlSerializer(typeof(Info));
            using (FileStream fs = new FileStream("People.xml", FileMode.OpenOrCreate))
            {
                return (Info)xml.Deserialize(fs);
            }
        }

        /*public static List<People> GetMiddleAge()
        {
            var records = RecordsXML.Get().PeopleList;
            People maleRecord = new People();
            maleRecord.Height = 0;
            Record femaleRecord = new Record();
            femaleRecord.Height = 0;

            

            var result = new List<Record> { pe, femaleRecord };
            return result;
        }*/


        public static void Generate(uint num)
        {
            var xml = new XmlSerializer(typeof(Info));
            var surnames = new string[] { "Иванов", "Трифонов", "Смирнов", "Кузнецов", "Соколов", "Козлов", "Сидоров" };
            var cities = new string[] { "Кемерово", "Новокузнецк", "Москва", "Омск", "Томск","Новосибирск","Нижний Новгород","СПБ","Калининград"  };
            

            var rand = new Random();
            string surname, city;
            uint age;

            var result = new Info();

            for (int i = 0; i < num; ++i)
            {
                
                    surname = surnames[rand.Next(0, 7)];
                    city = cities[rand.Next(0, 9)];

                age = Convert.ToUInt16(rand.Next(1, 99));
                var rec = new People(surname,age,city);
                result.PeopleList.Add(rec);
            }

            using (FileStream fs = new FileStream("People.xml", FileMode.Create))
            {
                xml.Serialize(fs, result);
            }
        }
    }

}