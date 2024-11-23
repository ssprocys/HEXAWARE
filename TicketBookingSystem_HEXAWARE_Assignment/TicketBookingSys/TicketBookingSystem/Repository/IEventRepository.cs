using TicketBookingSystem.Model;

namespace TicketBookingSystem.Repository
{
    public interface IEventRepository
    {
        void CreateEvent(Event eventObj);
        int GetAvailableSeats(int eventId);
        
    }
}
