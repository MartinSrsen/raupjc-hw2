using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak6i7
{
    public class Zad6i7
    {

        private async static void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = await GetTheMagicNumber();
            Console.WriteLine(result);
        }
        private async static Task<int> GetTheMagicNumber()
        {
            return await IKnowIGuyWhoKnowsAGuy();
        }
        private async static Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            return await IKnowWhoKnowsThis(10) + await IKnowWhoKnowsThis(5);
        }
        private async static Task<int> IKnowWhoKnowsThis(int n)
        {
            return await FactorialDigitSum(n);
        }





        private static Task<int> FactorialDigitSum(int n)
        {
            var t = Task.Run(() => Calculatesum(n));

            return t;
        }

        private static int Calculatesum(int n)
        {
            int i, fact;
            fact = n;
            for (i = n - 1; i >= 1; i--)
            {
                fact = fact * i;
            }

            return fact;
        }

        

        


        

    }

    
}
