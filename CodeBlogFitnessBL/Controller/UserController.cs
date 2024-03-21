using CodeBlogFitnessBL.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
    public class UserController
    {
        /// <summary>
        /// user of app.
        /// </summary>
        public User User {  get; }

        /// <summary>
        /// Create a new controller of user.
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName, string genderName,DateTime birthday, double weight, double height )
        {
            // TODO Check
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthday, weight, height);
           
        }
        /// <summary>
        /// Save all data of user
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using(var fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);   
            }
        }
        /// <summary>
        /// Get a data of user
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileLoadException"></exception>
        public UserController() 
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                if(formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                // TODO: What do I do if a user don't read?
            }
        }
    }
}
