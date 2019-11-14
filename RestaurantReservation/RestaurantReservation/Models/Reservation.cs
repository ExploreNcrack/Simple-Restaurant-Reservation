using RestaurantReservation.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        [Required]
        [ValidReservationDateTime("ReservationEnd", ErrorMessage = "Not valid")]
        [Display(Name = "Reservation Start")]
        public DateTime ReservationStart { get; set; }
        [Required]
        [Display(Name = "Reservation End")]
        public DateTime ReservationEnd { get; set; }
        [Required]
        [Display(Name = "Number Of People")]
        public int NumberOfPeople { get; set; }
    
        public int TableId { get;set; }
        public Table Table { get; set; }
    }
}
