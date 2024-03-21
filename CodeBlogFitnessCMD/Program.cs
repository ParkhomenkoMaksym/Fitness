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
            Console.WriteLine("Welcome to the app for Fitness");

            Console.WriteLine("Enter a name of user");
            var name = Console.ReadLine();

            Console.WriteLine("Enter your gender");
            var gender = Console.ReadLine();

            Console.WriteLine("Enter your DOB");
            var birthday = DateTime.Parse(Console.ReadLine()); //TODO Change

            Console.WriteLine("Enter your weight");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter your height");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthday, weight, height);
            userController.Save();
            //    if(name.Length <= 1)
            //    {

            //    }
        }
    }
}
