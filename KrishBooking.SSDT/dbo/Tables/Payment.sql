CREATE TABLE [dbo].[Payment] (
    [ID]         VARCHAR (255) NOT NULL,
    [Name]       VARCHAR (255) NULL,
    [Amount]     VARCHAR (255) NULL,
    [PaidAmount] VARCHAR (255) NULL,
    [DueDate]    VARCHAR (255) NULL,
    [BookingID]  VARCHAR (255) NULL,
    [UserID]     VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_Payment_To_Bookings] FOREIGN KEY ([BookingID]) REFERENCES [Bookings]([ID]), 
    CONSTRAINT [FK_Payment_To_Users] FOREIGN KEY ([UserID]) REFERENCES [Users]([ID])
);

