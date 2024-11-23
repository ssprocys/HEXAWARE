using System;

namespace TicketBookingSystem.Model
{
    public class Event
    {
        private int _eventId;
        private string _eventName;
        private DateTime _eventDate;
        private TimeSpan _eventTime;
        private int _venueId;
        private int _totalSeats;
        private int _availableSeats;
        private decimal _ticketPrice;
        private string _eventType;  // Movie, Sports, Concert
        private int _bookingId;

        // Manual property for EventId
        public int EventId
        {
            get { return _eventId; }
            set { _eventId = value; }
        }

        // Manual property for EventName
        public string EventName
        {
            get { return _eventName; }
            set { _eventName = value; }
        }

        // Manual property for EventDate
        public DateTime EventDate
        {
            get { return _eventDate; }
            set { _eventDate = value; }
        }

        // Manual property for EventTime
        public TimeSpan EventTime
        {
            get { return _eventTime; }
            set { _eventTime = value; }
        }

        // Manual property for VenueId
        public int VenueId
        {
            get { return _venueId; }
            set { _venueId = value; }
        }

        // Manual property for TotalSeats
        public int TotalSeats
        {
            get { return _totalSeats; }
            set { _totalSeats = value; }
        }

        // Manual property for AvailableSeats
        public int AvailableSeats
        {
            get { return _availableSeats; }
            set { _availableSeats = value; }
        }

        // Manual property for TicketPrice
        public decimal TicketPrice
        {
            get { return _ticketPrice; }
            set { _ticketPrice = value; }
        }

        // Manual property for EventType
        public string EventType
        {
            get { return _eventType; }
            set { _eventType = value; }
        }

        // Manual property for BookingId
        public int BookingId
        {
            get { return _bookingId; }
            set { _bookingId = value; }
        }

        public object VenueName { get; internal set; }

        // ToString method to display the details of the Event
        public override string ToString()
        {
            return $"EventId: {EventId}, EventName: {EventName}, EventDate: {EventDate.ToShortDateString()}, EventTime: {EventTime}, VenueId: {VenueId}, AvailableSeats: {AvailableSeats}, TicketPrice: {TicketPrice:C}, EventType: {EventType}";
        }
    }
}
