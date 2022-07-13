CREATE TABLE [dbo].[ApiScopes] (
    [Id]                      INT             IDENTITY (1, 1) NOT NULL,
    [Name]                    NVARCHAR (200)  NOT NULL,
    [DisplayName]             NVARCHAR (200)  NULL,
    [Description]             NVARCHAR (1000) NULL,
    [Required]                BIT             NOT NULL,
    [Emphasize]               BIT             NOT NULL,
    [ShowInDiscoveryDocument] BIT             NOT NULL,
    [ApiResourceId]           INT             NOT NULL,
    CONSTRAINT [PK_ApiScopes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ApiScopes_ApiResources_ApiResourceId] FOREIGN KEY ([ApiResourceId]) REFERENCES [dbo].[ApiResources] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ApiScopes_Name]
    ON [dbo].[ApiScopes]([Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ApiScopes_ApiResourceId]
    ON [dbo].[ApiScopes]([ApiResourceId] ASC);

