using System;

namespace fizzbuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 255; i++)
            {
                String s = "";

                if(i % 3 == 0)
                {
                    s = "Fizz";
                }
                if(i % 5 == 0)
                {
                    s += "Buzz";
                }
                if(i % 7 == 0)
                {
                    s += "Bang";
                }
                if(i % 11 == 0)
                {
                    s = "Bong";
                }
                if(i % 13 == 0)
                {
                    if(s.Contains('B'))
                    {
                        s = s.Substring(0, s.IndexOf('B')) + "Fezz" + s.Substring(s.IndexOf('B'));
                    }
                    else
                    {
                        s += "Fezz";
                    }
                }
                if(i % 17 == 0)
                {
                    String x = "";

                    for(int j = s.Length-4; j >= 0; j-=4)
                    {
                        x += s.Substring(j, 4);
                    }

                    s = x;
                }

                if(s.Length > 0)
                {
                    Console.WriteLine(s);
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
