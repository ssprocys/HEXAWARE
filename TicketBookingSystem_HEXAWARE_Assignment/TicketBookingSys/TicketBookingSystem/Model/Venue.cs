namespace TicketBookingSystem.Model
{
    public class Venue
    {
        private int _venueId;
        private string _venueName;
        private string _address;

        // Manual property for VenueId
        public int VenueId
        {
            get { return _venueId; }
            set { _venueId = value; }
        }

        // Manual property for VenueName
        public string VenueName
        {
            get { return _venueName; }
            set { _venueName = value; }
        }

        // Manual property for Address
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        // ToString method to display the details of the Venue
        public override string ToString()
        {
            return $"VenueId: {VenueId}, VenueName: {VenueName}, Address: {Address}";
        }
    }
}
