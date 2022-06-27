using System;

namespace fizzbuzz
{
    class Program
    {
        //reverses the order of fizzes and buzzes and etc..
        //example: FizzBuzz becomes BuzzFizz
        static String reverseFizz(String message)
        {
            //we take an empty string
            String newMessage = "";

            //if this happens we return the empty string
            //because that would mean the input is not particulary correct
            if(message.Length % 4 != 0)
            {
                return newMessage;
            }

            for (int j = message.Length - 4; j >= 0; j -= 4)
            {
                //and append to it every 4 characters from beginning to end from the input string
                newMessage += message.Substring(j, 4);
            }

            return newMessage;
        }

        static String insertFezz(String message)
        {
            if (message.Contains('B'))//if there is a "B" insert Fezz before it's first apparition
            {
                return message.Substring(0, message.IndexOf('B')) + "Fezz" + message.Substring(message.IndexOf('B'));
            }
            else//or else insert it at the end
            {
                return message + "Fezz";
            }
        }

        static bool promptRule(String ruleName, String ruleExplanation)
        {
            String input = "";

            do
            {
                Console.WriteLine("Would you like the " + ruleName + "(" + ruleExplanation + ") rule to be active?(y/n)");
                input = Console.ReadLine();
            }
            while (input != "y" && input != "n");

            if(input == "y")
            {
                return true;
            }
            return false;
        }

        class iterate
        {

        }

        static void Main(string[] args)
        {
            //this integer represents the number of loops our for will perform
            int maxvalue = -1;

            do
            {
                Console.WriteLine("Please enter a positive non-null number:");//we prompt the user to enter a positive non-null number

                Int32.TryParse(Console.ReadLine(), out maxvalue);//if it's a positive number all is ok
                //if not this triggers and the user is prompted again to enter a positive non-null number
            }
            while(maxvalue <= 0);

            Console.WriteLine("You have entered a valid number.");

            bool fizzRule = promptRule("Fizz", "Fizz appears if a number is a multiple of 3");
            bool buzzRule = promptRule("Buzz", "Buzz appears if a number is a multiple of 5");
            bool bangRule = promptRule("Bang", "Bang appears if a number is a multiple of 7");
            bool bongRule = promptRule("Bong", "Bong appears if a number is a multiple of 11 and erases previous rules");
            bool fezzRule = promptRule("Fezz", "Fezz appears if a number is a multiple of 13");
            bool reverseRule = promptRule("Reverse", "If the number is a multiple of 17 reverse the order of fizzes and buzzes");

            //here we loop through all the numbers from 1 to maxvalue
            for(int number = 1; number <= maxvalue; number++)
            {
                String message = "";

                //if the number is a multiple of 3, our message becomes "Fizz"
                if(number % 3 == 0 && fizzRule)
                {
                    message = "Fizz";
                }
                //if it's also a multiple of 5 append "Buzz"
                if(number % 5 == 0 && buzzRule)
                {
                    message += "Buzz";
                }
                //same as above but for 7 and appends Bang
                if(number % 7 == 0 && bangRule)
                {
                    message += "Bang";
                }
                //if its a multiple of 11 the message becomes "Bong"
                if(number % 11 == 0 && bongRule)
                {
                    message = "Bong";
                }
                //if the number is also a multiple of 13, insert "Fezz" in front of the first thing beginning with "B"
                if(number % 13 == 0 && fezzRule)
                {
                    message = insertFezz(message);
                }
                //if the number is a multiple of 17 we reverse the order of the fizzes/buzzes
                //ex: if it's FizzBuzz it becomes BuzzFizz
                //for this we call a function reverseFizz(String) defined above main
                if(number % 17 == 0 && reverseRule)
                {
                    message = reverseFizz(message);
                }

                //display fizzes/buzzes/etc if any
                if(message.Length > 0)
                {
                    Console.WriteLine(message);
                }
                //else display the number
                else
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
