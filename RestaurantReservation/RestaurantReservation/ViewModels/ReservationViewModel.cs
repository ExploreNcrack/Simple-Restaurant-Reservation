using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.ViewModels
{
    public class ReservationViewModel
    {
        [Required]
        [Display(Name = "Reservation Start")]
        public DateTime ReservationStart { get; set; }
        [Required]
        [Display(Name = "Reservation End")]
        public DateTime ReservationEnd { get; set; }
        [Required]
        [Display(Name = "Number Of People")]
        public int NumberOfPeople { get; set; }
        public int TableId { get; set; }
    }
}
