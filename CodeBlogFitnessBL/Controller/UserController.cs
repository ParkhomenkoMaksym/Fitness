using CodeBlogFitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitnessBL.Controller
{      
        /// <summary>
        /// Controller of user.
        /// </summary>
    public class UserController : ControllerBase
    {
        private const string USERS_FILE_NAME = "user.dat";
        /// <summary>
        /// user of app.
        /// </summary>
        public List<User> Users { get; } //IEnumerable

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Create a new controller of user.
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName)
        {
            // TODO Check
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("The name of user can't be null", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
            //var gender = new Gender(genderName);
            //Users = new List<User>() { userName, gender, birthday, weight, height };
           
        }
        public void SetNewUsersData(string genderName, DateTime birthDate, double weight = 1, double height = 1) 
        {
            //Check
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;  
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
        /// <summary>
        /// Save all data of user
        /// </summary>
        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
        }
        /// <summary>
        /// Get a save List of user
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileLoadException"></exception>
        private List<User> GetUsersData() 
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();  
        }
    }
}
