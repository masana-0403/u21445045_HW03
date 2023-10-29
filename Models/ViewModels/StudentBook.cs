using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace u21445045_HW03.Models.ViewModels
{
    public class StudentBook
    {
        //public List<students> Students { get; set; }
        [Key]
        public int studentId { get; set; }

        public string name { get; set; }
        public string surname { get; set; }
        public Nullable<System.DateTime> birthdate { get; set; }
        public string gender { get; set; }
        public string @class { get; set; }
        public Nullable<int> point { get; set; }
        //public List<books> Books { get; set; }
        [Key]
        public int bookId { get; set; }

        public string bookname { get; set; }
        public Nullable<int> pagecount { get; set; }
        public Nullable<int> bookpoint { get; set; }
        public Nullable<int> authorId { get; set; }
        public Nullable<int> typeId { get; set; }

        public virtual authors authors { get; set; }
        public virtual types types { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<borrows> borrows { get; set; }

        public IEnumerable<students> Students { get; set; }
        public IEnumerable<books> Books { get; set; }

    }
}