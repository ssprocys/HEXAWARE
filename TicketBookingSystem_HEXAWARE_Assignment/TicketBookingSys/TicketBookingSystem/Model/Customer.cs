namespace TicketBookingSystem.Model
{
    public class Customer
    {
        private int _customerId;
        private string _customerName;
        private string _email;
        private string _phoneNumber;
        private int _bookingId;

        // Manual property for CustomerId
        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        // Manual property for CustomerName
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        // Manual property for Email
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        // Manual property for PhoneNumber
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        // Manual property for BookingId
        public int BookingId
        {
            get { return _bookingId; }
            set { _bookingId = value; }
        }

        // ToString method to display the details of the Customer
        public override string ToString()
        {
            return $"CustomerId: {CustomerId}, CustomerName: {CustomerName}, Email: {Email}, PhoneNumber: {PhoneNumber}, BookingId: {BookingId}";
        }
    }
}
