using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        //unused
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

        class Bonus: IEnumerable<String>
        {
            private int max = -1;

            public Bonus(int max)
            {
                this.max = max;
            }

            public IEnumerator<String> GetEnumerator()
            {
                return new BonusEnum(max);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        class BonusEnum: IEnumerator<String>
        {
            String[] values;
            int position = -1;

            public BonusEnum(int max)
            {
                values = new String[max];

                for (int number = 1; number <= max; number++)
                {
                    String message = "";

                    if (number % 3 == 0)
                    {
                        message = "Fizz";
                    }
                    if (number % 5 == 0)
                    {
                        message += "Buzz";
                    }
                    if (number % 7 == 0)
                    {
                        message += "Bang";
                    }
                    if (number % 11 == 0)
                    {
                        message = "Bong";
                    }
                    if (number % 13 == 0)
                    {
                        message = insertFezz(message);
                    }
                    if (number % 17 == 0)
                    {
                        message = reverseFizz(message);
                    }

                    if (message.Length > 0)
                    {
                        values[number-1] = message;
                    }
                    else
                    {
                        values[number - 1] = number + "";
                    }
                }
            }

            private String current = "";

            public String Current
            {
                get { return this.current; }
            }

            object IEnumerator.Current
            {
                get { return this.Current; }
            }

            public bool MoveNext()
            {
                try
                {
                    current = values[position++];
                    return true;
                }
                catch (IndexOutOfRangeException)
                {
                    return false;
                }
            }

            public void Reset()
            {
                position = -1;
            }

            public void Dispose()
            {
                
            }
        }

        static void Main(string[] args)
        {
            //part 1
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

            //this list represents the current active rules
            Dictionary<int, String> rules = new Dictionary<int, String>();

            Console.WriteLine("Please enter the rules(separated with spaces):");
            Console.WriteLine("Example: -3 -5 -7 will enable the Fizz, Buzz and Bang rules");
            Console.WriteLine("If the rule is not known, ex: -40, write the rule word(4 letters, first is uppercased) immediately afterwards: -40Zoom");
            Console.WriteLine("Note: you cannot override existing rules!(-3, -5, -7, -11, -13, -17)");

            String userInputRules = Console.ReadLine();
            String[] userSelectedRules = userInputRules.Split(" ");

            foreach(String rule in userSelectedRules)
            {
                if(rule != "" && rule.StartsWith("-"))//if the rule follows the above example then we check
                {
                    switch(rule)
                    {
                        case "-3"://for each rule that the program knows
                            rules.Add(3, "Fizz");
                            break;
                        case "-5":
                            rules.Add(5, "Buzz");
                            break;
                        case "-7":
                            rules.Add(7, "Bang");
                            break;
                        case "-11":
                            rules.Add(11, "Bong");
                            break;
                        case "-13":
                            rules.Add(13, "Fezz");
                            break;
                        case "-17":
                            rules.Add(17, "");
                            break;
                        default://and for new rules
                            Regex rg = new Regex("-[0-9]+[A-Z][a-z]{3}");
                            if(rg.IsMatch(rule))
                            {
                                //the number part will represent all that is after the first character ("-") until the last 4 characters
                                int numberPart = Int32.Parse(rule.Substring(1, rule.Length - 5));
                                //the word part represents only the last 4 characters
                                String wordPart = rule.Substring(rule.Length - 4);

                                //check if rule exists already
                                List<int> keyListTemp = new List<int>(rules.Keys);
                                //if it does not, add it
                                if(!keyListTemp.Contains(numberPart))
                                {
                                    rules.Add(numberPart, wordPart);
                                }
                            }
                            //else ignore all the other entries
                            break;
                    }
                }
            }

            List<int> keyList = new List<int>(rules.Keys);
            Console.WriteLine("Number of rules: " + keyList.Count);

            //here we loop through all the numbers from 1 to maxvalue
            for (int number = 1; number <= maxvalue; number++)
            {
                String message = "";

                foreach(int key in keyList)
                {
                    switch (key)
                    {
                        case 11:
                            if (number % key == 0)
                            {
                                message = rules[key];
                            }
                            break;
                        case 13:
                            if (number % key == 0)
                            {
                                message = insertFezz(message);
                            }
                            break;
                        case 17:
                            if (number % key == 0)
                            {
                                message = reverseFizz(message);
                            }
                            break;
                        case 3:
                        case 5:
                        case 7:
                        default:
                            if (number % key == 0)
                            {
                                message += rules[key];
                            }
                            break;
                    }
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

            //part 2 continuation

            //IEnumerable bonus
            var fizzBuzzer = new Bonus(100);

            foreach (var value in fizzBuzzer)
            {
                //Console.WriteLine(value);
            }


            //not yet done - the oneliner

            var fizzBuzzer2 = from value in Enumerable.Range(1, 100) select value;
        }
    }
}
