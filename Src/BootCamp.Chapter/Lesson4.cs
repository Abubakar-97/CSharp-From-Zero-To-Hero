using System;
using System.Collections.Generic;
using System.Text;

namespace BootCamp.Chapter
{
    class Lesson4
    {

        public static void Demo()
        {
            Interview();
            Interview();
        }

        public static void Interview()
        {
            string name = PromptString("Name: ", "Name cannot be empty");

            string surname = PromptString("Surname: ", "Surname cannot be empty");

            int age = PromptInt("Age: ");

            float weight = PromptFloat("Weight(Kg): ");

            float cmHeight = PromptFloat("Height (cm): ");
            float mHeight = cmHeight / 100f;

            //  prints the description according to user's input
            Console.WriteLine($"{name} {surname} is {age} years old, their weight is {weight}Kg and their height is {cmHeight}cm");

            //  calculate BMI and print errormessage if it got an error
            float bmi = CalculateBMI(weight, mHeight);
            if (bmi < 0)
            {
                return;
            }
            Console.WriteLine($"Their bmi is {bmi}");

        }

       

        public static string PromptString(string needed, string error)
        {
            string userInput = askString(needed);

            if(userInput == "-")
            {
                Console.WriteLine(error);
                return PromptString(needed, error);
            }

            return userInput;
        }

        public static string askString(string needed)
        {
            Console.Write("Please enter your " + needed);
            string input = Console.ReadLine();
            if (!String.IsNullOrEmpty(input))
            {
                return input;
            }

            return "-";
        }
        public static int PromptInt(string v1)
        {
            int userInput = AskInt(v1);
            if(userInput == -1)
            {
                Console.WriteLine("Enter your " + v1 + " correctly");
                return PromptInt(v1);
            }

            return userInput;
        }

        public static int AskInt(string v1)
        {
            Console.Write("Please enter your " + v1);
            string input = Console.ReadLine();
            if(!String.IsNullOrEmpty(input))
            {
                return 0;
            }

            int finalNum;
            bool isInt = int.TryParse(input, out finalNum);

            if(!isInt)
            {
                Console.WriteLine(input + " is not a valid number.");
                finalNum = -1;
            }

            return finalNum;
        }

        public static float PromptFloat(string v1)
        {
            float userInput = AskFloat(v1);
            if (userInput < 0)
            {
                Console.WriteLine("Enter your " + v1 + " correctly");
                return PromptFloat(v1);
            }

            return userInput;
        }

        public static float AskFloat(string v1)
        {
            Console.WriteLine("Please enter your " + v1);
            string input = Console.ReadLine();
            if (!String.IsNullOrEmpty(input))
            {
                return 0f;
            }

            float finalNum;
            bool isFloat = float.TryParse(input, out finalNum);

            if (!isFloat)
            {
                Console.WriteLine(input + " is not a valid number.");
                finalNum = -1f;
            }

            return finalNum;
        }

        public static float CalculateBMI(float weight, float height)
        {
            if(weight <= 0 || height <= 0)
            {
                Console.WriteLine("Failed Calculating BMI because: ");
                if(weight <= 0 && height <= 0)
                {
                    Console.WriteLine($"Weight cannot be equal or less than zero.");
                    Console.WriteLine($"Height cannot be equal or less than zero.");
                }
                else if(weight <= 0)
                {
                    Console.WriteLine($"Weight cannot be equal or less than zero.");
                }
                else
                {
                    Console.WriteLine($"Height cannot be equal or less than zero.");
                }

                return -1f;
            }

            return weight / (height * height);
        }

    }
}
