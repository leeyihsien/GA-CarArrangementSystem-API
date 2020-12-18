using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA_CarArrangementSystem_API.ViewModels
{
    public class PassengerSearchViewModel
    {
        public string ArrangementId { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string UserPhone { get; set; }

        public string RouteId { get; set; }

        public string RouteName { get; set; }

        public string RouteType { get; set; }

        public DateTime DepartureTime { get; set; }

        public string CarId { get; set; }

        public string CarBrand { get; set; }


        public string DriverId { get; set; }

        public string DriverName { get; set; }

        public string DriverPhone { get; set; }


        public string ArrangementStatus { get; set; }

        public string ArrangementRemark { get; set; }
    }
}
