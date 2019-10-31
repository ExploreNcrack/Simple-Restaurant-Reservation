using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public string Description { get; set; }
        public int NumberOfSeats { get; set; }

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
