namespace LychrelComputer
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public Program()
        {
            uint numberToCheck = 10;
            const int maxNum = 200;
            var stepsPerNumber = new Dictionary<uint, int>();

            while (numberToCheck <= maxNum)
            {
                Console.WriteLine("Checking {0}...", numberToCheck);

                var steps = 0;
                var currentNumber = numberToCheck;

                while (!IsLychrelNumber(currentNumber))
                {
                    Console.WriteLine("{0} + {1} = {2}", currentNumber, ReverseNumber(currentNumber), currentNumber+ReverseNumber(currentNumber));

                    currentNumber += ReverseNumber(currentNumber);
                    steps++;
                }

                stepsPerNumber.Add(numberToCheck, steps);

                Console.WriteLine("\n{0} took {1} steps", numberToCheck, steps);

                numberToCheck++;
            }

            Console.ReadLine();
        }

        private uint ReverseNumber(uint number)
        {
            var left = number;
            uint rev = 0;

            while (left > 0)
            {
                var r = left % 10;
                rev = rev * 10 + r;
                left = left / 10;  //left = Math.floor(left / 10); 
            }

            return rev;
        }

        private bool IsLychrelNumber(uint number)
        {
            return ReverseNumber(number).Equals(number);
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}
