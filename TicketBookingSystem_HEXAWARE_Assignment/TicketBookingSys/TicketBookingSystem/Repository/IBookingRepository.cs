using TicketBookingSystem.Model;

namespace TicketBookingSystem.Repository
{
    public interface IBookingRepository
    {
        void BookTickets(Booking booking);
        void CancelBooking(int bookingId);

    }
}
