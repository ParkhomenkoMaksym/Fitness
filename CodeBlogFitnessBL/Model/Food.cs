using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitnessBL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }
        /// <summary>
        /// Proptein
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Fat
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Carbohydrate for 100g of product
        /// </summary>
        public double Carbohydrates { get; }

        public double Calories { get; }

        //public double CaloriesOneGram { get { return Calories / 100.0; } }

        //private double ProteinsOneGram { get { return Proteins / 100.0; } }
        
        //public double FatsOneGram { get { return Fats / 100.0; } }
        
        //public double CarbohydratesOneGram => Carbohydrates / 100.0;
        
        public Food(string name) : this(name, 0, 0, 0, 0)
        {
 
        }

        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0 ;
            //Check


        }
        public override string ToString()
        {
            return Name;
        }

    }
}
