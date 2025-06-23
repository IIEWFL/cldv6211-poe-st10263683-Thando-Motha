DROP TABLE IF EXISTS Bookings;
DROP TABLE IF EXISTS Events;
DROP TABLE IF EXISTS Venues;
DROP TABLE IF EXISTS EventType;

-- Then recreate everything:
CREATE TABLE EventType (
    EventTypeId INT IDENTITY(1,1) PRIMARY KEY,
    TypeName NVARCHAR(100) NOT NULL
);

INSERT INTO EventType (TypeName) VALUES 
('Conference'),
('Wedding'),
('Concert'),
('Corporate Meeting');

CREATE TABLE Venues (
    VenueId INT IDENTITY(1,1) PRIMARY KEY,
    VenueName NVARCHAR(100) NOT NULL,
    Location NVARCHAR(100) NOT NULL,
    Capacity INT NOT NULL,
    ImageUrl NVARCHAR(MAX),
    Availability BIT NOT NULL DEFAULT 1,
    EventTypeId INT NULL,
    CONSTRAINT FK_Venues_EventType FOREIGN KEY (EventTypeId) REFERENCES EventType(EventTypeId)
);

CREATE TABLE Events (
    EventId INT IDENTITY(1,1) PRIMARY KEY,
    EventName NVARCHAR(100) NOT NULL
);

CREATE TABLE Bookings (
    BookingId INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(100) NOT NULL,
    BookingDate DATE NOT NULL,
    EventId INT NOT NULL,
    VenueId INT NOT NULL,
    CONSTRAINT FK_Bookings_Events FOREIGN KEY (EventId) REFERENCES Events(EventId),
    CONSTRAINT FK_Bookings_Venues FOREIGN KEY (VenueId) REFERENCES Venues(VenueId)
);
