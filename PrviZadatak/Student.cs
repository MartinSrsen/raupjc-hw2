using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrviZadatak
{

    

        public class Student
        {
            public string Name { get; set; }
            public string Jmbag { get; set; }
            public Gender Gender { get; set; }
            public Student(string name, string jmbag)
            {
                Name = name;
                Jmbag = jmbag;
            }

            public static bool operator ==(Student obj1, Student obj2)
            {
                

                return (obj1.Name == obj2.Name && obj1.Jmbag == obj1.Jmbag);
            }

            public static bool operator !=(Student obj1, Student obj2)
            {
                return !(obj1 == obj2);
            }

            public override int GetHashCode()
            {
                return Name.GetHashCode() * 3 + Jmbag.GetHashCode();
            }

            public override bool Equals(object obj)
            {

                if (obj == null)
                    return false;

                return this == (Student) obj;
            }
        }
        public enum Gender
        {
            Male, Female
        }


    
}
