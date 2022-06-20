CREATE TABLE [dbo].[Bookings] (
    [ID]             VARCHAR (255) NOT NULL,
    [UserID]         VARCHAR (255) NULL,
    [FacilityID]     VARCHAR (255) NULL,
    [PaymentID]      VARCHAR (255) NULL,
    [EventDate]      VARCHAR (255) NULL,
    [EventTime]      VARCHAR (255) NULL,
    [StatusAoD]      VARCHAR (255) NULL,
    [AdditionalInfo] VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_Bookings_To_Users] FOREIGN KEY ([UserID]) REFERENCES [Users]([ID]),
    CONSTRAINT [FK_Bookings_To_Payment] FOREIGN KEY ([PaymentID]) REFERENCES [Payment]([ID]), 
    CONSTRAINT [FK_Bookings_To_Facility] FOREIGN KEY ([FacilityID]) REFERENCES [Facility]([ID])
);

