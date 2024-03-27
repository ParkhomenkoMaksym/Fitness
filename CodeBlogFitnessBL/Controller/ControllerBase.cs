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
    public abstract class ControllerBase
    {
        protected void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {

                formatter.Serialize(fs, item);
            }
        }
        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                //fs.Length;
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
                // TODO: What do I do if a user don't read?
            }
        }
    }
}
