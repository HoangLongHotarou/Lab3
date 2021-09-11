using Lab3.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Class
{
    public delegate int Compare(object st1, object st2);
    public class StudentManager
    {
        public List<Student> ls;

        public StudentManager()
        {
            ls = new List<Student>();
        }

        public Student this[int index]
        {
            get { return ls[index]; }
            set { ls[index] = value; }
        }

        public void Sort(TypeOfSortOrSearch type)
        {
            ls.Sort(delegate (Student first, Student second)
            {
                if (type == TypeOfSortOrSearch.MaSV)
                    return first.ID.CompareTo(second.ID);
                else if (type == TypeOfSortOrSearch.HoTem)
                    return first.Name.CompareTo(second.Name);
                return DateTime.Compare(first.DateOfBirth,second.DateOfBirth);
            });
        }
       
        public void Delete(object obj, Compare cp)
        {
            int i = ls.Count - 1;
            for (; i >= 0; i--)
            {
                if (cp(obj, this[i]) == 0)
                    this.ls.RemoveAt(i);
            }
        }

        public Student Find(object obj, Compare cp)
        {
            Student stResult = null;
            foreach (var st in ls)
            {
                if (cp(obj, st) == 0)
                {
                    stResult = st;
                    break;
                }
            }
            return stResult;
        }

        public List<Student> Search(TypeOfSortOrSearch type, string element)
        {
            return ls.FindAll(delegate (Student first)
            {
                if (type == TypeOfSortOrSearch.MaSV)
                    return first.ID == element;
                else if (type == TypeOfSortOrSearch.HoTem)
                    return first.Name.Trim().ToLower() == element.Trim().ToLower();
                return first.DateOfBirth == DateTime.Parse(element);
            });
        }

        public bool Update(Student stUpdate, object obj, Compare cp)
        {
            int i, count;
            bool kq = false;
            count = this.ls.Count;
            for (i=0;  i< count; i++)
            {
                if(cp(obj,this[i])==0)
                {
                    this[i] = stUpdate;
                    kq = true;
                    break;
                }
            }
            return kq;
        }

        public void ReadFile()
        {
            string fileName = "Data/DataSV.txt",t;
            string[] s;
            Student st;
            StreamReader sr = new StreamReader(new FileStream(fileName,FileMode.Open));
            while ((t=sr.ReadLine())!=null)
            {
                s = t.Split('\t');
                st = new Student();
                st.ID = s[0].Trim();
                st.Name = s[1];
                st.DateOfBirth = DateTime.Parse(s[2]);
                st.Address = s[3];
                st.Class = s[4];
                st.Picture = s[5];
                st.Sex = false;
                if (s[6] == "1")
                    st.Sex = true;
                string[] mj = s[7].Split(',');
                foreach (string c in mj)
                {
                    st.Major.Add(c);
                }
                ls.Add(st);
            }
        }
    }
}
