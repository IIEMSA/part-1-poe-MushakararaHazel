USE master;
IF EXISTS(SELECT * FROM sys.databases Where name = 'RegDb')
DROP DATABASE RegDB
CREATE DATABASE RegDb 

USE RegDb 

-- Drop tables in reverse order of dependencies
DROP TABLE IF EXISTS Bookings;
DROP TABLE IF EXISTS Event;
DROP TABLE IF EXISTS Venue;

-- Create tables in order of dependencies (parent tables first)
CREATE TABLE Venue (
    VenueId INT IDENTITY(1,1) PRIMARY KEY ,
    VenueName NVARCHAR(100) NOT NULL,
    Location NVARCHAR(200) NOT NULL,
    Capacity INT NOT NULL,
    ImageUrl NVARCHAR(500)
	);

	CREATE TABLE Event (
    EventId INT PRIMARY KEY IDENTITY(1,1),
    EventName NVARCHAR(100) NOT NULL,
    EventDate DATETIME NOT NULL,
    Description NVARCHAR(MAX),
    VenueId INT NULL,
    CONSTRAINT FK_Event_Venue FOREIGN KEY (VenueId) REFERENCES Venue(VenueId)
);


CREATE TABLE Bookings (
    BookingId INT PRIMARY KEY IDENTITY(1,1),
    EventId INT NOT NULL,
    VenueId INT NOT NULL,
    BookingDate DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Booking_Event FOREIGN KEY (EventId) REFERENCES Event(EventId),
    CONSTRAINT FK_Booking_Venue FOREIGN KEY (VenueId) REFERENCES Venue(VenueId),
    CONSTRAINT UQ_Event_Venue UNIQUE (EventId, VenueId)
);

-- insert sample data into the venue 
INSERT INTO Venue (VenueName , Location, Capacity, ImageUrl)
Values ( 'Venue1', 'Capetown', 100, 'image1.jpg');

-- insert sample data into the Event table 
INSERT INTO Event (EventName , EventDate,Description, VenueId)
Values ( 'Event1', '2025-04-22',' Description for Event1 ',1);


-- insert sample data into the Booking table
INSERT INTO Booking (VenueId, EventId, BookingDate)
Values ( 1, 1, '2025-04-22');

--TABLE MANIPULAION 
SELECT * FROM Venue
SELECT * FROM Event
SELECT * FROM Bookings



