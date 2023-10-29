using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace u21445045_HW03.Models.ViewModels
{
    public class AuthorTypeBorrow
    {
        
        
        public List<authors> Authors { get; set; }

        [Key]
        public int authorId { get; set; }

        public string name { get; set; }
        public string surname { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<books> books { get; set; }


        public List<types> Types { get; set; }
        [Key]
        public int typeId { get; set; }

        public string typeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        


        public List<borrows> Borrows { get; set; }
        [Key]
        public int borrowId { get; set; }

        public Nullable<int> studentId { get; set; }
        public Nullable<int> bookId { get; set; }
        public Nullable<System.DateTime> takenDate { get; set; }
        public Nullable<System.DateTime> broughtDate { get; set; }

        
        public virtual students students { get; set; }
        public virtual books Books { get; set; }
    }
}