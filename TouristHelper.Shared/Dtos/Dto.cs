using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristHelper.Shared.Dto
{
    public class TouristProfileDto
    {
        public int TouristId { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public bool IsActive { get; set; }
        public DateTime AccountCreated { get; set; }
    }

    public class HotelBookingDto
    {
        public int BookingID { get; set; }
        public string HotelName { get; set; } = default!;
        public string RoomType { get; set; } = default!;
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string BookingStatus { get; set; } = default!;
        public decimal TotalAmount { get; set; }
    }

    public class TourBookingDto
    {
        public int BookingID { get; set; }
        public string TourName { get; set; } = default!;
        public DateTime TravelDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public decimal TourPrice { get; set; }
        public string BookingStatus { get; set; } = default!;
    }

    public class RideBookingDto
    {
        public int BookingID { get; set; }
        public string CarType { get; set; } = default!;
        public string Driver { get; set; } = default!;
        public string Pickup { get; set; } = default!;
        public string Dropoff { get; set; } = default!;
        public DateTime PickupTime { get; set; }
        public int Passengers { get; set; }
        public string BookingStatus { get; set; } = default!;
    }

    public class PaymentDto
    {
        public int PaymentID { get; set; }
        public int BookingID { get; set; }
        public string Method { get; set; } = default!;
        public string Status { get; set; } = default!;
        public decimal Amount { get; set; }
        public DateTime? PaidAt { get; set; }
    }

    public class FeedbackDto
    {
        public int FeedbackID { get; set; }
        public int BookingID { get; set; }
        public string FeedbackText { get; set; } = default!;
        public DateTime SubmittedAt { get; set; }
    }
}

