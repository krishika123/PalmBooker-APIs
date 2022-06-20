CREATE TABLE [dbo].[Contacts] (
    [ID]              VARCHAR (255) NOT NULL,
    [UserID]          VARCHAR (255) NULL,
    [ReasonOfContact] VARCHAR (255) NULL,
    [Message]         VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_Contacts_To_Users] FOREIGN KEY ([UserID]) REFERENCES [USers]([ID])
);

