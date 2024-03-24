using CodeBlogFitnessBL.Controller;
using CodeBlogFitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitnessCMD
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the app for the Fitness");

            Console.WriteLine("Enter a name of user");
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

            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter your gender");
                var gender = Console.ReadLine();
                var birthday = ParseDateTime();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");
                

                userController.SetNewUsersData(gender, birthday, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();

            //userController.Save();
            ////    if(name.Length <var userController = new UserController(name, gender, birthday, weight, height);
            //userController.Save();
            ////    if(name.Length <= 1)
            //    {

            //    }
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthday;
            while (true)
            {
                Console.WriteLine("Enter your DOB (dd.MM.yyyy):");
                //string birthday = Console.ReadLine(); //TODO Change
                if (DateTime.TryParse(Console.ReadLine(), out birthday))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("This format not available");
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
