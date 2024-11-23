using System;
using TicketBookingSystem.Repository;
using TicketBookingSystem.Model;


namespace TicketBookingSystem.Main
{
    public class TicketBookSys
    {
        private static IEventRepository eventRepository = new EventRepository();
        private static IBookingRepository bookingRepository = new BookingRepository();
        //private static object _eventRepository;
        private static IEventRepository _eventRepository = new EventRepository();
        // Method to display the menu and handle user input
        public static void DisplayMenu()
        {
            int choice;
            do
            {
                // Displaying menu options
                Console.Clear();
                Console.WriteLine("Welcome to the Ticket Booking System");
                Console.WriteLine("1. Create Event");
                Console.WriteLine("2. Book Tickets");
                Console.WriteLine("3. Cancel Tickets");
                Console.WriteLine("4. Get Available Seats");
                Console.WriteLine("5. Exit");
                Console.Write("Please choose an option (1-5): ");

                // Reading user input and handling invalid input
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid choice, please choose a number between 1 and 5.");
                }

                // Handle menu options using a switch case
                switch (choice)
                {
                    case 1:
                        CreateEvent();
                        break;

                    case 2:
                        BookTickets();
                        break;

                    case 3:
                        CancelTickets();
                        break;

                    case 4:
                        GetAvailableSeats();
                        break;

                    case 5:
                        Console.WriteLine("Exiting system...");
                        break;

                    //case 6:
                    //    Console.WriteLine("Exiting system...");
                    //    break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 5); // Loop until the user selects 'Exit'
        }

        // Placeholder methods for the menu options (to be implemented)
        public static void CreateEvent()
        {
            try
            {
                Console.WriteLine("Enter Event Details:");

                Console.Write("Event Name: ");
                string eventName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(eventName))
                    throw new ArgumentException("Event name cannot be empty.");

                Console.Write("Event Date (yyyy-MM-dd): ");
                DateTime eventDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Event Time (HH:mm:ss): ");
                TimeSpan eventTime = TimeSpan.Parse(Console.ReadLine());

                Console.Write("Venue ID: ");
                int venueId = int.Parse(Console.ReadLine());

                Console.Write("Total Seats: ");
                int totalSeats = int.Parse(Console.ReadLine());

                Console.Write("Ticket Price: ");
                decimal ticketPrice = decimal.Parse(Console.ReadLine());

                Console.Write("Event Type (Movie/Sports/Concert): ");
                string eventType = Console.ReadLine();
                if (eventType != "Movie" && eventType != "Sports" && eventType != "Concert")
                    throw new ArgumentException("Invalid event type.");

                Console.Write("Booking ID: ");
                int bookingId = int.Parse(Console.ReadLine());

                Event newEvent = new Event
                {
                    EventName = eventName,
                    EventDate = eventDate,
                    EventTime = eventTime,
                    VenueId = venueId,
                    TotalSeats = totalSeats,
                    AvailableSeats = totalSeats, // Initially, available seats = total seats
                    TicketPrice = ticketPrice,
                    EventType = eventType,
                    BookingId = bookingId
                };

                eventRepository.CreateEvent(newEvent);

                Console.WriteLine("Event created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void BookTickets()
        {
            try
            {
                Console.WriteLine("Enter Booking Details:");

                Console.Write("Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());

                Console.Write("Event ID: ");
                int eventId = int.Parse(Console.ReadLine());

                Console.Write("Number of Tickets: ");
                int numTickets = int.Parse(Console.ReadLine());

                Booking newBooking = new Booking
                {
                    CustomerId = customerId,
                    EventId = eventId,
                    NumTickets = numTickets,
                    BookingDate = DateTime.Now // Current date
                };

                bookingRepository.BookTickets(newBooking);

                Console.WriteLine("Tickets booked successfully!");
                Console.WriteLine($"Total Cost: {newBooking.TotalCost:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

       public static void CancelTickets()
        {
            try
            {
                Console.Write("Enter Booking ID to cancel: ");
                int bookingId = int.Parse(Console.ReadLine());

                bookingRepository.CancelBooking(bookingId);

                Console.WriteLine("Booking canceled successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


        private static void GetAvailableSeats()
        {
            Console.WriteLine("Enter the Event ID to check available seats: ");
            if (int.TryParse(Console.ReadLine(), out int eventId))
            {
                try
                {
                    int availableSeats = _eventRepository.GetAvailableSeats(eventId);
                    Console.WriteLine($"Available Seats for Event ID {eventId}: {availableSeats}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numeric Event ID.");
            }
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }




    }
}
