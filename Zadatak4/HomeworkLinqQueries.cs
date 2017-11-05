using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using PrviZadatak;

namespace Zadatak4

{
    public class HomeworkLinqQueries
    {

        public static string[] Linq1(int[] intArray)
        {

            intArray = intArray.OrderBy(s => s).ToArray();
            List<String> groupString = new List<string>();
            foreach (var group in intArray.GroupBy(s => s))
            {
                String a = String.Format("Broj {0} ponavlja se {1} puta" , group.Key , group.Count());
                groupString.Add(a);
            }
            String[] list = groupString.ToArray();

            return list;

        }

        public static University[] Linq2_1(University[] universityArray)
        {
            
            return universityArray.Where(s => s.Students.All(x => x.Gender == Gender.Male)).ToArray();


        }

        public static University[] Linq2_2(University[] universityArray)
        {

            double prosjek = ((double) universityArray.Sum(s => s.Students.Length))/universityArray.Length;

            return universityArray.Where(s => s.Students.Length < prosjek).ToArray();



        }
        public static Student[] Linq2_3(University[] universityArray)
        {

            return universityArray.SelectMany(s => s.Students).Distinct().ToArray();


        }
        public static Student[] Linq2_4(University[] universityArray)
        {

            return universityArray.Where(s =>
                    s.Students.All(x => x.Gender == Gender.Male) || s.Students.All(x => x.Gender == Gender.Female))
                .ToArray().SelectMany(i => i.Students).Distinct().ToArray();

        }
        public static Student[] Linq2_5(University[] universityArray)
        {

          return universityArray.SelectMany(s => s.Students).GroupBy(i => i).Where(g => g.Count() > 1)
               .Select(y => y.Key).ToArray();
        }

    }
}
