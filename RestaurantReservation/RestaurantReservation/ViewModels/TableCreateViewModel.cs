using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.ViewModels
{
    public class TableCreateViewModel
    {
        [Required]
        [Display(Name = "Table Number")]
        public int TableNumber { get; set; }
        
        public string Description { get; set; }

        [Required]
        [Display(Name = "Number Of Seats")]
        public int NumberOfSeats { get; set; }
    }
}
