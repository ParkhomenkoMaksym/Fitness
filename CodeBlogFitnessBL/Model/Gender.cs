using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitnessBL.Model
{
    /// <summary>
    /// Gender.
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Create a new gender.
        /// </summary>
        /// <param name="name">Name of gender</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Gender(string name)
        {
            if (string.IsNullOrEmpty(name)) 
                throw new ArgumentNullException("Can't be empty", nameof(name));
            Name = name;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
