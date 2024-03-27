using CodeBlogFitnessBL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitnessBL.Controller
{
    public class EatingController : ControllerBase
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eating.dat";
        private readonly User user;

        public List<Food> Foods { get; }

        public Eating Eating { get; }


        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User can't be empty", nameof(user));

            Foods = GetAllFoods();
            Eating = GetAllEating();
        }

       
        public void Add(Food food, double weight)
        {
            var propduct = Foods.SingleOrDefault(f => f.Name == food.Name);
            if(propduct == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(propduct, weight);
                Save();
            }
        }

        private Eating GetAllEating()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
           
            
        }
        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eating);
        }
    }
}
