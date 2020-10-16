CREATE TABLE [dbo].[Location]
(
	[Id]         INT                   NOT NULL PRIMARY KEY IDENTITY (1,1),
    [PublicId]   UNIQUEIDENTIFIER      NOT NULL DEFAULT NEWID(), 
    [ServiceId]  INT                   NOT NULL, 
    [Room]       NVARCHAR(15)          NOT NULL, 
    [Bed]        NVARCHAR(15)          NOT NULL, 
    [CreatedOn]  DATETIME2             NOT NULL DEFAULT GETUTCDATE(), 
    [ModifiedOn] DATETIME2             NULL, 
    [DeletedOn]  DATETIME2             NULL,
    CONSTRAINT   [FK_Location_Service] FOREIGN KEY ([ServiceId]) REFERENCES [Service]([Id])
)
GO
CREATE INDEX [IX_Location_Service] ON [dbo].[Location] ([ServiceId])