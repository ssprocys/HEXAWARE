using System;

namespace TicketBookingSystem.Model
{
    public class Booking
    {
        private int _bookingId;
        private int _customerId;
        private int _eventId;
        private int _numTickets;
        private decimal _totalCost;
        private DateTime _bookingDate;

        // Manual property for BookingId
        public int BookingId
        {
            get { return _bookingId; }
            set { _bookingId = value; }
        }

        // Manual property for CustomerId
        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        // Manual property for EventId
        public int EventId
        {
            get { return _eventId; }
            set { _eventId = value; }
        }

        // Manual property for NumTickets
        public int NumTickets
        {
            get { return _numTickets; }
            set { _numTickets = value; }
        }

        // Manual property for TotalCost
        public decimal TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        // Manual property for BookingDate
        public DateTime BookingDate
        {
            get { return _bookingDate; }
            set { _bookingDate = value; }
        }

        // ToString method to display the details of the Booking
        public override string ToString()
        {
            return $"BookingId: {BookingId}, CustomerId: {CustomerId}, EventId: {EventId}, NumTickets: {NumTickets}, TotalCost: {TotalCost:C}, BookingDate: {BookingDate.ToShortDateString()}";
        }
    }
}
