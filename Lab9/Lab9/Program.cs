using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab9
{
    class Program
    {

        static void Main(string[] args)
        {
            //Loads all of my pre-made data into the List
            List<List<string>> classmates = GetDefaultData();

            //Welcome message
            Console.Write("Welcome to our C# class. ");

            //This do/while loop controls the majority of the flow of the program
            do
            {
                //Main menu
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

                //Ask to return to main menu or quit program
                Console.WriteLine("Would you like to continue? (y/n):");
            } while (IsRepeating());

            //Exit message
            Console.WriteLine("Goodbye!");
            Console.ReadKey();
        }

        //Takes in the current list of classmates, returns that list with the new student added
        static List<List<string>> AddClassmate(List<List<string>> classmates)
        {
            //Variables used to create new student, with default values
            string firstName = "default", lastName = "default", hometown = "default", food = "default", color = "default";

            //Main input of information for new student
            Console.WriteLine("Please enter the following information about the student.");
            firstName = GetValidInput("First name: ", @"^[A-Z][a-zA-Z]*$", "start with a capital letter and consist only of letters.");
            lastName = GetValidInput("Last name: ", @"^[A-Z][a-zA-Z\s]*$", "start with a capital letter and consist of only letters and spaces.");
            hometown = GetValidInput("Hometown: ", @"^[A-Z][a-zA-Z\s]*,\s[A-Z][a-zA-Z\s]$", "contain a town and state/country, both of which start with a capital letter and consist of only letters and spaces, and are separated by a comma and a space.");
            food = GetValidInput("Favorite Food: ", @"^[A-Z][a-zA-Z\s]*$", "start with a capital letter and consist of only letters and spaces.");
            color = GetValidInput("Favorite Color: ", @"^[A-Z][a-zA-Z\s]*$", "start with a capital letter and consist of only letters and spaces.");

            //Adds the new student to the list of classmates
            classmates.Add(new List<string> { firstName, lastName, hometown, food, color });

            //Return modified list
            return classmates;
        }

        //General method for prompting the user for a string and verifying it against a given regular expression
        static string GetValidInput(string prompt, string expression, string description)
        {
            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (Regex.IsMatch(input, expression))
                {
                    return input.Trim();
                }
                else
                {
                    Console.WriteLine($"Invalid input. Must {description}");
                }
            } while (true);
        }

        //Controls selecting a classmate and opening a menu to view their information
        static void ViewInformation(List<List<string>> classmates)
        {
            List<string> classmate = GetValidClassmate(classmates);
            PrintInfo(classmate);
        }

        //Gets, validates, and returns user input for the main menu.
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

        //Prompts the user for an index, verifies that their input is a valid integer, then returns it
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
                Console.WriteLine($"Not a valid index. Must be an integer 1-{classmates.Count}.");
                index = GetValidIndex(classmates);
            }
            return index;
        }

        //Verifies that a user-input integer is a valid index for the list of classmates, prints their first and last name,
        //then returns that classmate
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
                Console.WriteLine($"Not a valid index. Must be an integer 1-{classmates.Count}.");
                classmate = GetValidClassmate(classmates);
            }
            Console.Write($"Student {index + 1} is {classmate[FIRSTNAME]} {classmate[LASTNAME]}. ");
            return classmate;
        }

        //Takes a classmate and controls the menu for viewing their data
        static void PrintInfo(List<string> classmate)
        {
            while (true)
            {
                const int FIRSTNAME = 0, LASTNAME = 1, HOMETOWN = 2, FAVORITEFOOD = 3, FAVORITECOLOR = 4;

                //View menu
                Console.Write($"What would you like to know about {classmate[FIRSTNAME]} {classmate[LASTNAME]}? (enter \"hometown\", \"favorite food\" or \"favorite color\"): ");
                String input = Console.ReadLine().ToLower();
                if (input == "hometown")
                {
                    Console.Write($"{classmate[FIRSTNAME]} is from {classmate[HOMETOWN]}. ");
                }
                else if (input == "favorite food")
                {
                    Console.Write($"{classmate[FIRSTNAME]} likes to eat {classmate[FAVORITEFOOD]}. ");
                }
                else if (input == "favorite color")
                {
                    Console.WriteLine($"{classmate[FIRSTNAME]} loves the color {classmate[FAVORITECOLOR]}");
                }
                else
                {
                    Console.WriteLine("That data does not exist. Please try again.");
                    continue;
                }

                //Asks user to either view more info about the student or return to the main menu
                Console.Write($"Would you like to know more about {classmate[FIRSTNAME]}? (enter \"y\" or \"n\"): ");
                if (IsRepeating())
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
        }

        //Takes user input and returns true for y or yes, false for n or no. Used to control various menu loops.
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

        //Returns a set of default data for the program.
        static List<List<string>> GetDefaultData()
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
