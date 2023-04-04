using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkersDB
{
    class WorkerClass
    {
        string _name;
        int _age;
        string _gender;

        public WorkerClass(string name, int age, string gender) //konstruktorban hiányzik a visszatérési érték (void), a neve megegyezik az osztály nevével
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string GetDataString()
        {
            return Name + ';' + Age.ToString() + ';' + Gender;
        }
    }
}
