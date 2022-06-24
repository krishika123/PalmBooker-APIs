CREATE TABLE [dbo].[Payment] (
    [ID]         UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
    [Name]       VARCHAR (255) NOT NULL,
    [Amount]     VARCHAR (255) NOT NULL,
    [PaidAmount] VARCHAR (255) NULL,
    [DueDate]    VARCHAR (255) NULL,
    [BookingID]  UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_Payment_To_Bookings] FOREIGN KEY ([BookingID]) REFERENCES [Bookings]([ID])
);

