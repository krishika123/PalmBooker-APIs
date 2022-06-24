CREATE TABLE [dbo].[Facility] (
    [ID]          UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
    [Name]        VARCHAR (255) NOT NULL,
    [Number]      VARCHAR (255) NULL,
    [Description] VARCHAR (255) NULL,
    [RatePerHour] VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

