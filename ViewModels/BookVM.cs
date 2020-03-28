using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.ViewModels
{
    public class StudentBookVM
    {
        public int Id { get; set; }
        public DateTime DateBorrowed { get; set; }
        public string Title { get; set; }
        public DateTime DateToReturn { get; set; }
        public Boolean IsReturned { get; set; }
        public DateTime DateReturned { get; set; }
        
    }
}
