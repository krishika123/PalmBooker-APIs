CREATE TABLE [dbo].[Contacts] (
    [ID]              UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
    [ReasonOfContact] VARCHAR (255) NULL,
    [Message]         VARCHAR (255) NULL,
    [Name]         VARCHAR (255) NULL,
    [Email]         VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

