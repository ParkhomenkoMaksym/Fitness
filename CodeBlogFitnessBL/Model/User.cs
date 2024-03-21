using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodeBlogFitnessBL.Model
{
    [Serializable]
    public class User
    {
        #region Properties
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gender.
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Birthday.
        /// </summary>
        public DateTime BirthDate { get; }

        /// <summary>
        /// Weight.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        public double Height { get; set; }
        #endregion
        /// <summary>
        /// Creat a new user
        /// </summary>
        /// <param name="name">Name. </param>
        /// <param name="gender">Gender. </param>
        /// <param name="birthDate">Birthday. </param>
        /// <param name="weight">Weight. </param>
        /// <param name="height">Height. </param>
        /// <exception cref="ArgumentNullException"></exception>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Exceptions
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("The name can't be null");
                
            }
            if(gender == null) 
            {
                    throw new ArgumentNullException("Gender can't be null", nameof(gender));
            
            }
            if(birthDate < DateTime.Parse("01.01.1990") || birthDate >= DateTime.Now) 
            {
                    throw new ArgumentNullException("Invalid a date of birthday", nameof(birthDate));
            
            }
            if(weight <= 0) 
            {
                    throw new ArgumentNullException("Weight can't be less or equals to zero.", nameof(weight));
            
            }
            if(height <= 0) 
            {
                    throw new ArgumentNullException("Height can't be less or equals to zero.", nameof(height));
            
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
