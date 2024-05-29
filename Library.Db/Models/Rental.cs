using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Db.Models
{
    public class Rental
    {
        public int RentalId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
