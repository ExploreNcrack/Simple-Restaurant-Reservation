﻿using System;
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
        public DateTime ReservationStart { get; set; }
        [Required]
        public DateTime ReservationEnd { get; set; }
        [Required]
        public int NumberOfPeople { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public Table Table { get; set; }
    }
}
