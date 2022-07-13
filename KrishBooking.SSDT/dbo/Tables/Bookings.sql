CREATE TABLE [dbo].[Bookings] (
    [ID]             UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
    [UserID]         NVARCHAR(450) NULL,
    [FacilityID]     UNIQUEIDENTIFIER NULL,
    [EventDate]      VARCHAR (255) NULL,
    [EventTime]      VARCHAR (255) NULL,
    [StatusAoD]      VARCHAR (255) NULL ,
    [AdditionalInfo] VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_Bookings_To_Facility] FOREIGN KEY ([FacilityID]) REFERENCES [Facility]([ID]), 
    CONSTRAINT [FK_Bookings_To_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers]([Id])
);

