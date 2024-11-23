-- Create the database
CREATE DATABASE TicketBookingSys

-- create venue table
CREATE TABLE Venue (
    venue_id INT PRIMARY KEY IDENTITY(1,1),
    venue_name NVARCHAR(100) NOT NULL,
    address NVARCHAR(255) NOT NULL)

--create event table
	CREATE TABLE Event (
    event_id INT PRIMARY KEY IDENTITY(1,1),
    event_name NVARCHAR(100) NOT NULL,
    event_date DATE NOT NULL,
    event_time TIME NOT NULL,
    venue_id INT NOT NULL,
    total_seats INT NOT NULL,
    available_seats INT NOT NULL,
    ticket_price DECIMAL(18,2) NOT NULL,
    event_type NVARCHAR(50) CHECK (event_type IN ('Movie', 'Sports', 'Concert')) NOT NULL,
    booking_id INT NOT NULL,
    FOREIGN KEY (venue_id) REFERENCES Venue(venue_id) ON DELETE CASCADE)

	--create customer table
	CREATE TABLE Customer (
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    customer_name NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) UNIQUE NOT NULL,
    phone_number NVARCHAR(15) UNIQUE,
    booking_id INT NOT NULL)
	
	--create booking table
	CREATE TABLE Booking (
    booking_id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT NOT NULL,
    event_id INT NOT NULL,
    num_tickets INT NOT NULL,
    total_cost DECIMAL(18,2) NOT NULL,
    booking_date DATE NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES Customer(customer_id) ON DELETE CASCADE,
    FOREIGN KEY (event_id) REFERENCES Event(event_id) ON DELETE CASCADE)

	--Inserting Data into Venue Table
	INSERT INTO Venue (venue_name, address) 
VALUES ('Stadium A', '123 Main Street, City X'),
       ('Cinema Hall B', '456 Market Road, City Y')

--Inserting Data into Event Table
INSERT INTO Event (event_name, event_date, event_time, venue_id, total_seats, available_seats, ticket_price, event_type, booking_id)
VALUES ('Football Match', '2024-12-01', '18:00:00', 1, 500, 500, 50.00, 'Sports', 1),
       ('Concert A', '2024-12-05', '20:00:00', 2, 300, 300, 30.00, 'Concert', 2)

	   --Inserting Data into Customer Table
	   INSERT INTO Customer (customer_name, email, phone_number, booking_id)
VALUES ('John Doe', 'johndoe@example.com', '9876543210', 1),
       ('Jane Smith', 'janesmith@example.com', '1234567890', 2)

	   --Inserting Data into Booking Table
	   INSERT INTO Booking (customer_id, event_id, num_tickets, total_cost, booking_date)
VALUES (1, 1, 2, 100.00, '2024-11-20'),
       (2, 2, 3, 90.00, '2024-11-21')



