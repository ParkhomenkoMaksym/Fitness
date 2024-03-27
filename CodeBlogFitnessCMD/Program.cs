using CodeBlogFitnessBL.Controller;
using CodeBlogFitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitnessCMD
{
    public class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-RU");
            var resourceManager = new ResourceManager("CodeBlogFitnessCMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            //Console.WriteLine("Enter your gender");
            //var gender = Console.ReadLine();

            //Console.WriteLine("Enter your DOB");
            //var birthday = DateTime.Parse(Console.ReadLine()); //TODO Change

            //Console.WriteLine("Enter your weight");
            //var weight = double.Parse(Console.ReadLine());

            //Console.WriteLine("Enter your height");
            //var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            
            

            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter your gender");
                var gender = Console.ReadLine();
                var birthday = ParseDateTime("your DOB");
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");
                

                userController.SetNewUsersData(gender, birthday, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("What's food do you want?");
            Console.WriteLine("E - enter a meal");
            Console.WriteLine("A - enter an exercise");
            Console.WriteLine("Q - exit");

            var key = Console.ReadKey();
            Console.WriteLine();
            while (true)
            {
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                      
    

                        //var foods = product;
                         eatingController.Add(foods.Food, foods.Weight);
                        //eatingController.Add(product, weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        //var exercise = new Exercise(exe.Begin, exe.End, exe.Activity, userController.CurrentUser);
                        //Console.WriteLine("Enter a name of a product:");
                        //string food = Console.ReadLine();

                        //var calories = ParseDouble("calories");
                        //var proteins = ParseDouble("proteins");
                        //var fats = ParseDouble("fats");
                        //var carbs = ParseDouble("carbohydrates");
                        //var weight = ParseDouble("the weight of item");

                        //var product = new Food(food, calories, proteins, fats, carbs);

                        //var foods = product;
                        // eatingController.Add(foods.Food, foods.Weight);
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} from {item.Start.ToShortTimeString()} to {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }

            //userController.Save();
            ////    if(name.Length <var userController = new UserController(name, gender, birthday, weight, height);
            //userController.Save();
            ////    if(name.Length <= 1)
            //    {

            //    }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Enter a name of an exercise:");
            var name = Console.ReadLine();

            var energy = ParseDouble("spend your energy");
            var begin = ParseDateTime("begin an exercise");
            var end = ParseDateTime("end an exercise");
            var activity = new Activity(name, energy);

            return (begin, end, activity);


        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Enter a name of a product:");
            var food = Console.ReadLine();

            var calories = ParseDouble("calories");
            var proteins = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbs = ParseDouble("carbohydrates");
            var weight = ParseDouble("the weight of item");

            var product = new Food(food, calories, proteins, fats, carbs);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthday;
            while (true)
            {
                Console.WriteLine($"Enter {value} (dd.MM.yyyy):");
                //string birthday = Console.ReadLine(); //TODO Change
                if (DateTime.TryParse(Console.ReadLine(), out birthday))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"This format not available {value}");
                }
            }

            return birthday;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Enter your: {name}");
                //string birthday = Console.ReadLine(); //TODO Change
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"This format not available {name}");
                }
            }
        }
    }
}
