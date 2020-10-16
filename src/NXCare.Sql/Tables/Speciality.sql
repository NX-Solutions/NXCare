CREATE TABLE [dbo].[Speciality]
(
	[Id]         INT          NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name]       NVARCHAR(50) NOT NULL,
    [CreatedOn]  DATETIME2    NOT NULL DEFAULT GETUTCDATE(), 
    [ModifiedOn] DATETIME2    NULL, 
    [DeletedOn]  DATETIME2    NULL,
)
