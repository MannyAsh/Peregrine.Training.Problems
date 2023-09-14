using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
     class Program
    {
        static void Main(string[] args)
        {

            //Problem 1
            Console.WriteLine("Problem 1 - Longest Sequence ");

            Console.WriteLine(" ");


            // problem 2
            Console.WriteLine("Problem 2 - Anagrams ");

            List<string> words = new List<string> {

                "parts", "traps", "arts", "rats", "starts", "tarts", "rat", "art", "tar", "stars", "stray"
  
                

            };

            List<string> wordswithStar = words.Where(word => word.Contains("star")).ToList();

            foreach (string word in wordswithStar) {

                Console.WriteLine(word);
                
            
            }

            Console.WriteLine(" ");

            // problem 3
            Console.WriteLine("Problem 3 - Stars on screen ");


            int a = 5;
            

            for (int i = 1; i <= a; i++)
            {
                for (int j = 1; j <= a - i; j++)
                {
                    Console.Write(" ");
                }

                for (int k = 1; k <= 2 * i - 1; k++) {

                    Console.Write("*");
                
                }

                Console.WriteLine();
                
            }


            Console.WriteLine("");

            // problem 4
            Console.WriteLine("Problem 4 - Star - Diamond ");

            int b = 5;


            for (int x = 1; x <= b; x++)
            {
                int c = 5; // Number of rows in the diamond

                // Upper half of the diamond
                for (int i = 1; i <= c; i++)
                {
                    // Print spaces before stars
                    for (int j = 1; j <= c - i; j++)
                    {
                        Console.Write(" ");
                    }

                    // Print stars
                    for (int k = 1; k <= 2 * i - 1; k++)
                    {
                        Console.Write("*");
                    }

                    // Move to the next line
                    Console.WriteLine();
                }

                // Lower half of the diamond
                for (int i = c - 1; i >= 1; i--)
                {
                    // Print spaces before stars
                    for (int j = 1; j <= c - i; j++)
                    {
                        Console.Write(" ");
                    }

                    // Print stars
                    for (int k = 1; k <= 2 * i - 1; k++)
                    {
                        Console.Write("*");
                    }

                    // Move to the next line
                    Console.WriteLine();
                }
            }

            // problem 5
            Console.WriteLine("Problem 5 - String Reversal ");

            string wordToReverse = "Hello";
            string reversedWord = new string(wordToReverse.ToCharArray().Reverse().ToArray());
            Console.WriteLine(wordToReverse);
            Console.WriteLine(reversedWord);
            

            Console.WriteLine(" ");

            // problem 6
            Console.WriteLine("Problem 6 - palindrome ");
            Console.WriteLine(" ");

            Console.WriteLine("Enter a word: ");

            string inputtedWord = Console.ReadLine();

            if (IsPalindrome(inputtedWord))
            {

                Console.WriteLine("Palindrome");
            }

            else {

                Console.WriteLine("Not a Palindrome");
            
            }


            // problem 7
            Console.WriteLine("Problem 7 - sum of digits ");

            Console.WriteLine("Enter a number: ");

            String inputNumber = Console.ReadLine();

            int sum = SumDigits(inputNumber);

            Console.WriteLine(sum);
            Console.ReadLine();

            //Problem 8 - TwoSums

            Console.WriteLine(" ");
            Console.WriteLine("Problem 8 - TwoSums");

            List<int> numbers = new List<int> { 2, 7, 11, 15 };
            int targetSum = 9;

            int[] result = TwoSum(numbers, targetSum);

            if (result != null)
            {
                Console.WriteLine($"Indices: [{result[0]}, {result[1]}]");
            }
            else
            {
                Console.WriteLine("No two numbers add up to the target sum.");
            }


            //Problem 9 - Prime at Nth Position

            Console.WriteLine(" ");
            Console.WriteLine("Problem 9 - Prime at Nth Position");

            Console.Write("Enter the position (N) to find the Nth prime number: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                int nthPrime = GetNthPrime(n);
                Console.WriteLine($"The {n}th prime number is {nthPrime}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid positive integer.");
            }

            //Problem 10 - Next Prime Number

            Console.WriteLine(" ");
            Console.WriteLine("Problem 10 - Next Prime Number");

            Console.Write("Enter a number: ");
            if (int.TryParse(Console.ReadLine(), out int inputNumber2))
            {
                int nextPrime = FindNextPrime(inputNumber2);
                Console.WriteLine($"The next prime number after {inputNumber2} is {nextPrime}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            Console.ReadLine();
        }

        static int[] TwoSum(List<int> numbers, int targetSum)
        {
            Dictionary<int, int> numIndices = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int complement = targetSum - numbers[i];

                if (numIndices.ContainsKey(complement))
                {
                    return new int[] { numIndices[complement], i };
                }

                if (!numIndices.ContainsKey(numbers[i]))
                {
                    numIndices[numbers[i]] = i;
                }
            }

            return null;
        }

        static bool IsPalindrome(String word) {

            word = word.Replace(" ","").ToLower();  

            int left = 0;
            int right = word.Length - 1;

            while (left < right)
            {
                if (word[left] != word[right])
                {

              
                    return false;

                }

                else {

                    return true;
                
                }
                left++;
                right--;
            }
            return true;

        }

   
        static bool isPrimeNumber(int number) {

            if (number <= 1)
                return false;

            if (number <= 3)
                return true;

            if (number % 2 == 0 || number % 3 == 0)
                return false;

            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                    return false;
            }

            return true;
        }

        static int GetNthPrime(int n)
        {
            if (n == 1)
                return 2;

            int count = 1; // Starting with the first prime number (2)
            int number = 1; // The number we're checking for primality

            while (count < n)
            {
                number += 2; // Check only odd numbers (even numbers greater than 2 are not prime)
                if (isPrimeNumber(number))
                {
                    count++;
                }
            }

            return number;
        }

        static int FindNextPrime(int start)
        {
            int next = start;

            while (true)
            {
                next++;
                if (isPrimeNumber(next))
                    return next;
            }
        }

        static int SumDigits (String input)
        {
            int sum = 0;

            foreach (char digitChar in input)
            {
                if (char.IsDigit(digitChar))
                {
                    int digit = (int)char.GetNumericValue(digitChar);
                    sum += digit;
                }
            }

            return sum;  

        }

       
    



    }
}
