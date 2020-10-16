CREATE TABLE [dbo].[Service]
(
	[Id]         INT          NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name]       NVARCHAR(25) NOT NULL,
    [CreatedOn]  DATETIME2    NOT NULL DEFAULT GETUTCDATE(), 
    [ModifiedOn] DATETIME2    NULL, 
    [DeletedOn]  DATETIME2    NULL,
)
