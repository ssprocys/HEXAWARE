using System;
using System.Data.SqlClient;
using System.Text;
using TicketBookingSystem.Exceptions;
using TicketBookingSystem.Model;
using TicketBookingSystem.Utility;

namespace TicketBookingSystem.Repository
{
    public class EventRepository : IEventRepository
    {
        public void CreateEvent(Event eventObj)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DbConnUtil.GetConnectionString()))
                {
                    conn.Open();
                    string query = @"INSERT INTO Event (event_name, event_date, event_time, venue_id, total_seats, available_seats, ticket_price, event_type, booking_id)
                                     VALUES (@event_name, @event_date, @event_time, @venue_id, @total_seats, @available_seats, @ticket_price, @event_type, @booking_id)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@event_name", eventObj.EventName);
                        cmd.Parameters.AddWithValue("@event_date", eventObj.EventDate);
                        cmd.Parameters.AddWithValue("@event_time", eventObj.EventTime);
                        cmd.Parameters.AddWithValue("@venue_id", eventObj.VenueId);
                        cmd.Parameters.AddWithValue("@total_seats", eventObj.TotalSeats);
                        cmd.Parameters.AddWithValue("@available_seats", eventObj.AvailableSeats);
                        cmd.Parameters.AddWithValue("@ticket_price", eventObj.TicketPrice);
                        cmd.Parameters.AddWithValue("@event_type", eventObj.EventType);
                        cmd.Parameters.AddWithValue("@booking_id", eventObj.BookingId);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while creating event: " + ex.Message);
                throw;
            }
        }

        public int GetAvailableSeats(int eventId)
        {
            using (var connection = new SqlConnection(DbConnUtil.GetConnectionString()))
            {
                connection.Open();

                // Query to get available seats
                string query = "SELECT available_seats FROM Event WHERE event_id = @eventId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@eventId", eventId);

                var result = command.ExecuteScalar();
                if (result == null)
                {
                    throw new Exception("EventNotFoundException: Event ID not found.");
                }

                return Convert.ToInt32(result);
            }
        }


       
      

        
    }
}
