CREATE TABLE [dbo].[Users] (
    [ID]          UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
    [Name]        VARCHAR (255) NOT NULL,
    [Email]       VARCHAR (255) NOT NULL,
    [PhoneNumber] VARCHAR (255) NOT NULL,

    PRIMARY KEY CLUSTERED ([ID] ASC)
);

