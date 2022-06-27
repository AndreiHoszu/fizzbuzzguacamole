using System;

namespace fizzbuzz
{
    class Program
    {
        //reverses the order of fizzes and buzzes and etc..
        //example: FizzBuzz becomes BuzzFizz
        static String reverseFizz(String x)
        {
            //we take an empty string
            String s = "";

            //if this happens we return the empty string
            //because that would mean the input is not particulary correct
            if(x.Length % 4 != 0)
            {
                return s;
            }

            for (int j = x.Length - 4; j >= 0; j -= 4)
            {
                //and append to it every 4 characters from beginning to end from the input string
                s += x.Substring(j, 4);
            }

            return s;
        }

        static String insertFezz(String s, int position)
        {
            return s.Substring(0, position) + "Fezz" + s.Substring(position);
        }

        static void Main(string[] args)
        {
            for (int i = 1; i <= 255; i++)
            {
                String s = "";

                //if the number is a multiple of 3, our message becomes "Fizz"
                if(i % 3 == 0)
                {
                    s = "Fizz";
                }
                //if it's also a multiple of 5 append "Buzz"
                if(i % 5 == 0)
                {
                    s += "Buzz";
                }
                //same as above but for 7 and appends Bang
                if(i % 7 == 0)
                {
                    s += "Bang";
                }
                //if its a multiple of 11 the message becomes "Bong"
                if(i % 11 == 0)
                {
                    s = "Bong";
                }
                //if the number is also a multiple of 13, insert "Fezz" in front of the first thing beginning with "B"
                if(i % 13 == 0)
                {
                    if(s.Contains('B'))//if there is a "B"
                    {
                        s = insertFezz(s, s.IndexOf('B'));
                    }
                    else//or else insert it at the end
                    {
                        s += "Fezz";
                    }
                }
                //if the number is a multiple of 17 we reverse the order of the fizzes/buzzes
                //ex: if it's FizzBuzz it becomes BuzzFizz
                //for this we call a function reverseFizz(String) defined above main
                if(i % 17 == 0)
                {
                    s = reverseFizz(s);
                }

                //display fizzes/buzzes/etc if any
                if(s.Length > 0)
                {
                    Console.WriteLine(s);
                }
                //else display the number
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
