using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Models
{
    public class Table
    {
        public int TableId { get; set; }
        [Required]
        [Display(Name = "Table Number")]
        public int TableNumber { get; set; }
        public string Description { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
