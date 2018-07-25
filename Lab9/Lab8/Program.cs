using System;
using System.Text.RegularExpressions;

namespace Lab8
{
    class Program
    {

        static void Main(string[] args)
        {
            String[][] classmates = LoadData();
            Console.Write("Welcome to our C# class. ");
            do
            {
                String[] classmate = GetValidClassmate(classmates);
                PrintInfo(classmate);
                Console.Write("Would you like to learn about another student? (enter \"y\" or \"n\"): ");
            } while (IsRepeating());
            Console.WriteLine("Goodbye!");
            Console.ReadKey();
        }

        static int GetValidIndex()
        {
            Console.Write("Which student would you like to learn more about? (enter a number 1-20): ");
            String input = Console.ReadLine();
            int index;
            try
            {
                index = int.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Not a valid index. Must be an integer 1-20.");
                index = GetValidIndex();
            }
            return index;
        }

        static String[] GetValidClassmate(String[][] classmates)
        {
            const int FIRSTNAME = 0, LASTNAME = 1;
            int index = GetValidIndex() - 1;
            String[] classmate;
            try
            {
                classmate = classmates[index];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Not a valid index. Must be an integer 1-20.");
                classmate = GetValidClassmate(classmates);
            }
            Console.Write($"Student {index + 1} is {classmate[FIRSTNAME]} {classmate[LASTNAME]}. ");
            return classmate;
        }

        static void PrintInfo(String[] classmate)
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
                Console.Write("Would you like to know more? (enter \"yes\" or \"no\"): ");
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

        static String[][] LoadData()
        {
            String[] fabricia = { "Fabricia", "Gensch", "Riverside, CA", "BBQ Ribs" };
            String[] cintia = { "Cintia", "Buachalla", "Anchorage, AK", "Chocolate Ice Cream" };
            String[] elvira = { "Elvira", "Auteberry", "Tuscon, AZ", "Blueberries" };
            String[] graciana = { "Graciana", "Koning", "Tampa, FL", "Steak" };
            String[] gaetan = { "Gaetan", "Dickinson", "Anchorage, AK", "Roast Beef" };
            String[] cian = { "Cian", "Weaver", "Tampa, FL", "Bratwurst" };
            String[] gerolt = { "Gerolt", "Milburn", "Tuscon, AZ", "Eggs Benedict" };
            String[] perlita = { "Perlita", "MacFarlane", "Tampa, FL", "Sweet & Sour Chicken" };
            String[] elise = { "Elise", "Hogarth", "Riverside, CA", "Strawberry Pie" };
            String[] trina = { "Trina", "Moller", "Indianapolis, IN", "Duck" };
            String[] malini = { "Malini", "Carter", "Dallas, TX", "Caramel Apples" };
            String[] anna = { "Anna", "Vaccaro", "Riverside, CA", "Mashed Potatoes" };
            String[] aina = { "Aina", "Hoggard", "Indianapolis, IN", "Spring Rolls" };
            String[] fae = { "Fae", "Hanraets", "Dallas, TX", "Chicken" };
            String[] edita = { "Edita", "Cuellar", "Anchorage, AK", "Mac & Cheese" };
            String[] thyge = { "Thyge", "Barnet", "Tuscon, AZ", "Corn" };
            String[] kapono = { "Kapono", "Forestier", "Tuscon, AZ", "Baked Beans" };
            String[] kiley = { "Kiley", "Haight", "Tuscon, AZ", "Turkey" };
            String[] lila = { "Lila", "Rothbauer", "Riverside, CA", "Apples" };
            String[] clair = { "Clair", "Alberghini", "Indianapolis, IN", "Tacos" };
            String[][] classmates = new String[20][];
            classmates[0] = fabricia;
            classmates[1] = cintia;
            classmates[2] = elvira;
            classmates[3] = graciana;
            classmates[4] = gaetan;
            classmates[5] = cian;
            classmates[6] = gerolt;
            classmates[7] = perlita;
            classmates[8] = elise;
            classmates[9] = trina;
            classmates[10] = malini;
            classmates[11] = anna;
            classmates[12] = aina;
            classmates[13] = fae;
            classmates[14] = edita;
            classmates[15] = thyge;
            classmates[16] = kapono;
            classmates[17] = kiley;
            classmates[18] = lila;
            classmates[19] = clair;
            return classmates;
        }

    }
}
