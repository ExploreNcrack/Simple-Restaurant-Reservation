﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.ViewModels
{
    public class ConfirmTableReservationViewModel
    {
        public ReservationViewModel reservationViewModel { get; set; }
        public TableCreateViewModel tableCreateViewModel { get; set; }
    }
}
