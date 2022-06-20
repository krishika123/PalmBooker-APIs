CREATE TABLE [dbo].[Facility] (
    [ID]          VARCHAR (255) NOT NULL,
    [Name]        VARCHAR (255) NULL,
    [Number]      VARCHAR (255) NULL,
    [Description] VARCHAR (255) NULL,
    [BookingID]   VARCHAR (255) NULL,
    [RatePerHour] VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_Facility_To_Bookings] FOREIGN KEY ([BookingID]) REFERENCES [Bookings]([ID])
);

