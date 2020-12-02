using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panda_2
{
    static class UsefulTools
    {
        public static void SayHi(string name)
        {
            Console.WriteLine("Hello " + name);
        }
        public static void ToMinute(double s)
        {
            double m = 0;
            while(s >= 60)
            {
                s -= 60;
                m++;
            }
            double t = m + s / 100;
            if(t.ToString().Length == 3)
            {
                Console.WriteLine(Convert.ToString(t) + "0" + "m");
                return;
            }else if(t.ToString().Length == 1)
            {
                Console.WriteLine(Convert.ToString(t) + ".00" + "m");
            }
            Console.WriteLine(Convert.ToString(t) + "m");
            
        }
        public static void ToSecond(double m)
        {
            double s;
            s = m;
            m = Math.Floor(m);
            s = s - m;
            s *= 100;
            m *= 60;
            int t = Convert.ToInt32(s) + Convert.ToInt32(m);

            Console.WriteLine(Convert.ToString(t) + "s");
        }
        public static string IsPrimeNumber(int num)
        {
            for(int i = 2; i <= num; i++)
            {
                if(i == num)
                {
                    return i + " is a prime number";
                } else if (num % i == 0)
                {
                    return num + " is not a prime number, it can be divided by: " + i;
        
                }
            }
            return "Error";
        }     
        public static double Pitagora(double x, double y)
        {
            double dX = x * x;
            double dY = y * y;

            double i = Math.Sqrt(dX + dY);

            return i;
        }
        public static double MakeOperation(char x, double y, double z)
        {
            double ret;
            switch (x)
            {
                case '+':
                    ret = y + z;
                    return ret;
                case '-':
                    ret = y - z;
                    return ret;
                case '*':
                    ret = y * z;
                    return ret;
                case '/':
                    ret = y / z;
                    return ret;
            }
            return 0;
        }
        public static string Stupidify(string x)
        {
            StringBuilder sb = new StringBuilder(x);


            for(int i = 0; i < x.Length; i++)
            {
                if (i % 2 == 0)
                {
                    string z;
                    z = Convert.ToString(sb[i]);
                    z = z.ToLowerInvariant();
                    sb[i] = Convert.ToChar(z);

                } else if(i % 2 == 1)
                {
                    string z;
                    z = Convert.ToString(sb[i]);
                    z = z.ToUpperInvariant();
                    sb[i] = Convert.ToChar(z);
                }
            }
            string result = sb.ToString();
            return result;
        }
    }
}
