using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Models;

namespace LibraryManager.Models
{
    public partial class StudentBook
    {

        public string FullName
        { get
            {
                return Student.LastName+ " " + Student.FirstName + " "+ Student.MiddleName;
            }

        }
        public virtual Book Book { get; set; }
        public virtual Student Student{ get; set; }
    }
}
