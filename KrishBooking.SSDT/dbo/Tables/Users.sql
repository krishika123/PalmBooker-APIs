CREATE TABLE [dbo].[Users] (
    [ID]          VARCHAR (255) NOT NULL,
    [Name]        VARCHAR (255) NULL,
    [Email]       VARCHAR (255) NULL,
    [PhoneNumber] VARCHAR (255) NULL,
    [BookingID]   VARCHAR (255) NULL,
    [PaymentID]   VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Users_To_Bookings] FOREIGN KEY ([BookingID]) REFERENCES [Bookings]([ID]), 
    CONSTRAINT [FK_Users_To_Payment] FOREIGN KEY ([PaymentID]) REFERENCES [Payment]([ID])
);

