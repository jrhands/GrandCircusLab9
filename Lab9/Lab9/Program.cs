using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab9
{
    class Program
    {

        static void Main(string[] args)
        {
            List<List<string>> classmates = LoadData();
            Console.Write("Welcome to our C# class. ");
            do
            {
                Console.WriteLine("Would you like to (view) student information or (add) a student to the database?");
                string input = GetValidMenuOption();
                if (input == "view")
                {
                    ViewInformation(classmates);
                }
                else if (input == "add")
                {
                    classmates = AddClassmate(classmates);
                }
            } while (IsRepeating());
            Console.WriteLine("Goodbye!");
            Console.ReadKey();
        }

        static List<List<string>> AddClassmate(List<List<string>> classmates)
        {
            Console.WriteLine("This will add a classmate to the list.");
            Console.WriteLine("Would you like to continue? (y/n):");
            return classmates;
        }

        static void ViewInformation(List<List<string>> classmates)
        {
            List<string> classmate = GetValidClassmate(classmates);
            PrintInfo(classmate);
            Console.Write("Would you like to learn about another student? (enter \"y\" or \"n\"): ");
        }

        static string GetValidMenuOption()
        {
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if (Regex.IsMatch(input, "view|add"))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter \"view\" or \"add\".");
                }
            }
        }

        static int GetValidIndex(List<List<string>> classmates)
        {
            Console.Write($"Which student would you like to learn more about? (enter a number 1-{classmates.Count}): ");
            String input = Console.ReadLine();
            int index;
            try
            {
                index = int.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Not a valid index. Must be an integer 1-20.");
                index = GetValidIndex(classmates);
            }
            return index;
        }

        static List<string> GetValidClassmate(List<List<string>> classmates)
        {
            const int FIRSTNAME = 0, LASTNAME = 1;
            int index = GetValidIndex(classmates) - 1;
            List<string> classmate;
            try
            {
                classmate = classmates[index];
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Not a valid index. Must be an integer 1-20.");
                classmate = GetValidClassmate(classmates);
            }
            Console.Write($"Student {index + 1} is {classmate[FIRSTNAME]} {classmate[LASTNAME]}. ");
            return classmate;
        }

        static void PrintInfo(List<string> classmate)
        {
            while (true)
            {
                const int FIRSTNAME = 0, LASTNAME = 1, HOMETOWN = 2, FAVORITEFOOD = 3;
                Console.Write($"What would you like to know about {classmate[FIRSTNAME]} {classmate[LASTNAME]}? (enter \"hometown\" or \"favorite food\"): ");
                String input = Console.ReadLine().ToLower();
                if (input == "hometown")
                {
                    Console.Write($"{classmate[FIRSTNAME]} is from {classmate[HOMETOWN]}. ");
                }
                else if (input == "favorite food")
                {
                    Console.Write($"{classmate[FIRSTNAME]} likes to eat {classmate[FAVORITEFOOD]}. ");
                }
                else
                {
                    Console.WriteLine("That data does not exist. Please try again.");
                    continue;
                }
                Console.Write("Would you like to know more? (enter \"y\" or \"n\"): ");
                bool repeat = IsRepeating();
                if (repeat)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
        }

        static bool IsRepeating()
        {
            String input = Console.ReadLine().ToLower();
            if (Regex.IsMatch(input, "y|yes"))
            {
                return true;
            }
            else if (Regex.IsMatch(input, "n|no"))
            {
                return false;
            }
            else
            {
                Console.Write("Invalid input. Must be \"y\" or \"n\": ");
                return IsRepeating();
            }
        }

        static List<List<string>> LoadData()
        {
            return new List<List<string>>
            {
                new List<string> { "Fabricia", "Gensch", "Riverside, CA", "BBQ Ribs", "Red" },
                new List<string> { "Cintia", "Buachalla", "Anchorage, AK", "Chocolate Ice Cream", "Orange" },
                new List<string> { "Elvira", "Auteberry", "Tuscon, AZ", "Blueberries", "Yellow" },
                new List<string> { "Graciana", "Koning", "Tampa, FL", "Steak", "Green" },
                new List<string> { "Gaetan", "Dickinson", "Anchorage, AK", "Roast Beef", "Blue" },
                new List<string> { "Cian", "Weaver", "Tampa, FL", "Bratwurst", "Indigo" },
                new List<string> { "Gerolt", "Milburn", "Tuscon, AZ", "Eggs Benedict", "Purple" },
                new List<string> { "Perlita", "MacFarlane", "Tampa, FL", "Sweet & Sour Chicken", "Black" },
                new List<string> { "Elise", "Hogarth", "Riverside, CA", "Strawberry Pie", "White" },
                new List<string> { "Trina", "Moller", "Indianapolis, IN", "Duck", "Grey" },
                new List<string> { "Malini", "Carter", "Dallas, TX", "Caramel Apples", "Gray" },
                new List<string> { "Anna", "Vaccaro", "Riverside, CA", "Mashed Potatoes", "Gold" },
                new List<string> { "Aina", "Hoggard", "Indianapolis, IN", "Spring Rolls", "Silver" },
                new List<string> { "Fae", "Hanraets", "Dallas, TX", "Chicken", "Cyan" },
                new List<string> { "Edita", "Cuellar", "Anchorage, AK", "Mac & Cheese", "Magenta" },
                new List<string> { "Thyge", "Barnet", "Tuscon, AZ", "Corn", "Brown" },
                new List<string> { "Kapono", "Forestier", "Tuscon, AZ", "Baked Beans", "Scarlet" },
                new List<string> { "Kiley", "Haight", "Tuscon, AZ", "Turkey", "Dark Blue" },
                new List<string> { "Lila", "Rothbauer", "Riverside, CA", "Apples", "Pink" },
                new List<string> { "Clair", "Alberghini", "Indianapolis, IN", "Tacos", "Dark Green" }
            };
        }
    }
}
