using System;
using System.Data.SqlClient;
using TicketBookingSystem.Model;
using TicketBookingSystem.Utility;

namespace TicketBookingSystem.Repository
{
    public class BookingRepository : IBookingRepository
    {
        public void BookTickets(Booking booking)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DbConnUtil.GetConnectionString()))
                {
                    conn.Open();

                    // Check if event exists and has enough seats
                    string checkEventQuery = "SELECT available_seats, ticket_price FROM Event WHERE event_id = @event_id";
                    using (SqlCommand checkCmd = new SqlCommand(checkEventQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@event_id", booking.EventId);

                        using (SqlDataReader reader = checkCmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                throw new Exception("Event not found.");
                            }

                            int availableSeats = reader.GetInt32(0);
                            decimal ticketPrice = reader.GetDecimal(1);

                            if (availableSeats < booking.NumTickets)
                            {
                                throw new Exception("Not enough available seats.");
                            }

                            booking.TotalCost = ticketPrice * booking.NumTickets; // Calculate total cost
                        }
                    }

                    // Update available seats in Event table
                    string updateSeatsQuery = "UPDATE Event SET available_seats = available_seats - @num_tickets WHERE event_id = @event_id";
                    using (SqlCommand updateCmd = new SqlCommand(updateSeatsQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@num_tickets", booking.NumTickets);
                        updateCmd.Parameters.AddWithValue("@event_id", booking.EventId);

                        updateCmd.ExecuteNonQuery();
                    }

                    // Insert booking into Booking table
                    string insertBookingQuery = @"INSERT INTO Booking (customer_id, event_id, num_tickets, total_cost, booking_date)
                                                  VALUES (@customer_id, @event_id, @num_tickets, @total_cost, @booking_date)";
                    using (SqlCommand insertCmd = new SqlCommand(insertBookingQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@customer_id", booking.CustomerId);
                        insertCmd.Parameters.AddWithValue("@event_id", booking.EventId);
                        insertCmd.Parameters.AddWithValue("@num_tickets", booking.NumTickets);
                        insertCmd.Parameters.AddWithValue("@total_cost", booking.TotalCost);
                        insertCmd.Parameters.AddWithValue("@booking_date", booking.BookingDate);

                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while booking tickets: " + ex.Message);
                throw;
            }
        }

        public void CancelBooking(int bookingId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DbConnUtil.GetConnectionString()))
                {
                    conn.Open();

                    // Retrieve booking details
                    string getBookingQuery = "SELECT event_id, num_tickets FROM Booking WHERE booking_id = @booking_id";
                    int eventId = 0;
                    int numTickets = 0;

                    using (SqlCommand getCmd = new SqlCommand(getBookingQuery, conn))
                    {
                        getCmd.Parameters.AddWithValue("@booking_id", bookingId);

                        using (SqlDataReader reader = getCmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                throw new Exception("Invalid Booking ID. No such booking exists.");
                            }

                            eventId = reader.GetInt32(0);
                            numTickets = reader.GetInt32(1);
                        }
                    }

                    // Update available seats in Event table
                    string updateSeatsQuery = "UPDATE Event SET available_seats = available_seats + @num_tickets WHERE event_id = @event_id";
                    using (SqlCommand updateCmd = new SqlCommand(updateSeatsQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@num_tickets", numTickets);
                        updateCmd.Parameters.AddWithValue("@event_id", eventId);

                        updateCmd.ExecuteNonQuery();
                    }

                    // Delete the booking from Booking table
                    string deleteBookingQuery = "DELETE FROM Booking WHERE booking_id = @booking_id";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteBookingQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@booking_id", bookingId);

                        deleteCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while canceling booking: " + ex.Message);
                throw;
            }
        }

    }
}
