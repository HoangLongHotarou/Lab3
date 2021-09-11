using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Class
{
    public class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Class { get; set; }
        public string Picture { get; set; }
        public bool Sex { get; set; }
        public List<string> Major { get; set; }

        public Student()
        {
            Major = new List<string>();
        }

        public Student(string iD, string name, DateTime dateOfBirth, string address, string @class, string picture, bool sex, List<string> major)
        {
            ID = iD;
            Name = name;
            DateOfBirth = dateOfBirth;
            Address = address;
            Class = @class;
            Picture = picture;
            Sex = sex;
            Major = major;
        }
    }
}
